using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Domain.Model.OTP
{
    /// <summary>
    /// OtpType View Model
    /// </summary> 
    public class OtpTypeModel : BaseModel<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

    }
}
