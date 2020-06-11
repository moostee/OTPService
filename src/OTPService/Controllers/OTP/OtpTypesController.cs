using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTP.Core.Common;
using OTP.Core.Domain.Form.OTP;
using OTP.Core.Domain.Model.OTP;
using OTP.Core.Logic;
using OTP.Core.UI;

namespace OTP.Service.Controllers.OTP
{
    public class OtpTypesController : BaseApiController
    {
        private readonly ILogicModule Logic;

        public OtpTypesController(ILogicModule logic)
        {
            Logic = logic;
        }
        /// <summary>
        /// Search, Page, filter and Shaped OtpTypes
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="fields"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        [Produces(typeof(IEnumerable<OtpTypeModel>))]
        [Route("Search", Name = "OtpTypeApi")]
        [HttpGet]
        public IActionResult Get(string sort = "Id", string name = "", long page = 1, long pageSize = 10, string fields = "", int draw = 1)
        {
            try
            {
                var items = Logic.OtpTypeLogic.SearchView(name, page, pageSize, sort);

                if (page > items.TotalPages) page = items.TotalPages;
                var jo = new JObjectHelper();
                jo.Add("name", name);

                jo.Add("fields", fields);
                jo.Add("sort", sort);
                var linkBuilder = new PageLinkBuilder( jo, page, pageSize, items.TotalItems, draw);
                AddHeader("X-Pagination", linkBuilder.PaginationHeader);
                var dto = new List<OtpTypeModel>();
                if (items.TotalItems <= 0) return Ok(dto);
                var dtos = items.Items.ShapeList(fields);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get OtpType by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Detail")]
        [Produces(typeof(OtpTypeModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await Logic.OtpTypeLogic.GetModel(id);
                if (item == null)
                {
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "OtpType not found" }));
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(SerializeUtility.SerializeJSON(new { Message = ex.Message }));
            }
        }

        /// <summary>
        /// Add OtpType
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        [Produces(typeof(OtpTypeModel))]
        public async Task<IActionResult> Create(OtpTypeForm form)
        {
            try
            {
                var model = Logic.OtpTypeLogic.Create(form);
                var check = Logic.OtpTypeLogic.CreateExists(model);
                if (check)
                {
                    return BadRequest(SerializeUtility.SerializeJSON(new { Message = "OtpType already exists" }));
                }
                var dto = await Logic.OtpTypeLogic.Insert(model);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update OtpType
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        [Produces(typeof(OtpTypeModel))]
        public IActionResult Update(int id, OtpTypeForm form)
        {
            try
            {
                var model = Logic.OtpTypeLogic.Create(form);
                if (id != model.Id)
                    return BadRequest(SerializeUtility.SerializeJSON(new { Message = "Route Parameter does not match model ID" }));
                var found = Logic.OtpTypeLogic.Get(id);
                if (found == null)
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "OtpType not found" }));
                var check = Logic.OtpTypeLogic.UpdateExists(model);
                if (check)
                    return BadRequest(SerializeUtility.SerializeJSON(new { Message = "OtpType configuration already exists" }));
                var dto = Logic.OtpTypeLogic.Update(found, model,
                    "Name,RecordStatus");
                return Ok(dto);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(SerializeUtility.SerializeJSON(new { Message = ex.Message }));
            }
        }

        /// <summary>
        /// Delete OtpType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpPost]
        [Produces(typeof(OtpTypeModel))]
        public IActionResult Delete(int id)
        {
            try
            {
                var found = Logic.OtpTypeLogic.Get(id);
                if (found == null)
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "OtpType not found" }));
                Logic.OtpTypeLogic.Delete(found);
                return Ok(found);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(SerializeUtility.SerializeJSON(new { Message = ex.Message }));
            }
        }
    }
}