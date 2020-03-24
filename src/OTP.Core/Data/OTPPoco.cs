using NPoco;
using NPoco.FluentMappings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OTP.Core.Data
{
    public static class UMSPoco
    {
        /// <summary>
        /// 
        /// </summary>
        public static DatabaseFactory DbFactory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static void Setup(string config)
        {
            //NpgsqlConnection connection = new NpgsqlConnection(config);
            var fluentConfig = FluentMappingConfiguration.Configure(new OTPSolutionMappings());
            DbFactory = DatabaseFactory.Config(x =>
            {
                x.UsingDatabase(() => new NPoco.Database(config, DatabaseType.SqlServer2012, SqlClientFactory.Instance));
                x.WithFluentConfig(fluentConfig);
            });
        }
    }

    public class OTPSolutionMappings : Mappings
    {
        public OTPSolutionMappings()
        {
          
        }
    }
}
