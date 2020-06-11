using OTP.Core.Data.OTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Data
{
    public interface IDataModule
    {
        AppRepository Apps { get; }
        OtpTypeRepository OtpTypes { get; }
        OtpRepository Otps { get; }

    }
}
