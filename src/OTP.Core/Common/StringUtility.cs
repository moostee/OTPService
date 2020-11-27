using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace OTP.Core.Common
{
    public static class StringUtility
    {
        public static string GetDomain(string email)
        {
            try
            {
                MailAddress address = new MailAddress(email);
                return address.Host;
            }
            catch (Exception ex)
            {
                throw new Exception("Extract domain from email failed", ex);
            }
        }

        public static string GenerateRandomOTP(int iOTPLength=4)

        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }
        public static string CleanPhone(string phone)
        {
            if (phone != null && phone[0].ToString() == "+")
                return phone.Replace("+", "").Trim();
            return phone;

        }

        public static bool IsValidDialCode(string mobileNumber)
        {
            var validPrefixes = new string[] { "234" };
            if (!validPrefixes.Contains(mobileNumber.Substring(0, 3))) return false;
            return true;
        }

        public static string AppendCodeSign(string phone)
        {
            if (phone != null && phone[0].ToString() != "+")
                return "+" + phone;
            return phone;
        }


        public static string ValidMobile(string mobileNumber)
        {
            var err = new List<string>();
            mobileNumber = AppendCodeSign(mobileNumber);
            mobileNumber = CleanPhone(mobileNumber);
            if (!IsValidDialCode(mobileNumber))
                err.Add("Mobile number has an invalid prefix. please add the dialcode as prefix to the mobile number");
            if (!IsMobile(mobileNumber))
                err.Add("Invalid mobile length or Invalid mobile number format; e.g +2348169325634");
            if (err?.Count > 0)
                return string.Join(",", err.ToArray());
            return string.Empty;
        }
        public static bool IsMobile(string mobile, string countryCode = "ng")
        {
            var isOk = true;
            mobile = CleanPhone(mobile);
            switch (countryCode.ToLower())
            {
                case "ng":
                    if (mobile.Length != 13)
                    {
                        isOk = false;
                    }
                    if (!mobile.StartsWith("234"))
                    {
                        isOk = false;
                    }
                    break;
                default:
                    isOk = false;
                    break;
            }
            return isOk;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static bool IsEmail(string emailAddress)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                 + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                 + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                 + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                 + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);
            bool isStrictMatch = reStrict.IsMatch(emailAddress);
            return isStrictMatch;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public static bool IsPIN(string pin)
        {
            string patternStrict = @"^(?!(.)\1{3})(?!19|20)(?!0123|1234|2345|3456|4567|5678|6789|7890|0987|9876|8765|7654|6543|5432|4321|3210)\d{4}$";
            Regex reStrict = new Regex(patternStrict);
            bool isStrictMatch = reStrict.IsMatch(pin);
            return isStrictMatch;
        }

        public static string GenerateAPISecret()
        {
            RandomNumberGenerator cryptoRandomDataGenerator = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[32];
            cryptoRandomDataGenerator.GetBytes(buffer);
            string uniq = Convert.ToBase64String(buffer);
            return uniq;
        }

        public static object ToStringQuery(string seeds, string dataType = "string")
        {
            seeds = seeds.Replace(" ", "").Trim();
            seeds = seeds.Replace("'", "").Trim();
            seeds = seeds.Replace("\"", "").Trim();
            char[] sep = { ',' };
            var bits = seeds.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            var ls = new List<string>();
            if (dataType == "string")
            {
                foreach (var k in bits)
                {
                    ls.Add("'" + k + "'");
                }
            }

            if (dataType == "number")
            {
                foreach (var k in bits)
                {
                    ls.Add(CastUtility.ToInt32(k).ToString());
                }
            }

            return string.Join(",", ls.ToArray());
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


    }

    public static class HttpRequestExtension
    {
        public static string GetHeader(this HttpRequest request, string key)
        {
            return request.Headers.FirstOrDefault(x => x.Key == key).Value.FirstOrDefault();
        }
    }






}
