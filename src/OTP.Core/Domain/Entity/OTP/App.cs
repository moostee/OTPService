using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Domain.Entity.OTP
{
    /// <summary>
    /// App Class
    /// </summary>
    /// <summary>
    /// App Class
    /// </summary>
    public class App : BaseEntity<int>
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
