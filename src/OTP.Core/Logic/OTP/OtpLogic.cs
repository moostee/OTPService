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
        public async Task<OtpModel> Insert(OtpModel model, bool check = true)
        {
            if (check)
            {
                var routeSearch = Data.Otps.ItemExists(model);
                if (routeSearch)
                {
                    throw new Exception("Otp Name already exists");
                }
            }
            var entity = Factory.Otps.CreateEntity(model);
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

        /// <summary>
        /// Update Otp, with Patch Options Optional
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="model"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public OtpModel Update(Otp entity, OtpModel model = null, string fields = "")
        {
            if (model != null)
            {
                entity = Patch(entity, model, fields);
            }
            return Factory.Otps.CreateModel(Data.Otps.UpdateNpoco(entity));
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

    }
}
