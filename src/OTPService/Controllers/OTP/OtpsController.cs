using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTP.Core.Common;
using OTP.Core.Domain.Form.OTP;
using OTP.Core.Domain.Model.Helper;
using OTP.Core.Domain.Model.OTP;
using OTP.Core.Logic;
using OTP.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTP.Service.Controllers.OTP
{
    public class OtpsController : BaseApiController
    {
        private readonly ILogicModule Logic;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _clientSecret;

        public OtpsController(ILogicModule logic, IHttpContextAccessor httpContextAccessor)
        {
            Logic = logic;
            _httpContextAccessor = httpContextAccessor;
            _clientSecret = _httpContextAccessor.HttpContext.Request.Headers["X-ClientSecret"];
        }
        /// <summary>
        /// Search, Page, filter and Shaped Otps
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="appId"></param>
        /// <param name="appFeature"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="dialCode"></param>
        /// <param name="otpCode"></param>
        /// <param name="isUsed"></param>
        /// <param name="timeUsed"></param>
        /// <param name="expiryDate"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="fields"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        [Produces(typeof(IEnumerable<OtpModel>))]
        [Route("Search", Name = "OtpApi")]
        [HttpGet]
        public IActionResult Get(string sort = "Id", int appId = 0, string appFeature = "", string phoneNumber = "", string email = "", string dialCode = "", int otpCode = 0, bool? isUsed = null, DateTime? timeUsed = null, DateTime? expiryDate = null, long page = 1, long pageSize = 10, string fields = "", int draw = 1)
        {
            try
            {
                var items = Logic.OtpLogic.SearchView(appId, appFeature, phoneNumber, email, dialCode, otpCode, isUsed, timeUsed, expiryDate, page, pageSize, sort);

                if (page > items.TotalPages) page = items.TotalPages;
                var jo = new JObjectHelper();
                jo.Add("appId", appId);
                jo.Add("appFeature", appFeature);
                jo.Add("phoneNumber", phoneNumber);
                jo.Add("email", email);
                jo.Add("dialCode", dialCode);
                jo.Add("otpCode", otpCode);
                jo.Add("isUsed", isUsed);
                jo.Add("timeUsed", timeUsed);
                jo.Add("expiryDate", expiryDate);

                jo.Add("fields", fields);
                jo.Add("sort", sort);
                var linkBuilder = new PageLinkBuilder(jo, page, pageSize, items.TotalItems, draw);
                AddHeader("X-Pagination", linkBuilder.PaginationHeader);
                var dto = new List<OtpModel>();
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
        /// Get Otp by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Detail")]
        [Produces(typeof(OtpModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await Logic.OtpLogic.GetModel(id);
                if (item == null)
                {
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "Otp not found" }));
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
        /// Add Otp
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        [Produces(typeof(OtpModel))]
        public async Task<IActionResult> Create(OtpForm form)
        {
            var response = Utilities.InitializeResponse();
            try
            {
                var appModel = Logic.AppLogic.SearchView("", _clientSecret).Items.FirstOrDefault();
                var app = Logic.AppLogic.Create(appModel);
                var model = Logic.OtpLogic.Create(form);
                var (hasError, errorMessage) = Logic.OtpLogic.ValidateAppOtpType(model, app.OtpTypeId);
                if (hasError) return BadRequest(Utilities.UnsuccessfulResponse(response, errorMessage));
                var otpExists = Logic.OtpLogic.Search(app.Id, model.AppFeature, model.PhoneNumber, model.Email, model.DialCode, 0, false).FirstOrDefault();
                if (otpExists == null)
                {
                    response.Data = await Logic.OtpLogic.ProcessOtpCreation(model, app);
                }
                else
                {
                    if (app.HasExpiry)
                        otpExists.ExpiryDate = DateTime.UtcNow.Add(app.ExpiryPeriod);
                    Logic.OtpLogic.Update(otpExists);
                    response.Data = await Logic.OtpLogic.ProcessOtpCreation(model, app);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(Utilities.CatchException(response));
            }
            return Ok(response);
        }


        /// <summary>
        /// Update Otp
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        [Produces(typeof(OtpModel))]
        public IActionResult Update(int id, OtpForm form)
        {
            var response = Utilities.InitializeResponse();
            try
            {
                var app = Logic.AppLogic.Search("", _clientSecret).FirstOrDefault();

                form.Id = id;
                var model = Logic.OtpLogic.Create(form);
                if (id != model.Id)
                    return BadRequest(Utilities.UnsuccessfulResponse(response, "Route Parameter does not match model ID"));
                var found = Logic.OtpLogic.Get(id);
                if (found == null)
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "Otp not found" }));
                var check = Logic.OtpLogic.UpdateExists(model);
                if (check)
                    return BadRequest(SerializeUtility.SerializeJSON(new { Message = "Otp configuration already exists" }));
                var dto = Logic.OtpLogic.Update(found, model,
                    "AppId,AppFeature,PhoneNumber,Email,DialCode,OtpCode,IsUsed,TimeUsed,ExpiryDate,RecordStatus");
                return Ok(dto);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(SerializeUtility.SerializeJSON(new { Message = ex.Message }));
            }
        }

        /// <summary>
        /// Delete Otp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpPost]
        [Produces(typeof(OtpModel))]
        public IActionResult Delete(int id)
        {
            try
            {
                var found = Logic.OtpLogic.Get(id);
                if (found == null)
                    return NotFound(SerializeUtility.SerializeJSON(new { Message = "Otp not found" }));
                Logic.OtpLogic.Delete(found);
                return Ok(found);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(SerializeUtility.SerializeJSON(new { Message = ex.Message }));
            }
        }

        [Route("Use")]
        [HttpPost]
        [Produces(typeof(OtpModel))]
        public IActionResult UseOtp(UseOtpForm otp)
        {
            var response = Utilities.InitializeResponse();
            try
            {
                var appModel = Logic.AppLogic.SearchView("", _clientSecret).Items.FirstOrDefault();
                var app = Logic.AppLogic.Create(appModel);
                var otpExists = Logic.OtpLogic.Search(app.Id, "", "", "", "", otp.OtpCode, false).FirstOrDefault();
                if (otpExists == null)
                    return NotFound(Utilities.UnsuccessfulResponse(response,"Otp not found / Otp has been used"));
                if (app.HasExpiry)
                {
                    if (DateTime.UtcNow > otpExists.ExpiryDate) return BadRequest(Utilities.UnsuccessfulResponse(response, "Otp has expired"));
                }                    
                Logic.OtpLogic.Update(otpExists);
                return Ok(otpExists);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest(Utilities.CatchException(response));
            }
        }
    }
}