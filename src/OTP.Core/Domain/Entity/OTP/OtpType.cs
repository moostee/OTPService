using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Domain.Entity.OTP
{
    public class OtpType : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

    }
}
