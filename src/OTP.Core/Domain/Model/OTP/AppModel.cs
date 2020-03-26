using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Domain.Model.OTP
{
    /// <summary>
    /// App View Model
    /// </summary> 
    public class AppModel : BaseModel<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OtpTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OtpLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool HasExpiry { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan ExpiryPeriod { get; set; }

    }
}
