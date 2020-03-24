using AutoMapper;
using OTP.Core.Domain.Entity;
using OTP.Core.Domain.Form;
using OTP.Core.Domain.Model;

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
               
            });
        }
    }
}
