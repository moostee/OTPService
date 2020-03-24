using Microsoft.EntityFrameworkCore;

namespace OTP.Core.Data
{
    public class OTPContext : DbContext
    {
        private DbContextOptions<OTPContext> _options;
        public OTPContext(DbContextOptions<OTPContext> options)
        : base(options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_options == null)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=otpdb;Integrated Security=True;");
            }
        }
    }
}
