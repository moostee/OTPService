using OTP.Core.Domain.Factory.OTP;

namespace OTP.Core.Domain
{
    public class FactoryModule : IFactoryModule
    {

        private OtpFactory _otp;

        /// <summary>
        /// Otp Factory Module
        /// </summary>
        public OtpFactory Otps { get { if (_otp == null) { _otp = new OtpFactory(); } return _otp; } }

        private OtpTypeFactory _otptype;

        /// <summary>
        /// OtpType Factory Module
        /// </summary>
        public OtpTypeFactory OtpTypes { get { if (_otptype == null) { _otptype = new OtpTypeFactory(); } return _otptype; } }

        private AppFactory _app;

        /// <summary>
        /// App Factory Module
        /// </summary>
        public AppFactory Apps { get { if (_app == null) { _app = new AppFactory(); } return _app; } }


    }
}
