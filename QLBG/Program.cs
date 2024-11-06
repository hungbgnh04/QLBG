using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace QLBG
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            // Thiết lập DataDirectory để trỏ đến thư mục App_Data trong thư mục gốc của dự án
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string dbFilePath = Path.Combine(projectDirectory, "App_Data", "QLBG.mdf");
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbFilePath};Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

            // Cập nhật connection string trong App.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionSetting = config.ConnectionStrings.ConnectionStrings["DBConnection"];

            if (connectionSetting != null)
            {
                connectionSetting.ConnectionString = connectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            else
            {
                MessageBox.Show("Connection string 'DBConnection' not found in App.config.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QLBG.Views.frmLayout());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
