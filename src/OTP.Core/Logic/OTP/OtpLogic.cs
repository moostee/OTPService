using Newtonsoft.Json;
using OTP.Core.Common;
using OTP.Core.Data;
using OTP.Core.Domain;
using OTP.Core.Domain.Entity.OTP;
using OTP.Core.Domain.Enum;
using OTP.Core.Domain.Form.OTP;
using OTP.Core.Domain.Model;
using OTP.Core.Domain.Model.Helper;
using OTP.Core.Domain.Model.OTP;
using RestSharp;
using SkarpaUMS_Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OTP.Core.Logic.OTP
{
    public partial class OtpLogic : BaseLogic
    {

    }


    /// <summary>
    /// Otp Logic
    /// </summary>
    public partial class OtpLogic : BaseLogic
    {

        private readonly IDataModule Data;
        private readonly IFactoryModule Factory;

        public OtpLogic(IDataModule data, IFactoryModule factory)
        {
            Data = data;
            Factory = factory;
        }


        /// <summary>
        /// IQueryable Otp Entity Search
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appFeature"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="dialCode"></param>
        /// <param name="otpCode"></param>
        /// <param name="isUsed"></param>
        /// <param name="timeUsed"></param>
        /// <param name="expiryDate"></param>
        /// <returns></returns>
        public IQueryable<Otp> Search(int appId = 0, string appFeature = "", string phoneNumber = "", string email = "", string dialCode = "", int otpCode = 0, bool? isUsed = null, DateTime? timeUsed = null, DateTime? expiryDate = null)
        {
            return Data.Otps.Search(appId, appFeature, phoneNumber, email, dialCode, otpCode, isUsed, timeUsed, expiryDate);
        }



        /// <summary>
        /// Paged Otp Model Search
        /// </summary>
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
        ///<param name="pageSize"></param>
        ///<param name="sort"></param>
        /// <returns></returns>
        public Page<OtpModel> SearchEf(int appId = 0, string appFeature = "", string phoneNumber = "", string email = "", string dialCode = "", int otpCode = 0, bool? isUsed = null, DateTime? timeUsed = null, DateTime? expiryDate = null,
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            return Data.Otps.SearchEF(appId, appFeature, phoneNumber, email, dialCode, otpCode, isUsed, timeUsed, expiryDate, page, pageSize, sort);
        }


        /// <summary>
        /// IEnumerable Otp Model Search
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appFeature"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="dialCode"></param>
        /// <param name="otpCode"></param>
        /// <param name="isUsed"></param>
        /// <param name="timeUsed"></param>
        /// <param name="expiryDate"></param>
        /// <returns></returns>
        public IEnumerable<OtpModel> SearchModel(int appId = 0, string appFeature = "", string phoneNumber = "", string email = "", string dialCode = "", int otpCode = 0, bool? isUsed = null, DateTime? timeUsed = null, DateTime? expiryDate = null)
        {
            return Data.Otps.Search(appId, appFeature, phoneNumber, email, dialCode, otpCode, isUsed, timeUsed, expiryDate)
                .Select(Factory.Otps.CreateModel);
        }

        /// <summary>
        /// Paged Otp Model Search
        /// </summary>
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
        ///<param name="pageSize"></param>
        ///<param name="sort"></param>
        /// <returns></returns>
        public Page<OtpModel> SearchView(int appId = 0, string appFeature = "", string phoneNumber = "", string email = "", string dialCode = "", int otpCode = 0, bool? isUsed = null, DateTime? timeUsed = null, DateTime? expiryDate = null,
            long page = 1, long pageSize = 10, string sort = "")
        {
            return Data.Otps.SearchView(appId, appFeature, phoneNumber, email, dialCode, otpCode, isUsed, timeUsed, expiryDate, page, pageSize, sort);
        }

        /// <summary>
        /// Create Otp Model from Otp Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public OtpModel Create(Otp entity)
        {
            return Factory.Otps.CreateModel(entity);
        }

        /// <summary>
        /// Create Otp Model from Otp Form
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public OtpModel Create(OtpForm form)
        {
            return Factory.Otps.CreateModel(form);
        }

        /// <summary>
        /// Create Otp Entity from Otp Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Otp Create(OtpModel model)
        {
            return Factory.Otps.CreateEntity(model);
        }

        /// <summary>
        /// Check Uniqueness of Otp before creation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateExists(OtpModel model)
        {
            return Data.Otps.ItemExists(model);
        }

        /// <summary>
        /// Delete Otp
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(Otp entity)
        {
            return Data.Otps.DeleteNpoco(entity);
        }

        /// <summary>
        /// Get Otp Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Otp Get(int id)
        {
            return Data.Otps.Get(id);
        }

        /// <summary>
        /// Get Otp Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OtpModel> GetModel(int id)
        {
            return await Data.Otps.GetModel(id);
        }

        /// <summary>
        /// Insert new Otp to DB
        /// </summary>
        /// <param name="model"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        public async Task<OtpModel> Insert(OtpModel model, App app)
        {
            var entity = Factory.Otps.CreateEntity(model);
            if (app.HasExpiry)
            {
                entity.ExpiryDate = DateTime.UtcNow.Add(app.ExpiryPeriod);
            }
            entity.AppId = app.Id;
            entity.OtpCode = Convert.ToInt32(StringUtility.GenerateRandomOTP(app.OtpLength));
            entity.RecordStatus = Core.Domain.Enum.RecordStatus.Active;
            await Data.Otps.Insert(entity);
            return Factory.Otps.CreateModel(entity);
        }

        /// <summary>
        /// Update a Otp Entity with a Otp Model with selected fields
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="model"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public Otp Patch(Otp entity, OtpModel model, string fields)
        {
            return Factory.Otps.Patch(entity, model, fields);
        }

        public async Task<OtpModel> ProcessOtpCreation(OtpModel otpModel, App app)
        {
            var model = await Insert(otpModel, app);
            model.EmailSubject = otpModel.EmailSubject == null ? "Skarpa" : otpModel.EmailSubject;
            model.Body = otpModel.Body;
            model.EmailTemplate = otpModel.EmailTemplate;
            model.Firstname = otpModel.Firstname;
            HasSentOtpBasedOnOtpType(model, app);
            return model;
        }

        /// <summary>
        /// Update Otp, with Patch Options Optional
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="model"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public OtpModel Update(Otp entity,OtpModel model = null, string fields = "")
        {
            if (model != null)
            {
                entity = Patch(entity, model, fields);
            }
            entity.IsUsed = true;
            entity.TimeUsed = DateTime.UtcNow;
            return Factory.Otps.CreateModel(Data.Otps.Update(entity));
        }

        /// <summary>
        /// Check Uniqueness of Otp before update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateExists(OtpModel model)
        {
            return Data.Otps.ItemExists(model, model.Id);
        }


        public (bool hasError, string errorMessage) ValidateAppOtpType(string email, string phone, int otpTypeId)
        {
            bool hasError = false;
            string errorMessage = string.Empty;
            switch ((OtpTypes)otpTypeId)
            {
                case OtpTypes.Email:
                    if (string.IsNullOrWhiteSpace(email)) return (true, "Email Address cannot be empty for your Otp type");
                    if (!StringUtility.IsEmail(email)) return (true, "Email Address not in the right format");
                    break;
                case OtpTypes.PhoneNumber:
                    if (string.IsNullOrWhiteSpace(phone))
                    {
                        hasError = true;
                        errorMessage = "Mobile cannot be empty for your Otp type";
                    }
                    break;
                case OtpTypes.PhoneNumber_Email:
                    if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phone)) return (true, "Email Address And Phone Number cannot be empty for your Otp type");
                    if (!string.IsNullOrWhiteSpace(email) && !StringUtility.IsEmail(email)) return (true, "Email Address not in the right format");
                    break;
                default:
                    hasError = true;
                    errorMessage = "Otp type invalid";
                    break;

            }
            return (hasError, errorMessage);
        }

        public void SendEmail(string email, string emailSubject,string html ,object payload) {
            //var text = hasExpiry ? $"Here is your token {otp}. It expires {DateTime.UtcNow.AddMinutes(period.TotalMinutes).ToString("dd-MMM-yy HH:mm")}." +
            //    $"{Environment.NewLine}{body}." : $"Here is your  token {otp}.{Environment.NewLine}{body}.";
            //var request = new { text, receiver = email, subject = emailSubject };
            var request = new {html,payload, receiver = email, subject = emailSubject };
            Log.Info(JsonConvert.SerializeObject(request));
            var thread = new Thread(async() => {
                var r = await Utilities.MakeApiRequest(Method.POST, $"{Constants.NOTIFICATION_SERVICE_URL}v1/sendmail", JsonConvert.SerializeObject(request));
                Log.Info(r.Content);
            });
            thread.Start();            
        }

        public void SendSms(string phone, int otp, bool hasExpiry, TimeSpan period, string body) {
            var text = hasExpiry ? $"Here is your  token {otp}.It expires {DateTime.UtcNow.AddMinutes(period.TotalMinutes).ToString("dd-MMM-yy HH:mm")}." +
                $"{Environment.NewLine}{body}." : $"Here is your token {otp}.{Environment.NewLine}{body}.";
            var request = new { message = text , receiver = phone };
            var thread = new Thread(async () => {
                var r = await Utilities.MakeApiRequest(Method.POST, $"{Constants.NOTIFICATION_SERVICE_URL}v1/sms", JsonConvert.SerializeObject(request));
                Log.Info(r.Content);
            });
            thread.Start();
        }

        public bool HasSentOtpBasedOnOtpType(OtpModel otp,App app)
        {
            bool status = true;
            var payload = new
            {
                firstname = otp.Firstname,
                code = otp.OtpCode,
                hasExpiry = app.HasExpiry,
                expiryPeriod = DateTime.UtcNow.AddMinutes(app.ExpiryPeriod.TotalMinutes).ToString("dd-MMM-yy HH:mm")
            };
            switch ((OtpTypes)app.OtpTypeId)
            {
                case OtpTypes.Email:
                    SendEmail(otp.Email, otp.EmailSubject, otp.EmailTemplate, payload);
                    break;
                case OtpTypes.PhoneNumber:
                    SendSms(otp.PhoneNumber, otp.OtpCode, app.HasExpiry, app.ExpiryPeriod, otp.Body);
                    break;
                case OtpTypes.PhoneNumber_Email:
                    if(otp.Email != null)
                    {
                        SendEmail(otp.Email, otp.EmailSubject, otp.EmailTemplate, payload);
                    }                        
                    if (otp.PhoneNumber != null)
                    {
                        SendSms(otp.PhoneNumber, otp.OtpCode, app.HasExpiry, app.ExpiryPeriod, otp.Body);
                    }                       

                    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }

    }
}
