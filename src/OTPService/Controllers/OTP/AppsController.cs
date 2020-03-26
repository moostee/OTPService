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
    
    public class AppsController : BaseApiController
    {
        private readonly ILogicModule Logic;

        public AppsController(ILogicModule logic)
        {
            Logic = logic;
        }
        /// <summary>
        /// Add App
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        [Produces(typeof(AppModel))]
        public async Task<IActionResult> Create(AppForm form)
        {
            try
            {
                var model = Logic.AppLogic.Create(form);
                var check = Logic.AppLogic.CreateExists(model);
                if (check)
                {
                    return BadRequest(SerializeUtility.SerializeJSON(new { Message = "App already exists" }));
                }
                var dto = await Logic.AppLogic.Insert(model);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get App by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Detail")]
        [Produces(typeof(AppModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await Logic.AppLogic.GetModel(id);
                if (item == null)
                {
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "App not found" }));
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
        /// Search, Page, filter and Shaped Apps
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="name"></param>
        /// <param name="appSecret"></param>
        /// <param name="otpTypeId"></param>
        /// <param name="otpLength"></param>
        /// <param name="hasExpiry"></param>
        /// <param name="expiryPeriod"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="fields"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        [Produces(typeof(IEnumerable<AppModel>))]
        [Route("Search", Name = "AppApi")]
        [HttpGet]
        public IActionResult Get(string sort = "Id", string name = "", string appSecret = "", int otpTypeId = 0, int otpLength = 0, bool? hasExpiry = null, TimeSpan? expiryPeriod = null, long page = 1, long pageSize = 10, string fields = "", int draw = 1)
        {
            try
            {
                var items = Logic.AppLogic.SearchView(name, appSecret, otpTypeId, otpLength, hasExpiry, expiryPeriod, page, pageSize, sort);

                if (page > items.TotalPages) page = items.TotalPages;
                var jo = new JObjectHelper();
                jo.Add("name", name);
                jo.Add("appSecret", appSecret);
                jo.Add("otpTypeId", otpTypeId);
                jo.Add("otpLength", otpLength);
                jo.Add("hasExpiry", hasExpiry);
                jo.Add("expiryPeriod", expiryPeriod.ToString());

                jo.Add("fields", fields);
                jo.Add("sort", sort);
                var linkBuilder = new PageLinkBuilder(jo, page, pageSize, items.TotalItems, draw);
                AddHeader("X-Pagination", linkBuilder.PaginationHeader);
                var dto = new List<AppModel>();
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
        /// Update App
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        [Produces(typeof(AppModel))]
        public IActionResult Update(int id, AppForm form)
        {
            try
            {
                var model = Logic.AppLogic.Create(form);
                if (id != model.Id)
                    return BadRequest(SerializeUtility.SerializeJSON(new { Message = "Route Parameter does not match model ID" }));
                var found = Logic.AppLogic.Get(id);
                if (found == null)
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "App not found" }));
                var check = Logic.AppLogic.UpdateExists(model);
                if (check)
                    return BadRequest(SerializeUtility.SerializeJSON(new { Message = "App configuration already exists" }));
                var dto = Logic.AppLogic.Update(found, model,
                    "Name,AppSecret,OtpTypeId,OtpLength,HasExpiry,ExpiryPeriod,RecordStatus");
                return Ok(dto);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(SerializeUtility.SerializeJSON(new { Message = ex.Message }));
            }
        }

        /// <summary>
        /// Delete App
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpPost]
        [Produces(typeof(AppModel))]
        public IActionResult Delete(int id)
        {
            try
            {
                var found = Logic.AppLogic.Get(id);
                if (found == null)
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "App not found" }));
                Logic.AppLogic.Delete(found);
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