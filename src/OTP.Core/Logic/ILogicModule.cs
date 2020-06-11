using OTP.Core.Logic.OTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Logic
{
    public interface ILogicModule
    {
        OtpLogic OtpLogic { get; }
        OtpTypeLogic OtpTypeLogic { get; }

        AppLogic AppLogic { get; }
    }
}
