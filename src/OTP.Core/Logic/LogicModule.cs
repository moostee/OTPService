using OTP.Core.Data;
using OTP.Core.Domain;
using OTP.Core.Logic.OTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Logic
{
    public class LogicModule : ILogicModule
    {
        private IDataModule _data;
        private IFactoryModule _factory;
        public LogicModule(IDataModule data, IFactoryModule factory)
        {
            _data = data;
            _factory = factory;
        }
        private OtpLogic _otp;

        /// <summary>
        /// Otp Logic Module
        /// </summary>
        public OtpLogic OtpLogic { get { if (_otp == null) { _otp = new OtpLogic(_data, _factory); } return _otp; } }

        private OtpTypeLogic _otptype;

        /// <summary>
        /// OtpType Logic Module
        /// </summary>
        public OtpTypeLogic OtpTypeLogic { get { if (_otptype == null) { _otptype = new OtpTypeLogic(_data, _factory); } return _otptype; } }

        private AppLogic _app;

        /// <summary>
        /// App Logic Module
        /// </summary>
        public AppLogic AppLogic { get { if (_app == null) { _app = new AppLogic(_data, _factory); } return _app; } }


    }
}
