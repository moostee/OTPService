using AutoMapper;
using OTP.Core.Domain.Entity.OTP;
using OTP.Core.Domain.Form.OTP;
using OTP.Core.Domain.Model.OTP;

namespace OTP.Core.Common
{

    /// <summary>
    /// 
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static MapperConfiguration config;
        /// <summary>
        /// Registers the mappings.
        /// </summary>
        public static void RegisterMappings()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OtpType, OtpTypeModel>().ReverseMap();
                cfg.CreateMap<OtpType, OtpTypeForm>().ReverseMap();
                cfg.CreateMap<OtpTypeModel, OtpTypeForm>().ReverseMap();

                cfg.CreateMap<Otp, OtpModel>().ReverseMap();
                cfg.CreateMap<Otp, OtpForm>().ReverseMap();
                cfg.CreateMap<OtpModel, OtpForm>().ReverseMap();

                cfg.CreateMap<App, AppModel>().ReverseMap();
                cfg.CreateMap<App, AppForm>().ReverseMap();
                cfg.CreateMap<AppModel, AppForm>().ReverseMap();
            });
        }
    }
}
