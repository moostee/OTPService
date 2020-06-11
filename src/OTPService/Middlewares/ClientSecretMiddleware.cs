using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OTP.Core.Common;
using OTP.Core.Data;
using OTP.Core.Domain.Model.Helper;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OTP.Service.Middlewares
{
    public class ClientSecretMiddleware
    {
        private readonly RequestDelegate _Next;
        public ClientSecretMiddleware(RequestDelegate next)
        {
            _Next = next;
        }

        public async Task Invoke(HttpContext context,IDataModule dataModule)
        {
            if (context.Request.Path.ToUriComponent().Contains("Otps"))
            {
                var _data = dataModule.Apps;
                var response = Utilities.InitializeResponse();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var reqAuthToken = context.Request.Headers["X-ClientSecret"];

                if (string.IsNullOrEmpty(reqAuthToken))
                {
                    await context.Response.WriteAsync(
                        SerializeUtility.SerializeJSON(Utilities.UnsuccessfulResponse(response, "X-ClientSecret header is required")),
                        Encoding.UTF8);
                }
                else
                if (_data.SearchView("",reqAuthToken).Items.FirstOrDefault()?.AppSecret != reqAuthToken)
                {
                    await context.Response.WriteAsync(
                        SerializeUtility.SerializeJSON(Utilities.UnsuccessfulResponse(response, "Invalid access token")),
                        Encoding.UTF8);
                }
                else
                {
                    await _Next(context);
                }
            }
            else
            {
                await _Next(context);
            }
        }
    }
    
}
