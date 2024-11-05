using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLBG.DAL
{
    public class DatabaseHelper
    {
        private readonly DatabaseManager dbManager;

        public DatabaseHelper()
        {
            dbManager = DatabaseManager.Instance;
        }

        /// <summary>
        /// Checks if the provided email and password match an existing user in the NhanVien table.
        /// </summary>
        public bool CheckLogin(string email, string password)
        {
            string query = "SELECT COUNT(1) FROM NhanVien WHERE Email=@Email AND Password=@Password";
            SqlParameter[] parameters = {
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password)
            };
            object result = dbManager.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) == 1;
        }

        /// <summary>
        /// Checks if an email exists in the NhanVien table.
        /// </summary>
        public bool CheckEmailExist(string email)
        {
            string query = "SELECT COUNT(1) FROM NhanVien WHERE Email=@Email";
            SqlParameter[] parameters = {
                new SqlParameter("@Email", email)
            };
            object result = dbManager.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) == 1;
        }

        /// <summary>
        /// Updates the password for a user in the NhanVien table.
        /// </summary>
        public bool UpdatePassword(string email, string newPassword)
        {
            string query = "UPDATE NhanVien SET Password=@Password WHERE Email=@Email";
            SqlParameter[] parameters = {
        new SqlParameter("@Password", newPassword),
        new SqlParameter("@Email", email)
    };
            int rowsAffected = dbManager.ExecuteNonQuery(query, parameters);
            if (rowsAffected > 0)
            {
                dbManager.ShowSuccessMessage("Mật khẩu đã được cập nhật thành công!");
                return true;
            }
            else
            {
                dbManager.ShowErrorMessage("Cập nhật mật khẩu thất bại.");
                return false;
            }
        }

    }
}