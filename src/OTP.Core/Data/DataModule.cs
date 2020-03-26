using OTP.Core.Data.OTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Data
{
    public class DataModule : IDataModule
    {
        public DataModule(OTPContext context)
        {
            _context = context;
        }
        private readonly OTPContext _context;
        private AppRepository _apps;
        public AppRepository Apps { get { if (_apps == null) { _apps = new AppRepository(_context); } return _apps; } }

        private OtpTypeRepository _otptypes;
        public OtpTypeRepository OtpTypes { get { if (_otptypes == null) { _otptypes = new OtpTypeRepository(_context); } return _otptypes; } }

        private OtpRepository _otps;
        public OtpRepository Otps { get { if (_otps == null) { _otps = new OtpRepository(_context); } return _otps; } }

    }
}
