using NLog;
using System;

namespace OTP.Core.Common
{
    public static class Log
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static void Error(Exception ex)
        {
            logger.Error(ex, ex.Message);
        }
        public static void Info(string message)
        {
            logger.Info(message);
        }
    }
}
