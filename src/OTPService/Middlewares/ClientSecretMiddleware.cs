using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OTP.Core.Data;
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
            
        }
    }
    
}
