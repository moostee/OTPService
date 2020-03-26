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

    }
}