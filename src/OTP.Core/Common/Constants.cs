using System;

namespace SkarpaUMS_Core.Common
{
    public static class Constants
    {
        public static string DB_CONN => Settings.Get("dbconn");
        public static string NOTIFICATION_SERVICE_URL => Settings.Get("notificationserviceurl");
    }
}
