using NPoco;
using NPoco.FluentMappings;
using OTP.Core.Domain.Entity.OTP;
using OTP.Core.Domain.Model.OTP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OTP.Core.Data
{
    public static class OTPPoco
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
            For<App>()
            .PrimaryKey(x => x.Id)
            .TableName("Apps");

            For<AppModel>().PrimaryKey(x => x.Id)
            .TableName("appmodel")
            .Columns(x =>
            {
                x.Column(y => y.RecordStatusText).Ignore();
                x.Column(y => y.CreatedAtText).Ignore();
                x.Column(y => y.UpdatedAtText).Ignore();
            });

            For<Otp>()
            .PrimaryKey(x => x.Id)
            .TableName("Otps");

            For<OtpModel>().PrimaryKey(x => x.Id)
            .TableName("otpmodel")
            .Columns(x =>
            {
                x.Column(y => y.RecordStatusText).Ignore();
                x.Column(y => y.CreatedAtText).Ignore();
                x.Column(y => y.UpdatedAtText).Ignore();
                x.Column(y => y.EmailSubject).Ignore();
                x.Column(y => y.Body).Ignore();
                x.Column(y => y.Firstname).Ignore();
                x.Column(y => y.EmailTemplate).Ignore();
            });


            For<OtpType>()
            .PrimaryKey(x => x.Id)
            .TableName("OtpTypes");

            For<OtpTypeModel>().PrimaryKey(x => x.Id)
            .TableName("otptypemodel")
            .Columns(x =>
            {
                x.Column(y => y.RecordStatusText).Ignore();
                x.Column(y => y.CreatedAtText).Ignore();
                x.Column(y => y.UpdatedAtText).Ignore();
            });
        }
    }
}
