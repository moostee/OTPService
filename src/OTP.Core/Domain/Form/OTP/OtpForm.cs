using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Domain.Form.OTP
{
    /// <summary>
    /// Otp Form
    /// </summary>
    public class OtpForm : BaseForm<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public int AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AppFeature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DialCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OtpCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TimeUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpiryDate { get; set; }

    }
}
