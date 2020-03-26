using OTP.Core.Domain.Entity.OTP;
using OTP.Core.Domain.Model;
using OTP.Core.Domain.Model.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTP.Core.Data.OTP
{
    public class OtpRepository : BaseRepository<Otp, OtpModel, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public OtpRepository(OTPContext context) : base(context)
        {
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
            var table = Query();
            if (appId > 0)
            {
                table = table.Where(x => x.AppId == appId);
            }
            if (!string.IsNullOrEmpty(appFeature))
            {
                table = table.Where(x => x.AppFeature == appFeature);
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                table = table.Where(x => x.PhoneNumber == phoneNumber);
            }
            if (!string.IsNullOrEmpty(email))
            {
                table = table.Where(x => x.Email == email);
            }
            if (!string.IsNullOrEmpty(dialCode))
            {
                table = table.Where(x => x.DialCode == dialCode);
            }
            if (otpCode > 0)
            {
                table = table.Where(x => x.OtpCode == otpCode);
            }
            if (isUsed.HasValue)
            {
                var isUsedVal = isUsed.GetValueOrDefault();
                table = table.Where(x => x.IsUsed == isUsedVal);
            }
            if (timeUsed.HasValue)
            {
                var timeUsedVal = timeUsed.GetValueOrDefault();
                table = table.Where(x => x.TimeUsed == timeUsedVal);
            }
            if (expiryDate.HasValue)
            {
                var expiryDateVal = expiryDate.GetValueOrDefault();
                table = table.Where(x => x.ExpiryDate == expiryDateVal);
            }

            return table;
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
        public Page<OtpModel> SearchEF(int appId = 0, string appFeature = "", string phoneNumber = "", string email = "", string dialCode = "", int otpCode = 0, bool? isUsed = null, DateTime? timeUsed = null, DateTime? expiryDate = null,
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            var table = QueryModel();

            if (appId > 0)
            {
                table = table.Where(x => x.AppId == appId);
            }
            if (!string.IsNullOrEmpty(appFeature))
            {
                table = table.Where(x => x.AppFeature == appFeature);
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                table = table.Where(x => x.PhoneNumber == phoneNumber);
            }
            if (!string.IsNullOrEmpty(email))
            {
                table = table.Where(x => x.Email == email);
            }
            if (!string.IsNullOrEmpty(dialCode))
            {
                table = table.Where(x => x.DialCode == dialCode);
            }
            if (otpCode > 0)
            {
                table = table.Where(x => x.OtpCode == otpCode);
            }
            if (isUsed.HasValue)
            {
                var isUsedVal = isUsed.GetValueOrDefault();
                table = table.Where(x => x.IsUsed == isUsedVal);
            }
            if (timeUsed.HasValue)
            {
                var timeUsedVal = timeUsed.GetValueOrDefault();
                table = table.Where(x => x.TimeUsed == timeUsedVal);
            }
            if (expiryDate.HasValue)
            {
                var expiryDateVal = expiryDate.GetValueOrDefault();
                table = table.Where(x => x.ExpiryDate == expiryDateVal);
            }


            return Paged(table, pageSize, page, sort);

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
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            var sql = " where Id > 0 ";
            var c = 0;

            if (appId > 0)
            {
                sql += $" and AppId = @{c} ";
                AddParam("appId", appId);
                c++;
            }
            if (!string.IsNullOrEmpty(appFeature))
            {
                sql += $" and AppFeature = @{c} ";
                AddParam("appFeature", appFeature);
                c++;
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                sql += $" and PhoneNumber = @{c} ";
                AddParam("phoneNumber", phoneNumber);
                c++;
            }
            if (!string.IsNullOrEmpty(email))
            {
                sql += $" and Email = @{c} ";
                AddParam("email", email);
                c++;
            }
            if (!string.IsNullOrEmpty(dialCode))
            {
                sql += $" and DialCode = @{c} ";
                AddParam("dialCode", dialCode);
                c++;
            }
            if (otpCode > 0)
            {
                sql += $" and OtpCode = @{c} ";
                AddParam("otpCode", otpCode);
                c++;
            }
            if (isUsed.HasValue)
            {
                var isUsedVal = isUsed.GetValueOrDefault();
                sql += $" and IsUsed = @{c} ";
                AddParam("isUsed", isUsedVal);
                c++;
            }
            if (timeUsed.HasValue)
            {
                var timeUsedVal = timeUsed.GetValueOrDefault();
                sql += $" and TimeUsed = @{c} ";
                AddParam("timeUsed", timeUsedVal);
                c++;
            }
            if (expiryDate.HasValue)
            {
                var expiryDateVal = expiryDate.GetValueOrDefault();
                sql += $" and ExpiryDate = @{c} ";
                AddParam("expiryDate", expiryDateVal);
                c++;
            }



            sql += ApplySort(sort);
            if (page <= 0) return QueryView(sql);

            return PagedView(sql, page, pageSize);
        }



        /// <summary>
        /// check exists
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool ItemExists(OtpModel model, int? Id = null)
        {
            var search = SearchView(model.AppId, model.AppFeature, model.PhoneNumber, model.Email, model.DialCode, model.OtpCode, model.IsUsed, model.TimeUsed, model.ExpiryDate);
            var check = search.Items.AsEnumerable();
            if (Id != null)
            {
                check = check.Where(x => x.Id != Id);
            }
            return check.Any();
        }
    }
}
