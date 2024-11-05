using System;
using System.IO;

namespace QLBG.Helpers
{
    public static class App_Default
    {
        public static string SenderEmail { get; } = "realer190904@gmail.com";
        public static string SenderPassword { get; } = "ijfaldgglybtrkgh";
        public static string SmtpHost { get; } = "smtp.gmail.com";
        public static int SmtpPort { get; } = 587;

        // Sử dụng Path.Combine và AppDomain.CurrentDomain.BaseDirectory để đảm bảo đường dẫn chính xác
        public static string DefaultConnectionString { get; } =
            $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "QLBG.mdf")};Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

        public static bool ValidateEmailConfig()
        {
            return !string.IsNullOrEmpty(SenderEmail) &&
                   !string.IsNullOrEmpty(SenderPassword) &&
                   !string.IsNullOrEmpty(SmtpHost) &&
                   SmtpPort > 0;
        }
    }
}
