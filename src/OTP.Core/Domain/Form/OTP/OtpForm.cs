using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
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

    }

    public class UseOtpForm
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int OtpCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
