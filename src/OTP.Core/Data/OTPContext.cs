using Microsoft.EntityFrameworkCore;
using OTP.Core.Domain.Entity.OTP;

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

        public OTPContext()
        {

        }

        public DbSet<Otp> Otps { get; set; }

        public DbSet<OtpType> OtpTypes { get; set; }

        public DbSet<App> Apps { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_options == null)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=skarpaotpdb;Integrated Security=True;");
            }
        }
    }
}
