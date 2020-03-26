using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Domain.Form.OTP
{
    /// <summary>
    /// App Form
    /// </summary>
    public class AppForm : BaseForm<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
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
