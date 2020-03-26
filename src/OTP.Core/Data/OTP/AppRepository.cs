using OTP.Core.Domain.Entity.OTP;
using OTP.Core.Domain.Model;
using OTP.Core.Domain.Model.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTP.Core.Data.OTP
{
    public class AppRepository : BaseRepository<App, AppModel, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AppRepository(OTPContext context) : base(context)
        {
        }
        /// <summary>
        /// IQueryable App Entity Search
        /// </summary>
        /// <param name="name"></param>
        /// <param name="appSecret"></param>
        /// <param name="otpTypeId"></param>
        /// <param name="otpLength"></param>
        /// <param name="hasExpiry"></param>
        /// <param name="expiryPeriod"></param>
        /// <returns></returns>
        public IQueryable<App> Search(string name = "", string appSecret = "", int otpTypeId = 0, int otpLength = 0, bool? hasExpiry = null, TimeSpan? expiryPeriod = null)
        {
            var table = Query();
            if (!string.IsNullOrEmpty(name))
            {
                table = table.Where(x => x.Name == name);
            }
            if (!string.IsNullOrEmpty(appSecret))
            {
                table = table.Where(x => x.AppSecret == appSecret);
            }
            if (otpTypeId > 0)
            {
                table = table.Where(x => x.OtpTypeId == otpTypeId);
            }
            if (otpLength > 0)
            {
                table = table.Where(x => x.OtpLength == otpLength);
            }
            if (hasExpiry.HasValue)
            {
                var hasExpiryVal = hasExpiry.GetValueOrDefault();
                table = table.Where(x => x.HasExpiry == hasExpiryVal);
            }
            if (expiryPeriod.HasValue)
            {
                var expiryPeriodVal = expiryPeriod.GetValueOrDefault();
                table = table.Where(x => x.ExpiryPeriod == expiryPeriodVal);
            }

            return table;
        }

        /// <summary>
        /// Paged App Model Search
        /// </summary>
        /// <param name="name"></param>
        /// <param name="appSecret"></param>
        /// <param name="otpTypeId"></param>
        /// <param name="otpLength"></param>
        /// <param name="hasExpiry"></param>
        /// <param name="expiryPeriod"></param>
        /// <param name="page"></param>
        ///<param name="pageSize"></param>
        ///<param name="sort"></param>
        /// <returns></returns>
        public Page<AppModel> SearchEF(string name = "", string appSecret = "", int otpTypeId = 0, int otpLength = 0, bool? hasExpiry = null, TimeSpan? expiryPeriod = null,
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            var table = QueryModel();

            if (!string.IsNullOrEmpty(name))
            {
                table = table.Where(x => x.Name == name);
            }
            if (!string.IsNullOrEmpty(appSecret))
            {
                table = table.Where(x => x.AppSecret == appSecret);
            }
            if (otpTypeId > 0)
            {
                table = table.Where(x => x.OtpTypeId == otpTypeId);
            }
            if (otpLength > 0)
            {
                table = table.Where(x => x.OtpLength == otpLength);
            }
            if (hasExpiry.HasValue)
            {
                var hasExpiryVal = hasExpiry.GetValueOrDefault();
                table = table.Where(x => x.HasExpiry == hasExpiryVal);
            }
            if (expiryPeriod.HasValue)
            {
                var expiryPeriodVal = expiryPeriod.GetValueOrDefault();
                table = table.Where(x => x.ExpiryPeriod == expiryPeriodVal);
            }

            return Paged(table, pageSize, page, sort);

        }

        /// <summary>
        /// Paged App Model Search
        /// </summary>
        /// <param name="name"></param>
        /// <param name="appSecret"></param>
        /// <param name="otpTypeId"></param>
        /// <param name="otpLength"></param>
        /// <param name="hasExpiry"></param>
        /// <param name="expiryPeriod"></param>
        /// <param name="page"></param>
        ///<param name="pageSize"></param>
        ///<param name="sort"></param>
        /// <returns></returns>
        public Page<AppModel> SearchView(string name = "", string appSecret = "", int otpTypeId = 0, int otpLength = 0, bool? hasExpiry = null, TimeSpan? expiryPeriod = null,
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            var sql = " where Id > 0 ";
            var c = 0;

            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and Name = @{c} ";
                AddParam("name", name);
                c++;
            }
            if (!string.IsNullOrEmpty(appSecret))
            {
                sql += $" and AppSecret = @{c} ";
                AddParam("appSecret", appSecret);
                c++;
            }
            if (otpTypeId > 0)
            {
                sql += $" and OtpTypeId = @{c} ";
                AddParam("otpTypeId", otpTypeId);
                c++;
            }
            if (otpLength > 0)
            {
                sql += $" and OtpLength = @{c} ";
                AddParam("otpLength", otpLength);
                c++;
            }
            if (hasExpiry.HasValue)
            {
                var hasExpiryVal = hasExpiry.GetValueOrDefault();
                sql += $" and HasExpiry = @{c} ";
                AddParam("hasExpiry", hasExpiryVal);
                c++;
            }
            if (expiryPeriod.HasValue)
            {
                var expiryPeriodVal = expiryPeriod.GetValueOrDefault();
                sql += $" and ExpiryPeriod = @{c} ";
                AddParam("expiryPeriod", expiryPeriodVal);
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
        public bool ItemExists(AppModel model, int? Id = null)
        {
            var search = SearchView(model.Name, model.AppSecret, model.OtpTypeId, model.OtpLength, model.HasExpiry, model.ExpiryPeriod);
            var check = search.Items.AsEnumerable();
            if (Id != null)
            {
                check = check.Where(x => x.Id != Id);
            }
            return check.Any();
        }
    }
}
