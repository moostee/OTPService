using OTP.Core.Domain.Entity.OTP;
using OTP.Core.Domain.Model;
using OTP.Core.Domain.Model.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTP.Core.Data.OTP
{
    public class OtpTypeRepository : BaseRepository<OtpType, OtpTypeModel, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public OtpTypeRepository(OTPContext context) : base(context)
        {
        }
        /// <summary>
        /// IQueryable OtpType Entity Search
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<OtpType> Search(string name = "")
        {
            var table = Query();
            if (!string.IsNullOrEmpty(name))
            {
                table = table.Where(x => x.Name == name);
            }

            return table;
        }

        /// <summary>
        /// Paged OtpType Model Search
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        ///<param name="pageSize"></param>
        ///<param name="sort"></param>
        /// <returns></returns>
        public Page<OtpTypeModel> SearchEF(string name = "",
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            var table = QueryModel();

            if (!string.IsNullOrEmpty(name))
            {
                table = table.Where(x => x.Name == name);
            }


            return Paged(table, pageSize, page, sort);

        }

        /// <summary>
        /// Paged OtpType Model Search
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        ///<param name="pageSize"></param>
        ///<param name="sort"></param>
        /// <returns></returns>
        public Page<OtpTypeModel> SearchView(string name = "",
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
        public bool ItemExists(OtpTypeModel model, int? Id = null)
        {
            var search = SearchView(model.Name);
            var check = search.Items.AsEnumerable();
            if (Id != null)
            {
                check = check.Where(x => x.Id != Id);
            }
            return check.Any();
        }
    }
}
