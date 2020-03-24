using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Common
{
    public class SerializeUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInstance"></param>
        /// <returns></returns>
        public static string SerializeJSON(object objectInstance)
        {
            return JsonConvert.SerializeObject(objectInstance);
        }
    }
}
