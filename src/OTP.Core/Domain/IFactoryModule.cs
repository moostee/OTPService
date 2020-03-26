using OTP.Core.Domain.Factory.OTP;

namespace OTP.Core.Domain
{
    public interface IFactoryModule
    {
        AppFactory Apps { get; }
        OtpFactory Otps { get; }
        OtpTypeFactory OtpTypes { get; }
    }
}
