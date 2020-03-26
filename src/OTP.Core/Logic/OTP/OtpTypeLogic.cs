using OTP.Core.Data;
using OTP.Core.Domain;
using OTP.Core.Domain.Entity.OTP;
using OTP.Core.Domain.Form.OTP;
using OTP.Core.Domain.Model;
using OTP.Core.Domain.Model.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTP.Core.Logic.OTP
{
    public partial class OtpTypeLogic : BaseLogic
    {

    }


    /// <summary>
    /// OtpType Logic
    /// </summary>
    public partial class OtpTypeLogic : BaseLogic
    {

        private readonly IDataModule Data;
        private readonly IFactoryModule Factory;

        public OtpTypeLogic(IDataModule data, IFactoryModule factory)
        {
            Data = data;
            Factory = factory;
        }


        /// <summary>
        /// IQueryable OtpType Entity Search
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<OtpType> Search(string name = "")
        {
            return Data.OtpTypes.Search(name);
        }



        /// <summary>
        /// Paged OtpType Model Search
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        ///<param name="pageSize"></param>
        ///<param name="sort"></param>
        /// <returns></returns>
        public Page<OtpTypeModel> SearchEf(string name = "",
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            return Data.OtpTypes.SearchEF(name, page, pageSize, sort);
        }


        /// <summary>
        /// IEnumerable OtpType Model Search
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<OtpTypeModel> SearchModel(string name = "")
        {
            return Data.OtpTypes.Search(name)
                .Select(Factory.OtpTypes.CreateModel);
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
            long page = 1, long pageSize = 10, string sort = "")
        {
            return Data.OtpTypes.SearchView(name, page, pageSize, sort);
        }

        /// <summary>
        /// Create OtpType Model from OtpType Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public OtpTypeModel Create(OtpType entity)
        {
            return Factory.OtpTypes.CreateModel(entity);
        }

        /// <summary>
        /// Create OtpType Model from OtpType Form
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public OtpTypeModel Create(OtpTypeForm form)
        {
            return Factory.OtpTypes.CreateModel(form);
        }

        /// <summary>
        /// Create OtpType Entity from OtpType Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OtpType Create(OtpTypeModel model)
        {
            return Factory.OtpTypes.CreateEntity(model);
        }

        /// <summary>
        /// Check Uniqueness of OtpType before creation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateExists(OtpTypeModel model)
        {
            return Data.OtpTypes.ItemExists(model);
        }

        /// <summary>
        /// Delete OtpType
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(OtpType entity)
        {
            return Data.OtpTypes.DeleteNpoco(entity);
        }

        /// <summary>
        /// Get OtpType Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OtpType Get(int id)
        {
            return Data.OtpTypes.Get(id);
        }

        /// <summary>
        /// Get OtpType Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OtpTypeModel> GetModel(int id)
        {
            return await Data.OtpTypes.GetModel(id);
        }

        /// <summary>
        /// Insert new OtpType to DB
        /// </summary>
        /// <param name="model"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        public async Task<OtpTypeModel> Insert(OtpTypeModel model, bool check = true)
        {
            if (check)
            {
                var routeSearch = Data.OtpTypes.ItemExists(model);
                if (routeSearch)
                {
                    throw new Exception("OtpType Name already exists");
                }
            }
            var entity = Factory.OtpTypes.CreateEntity(model);
            entity.RecordStatus = Core.Domain.Enum.RecordStatus.Active;
            await Data.OtpTypes.Insert(entity);
            return Factory.OtpTypes.CreateModel(entity);
        }

        /// <summary>
        /// Update a OtpType Entity with a OtpType Model with selected fields
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="model"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public OtpType Patch(OtpType entity, OtpTypeModel model, string fields)
        {
            return Factory.OtpTypes.Patch(entity, model, fields);
        }

        /// <summary>
        /// Update OtpType, with Patch Options Optional
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="model"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public OtpTypeModel Update(OtpType entity, OtpTypeModel model = null, string fields = "")
        {
            if (model != null)
            {
                entity = Patch(entity, model, fields);
            }
            return Factory.OtpTypes.CreateModel(Data.OtpTypes.UpdateNpoco(entity));
        }

        /// <summary>
        /// Check Uniqueness of OtpType before update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateExists(OtpTypeModel model)
        {
            return Data.OtpTypes.ItemExists(model, model.Id);
        }

    }
}
