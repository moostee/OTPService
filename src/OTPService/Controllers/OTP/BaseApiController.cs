using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTP.Core.Common;

namespace OTP.Service.Controllers.OTP
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void AddHeader(string key, object data)
        {

            HttpContext.Response.Headers.Add(key, SerializeUtility.SerializeJSON(data));
        }
    }
}