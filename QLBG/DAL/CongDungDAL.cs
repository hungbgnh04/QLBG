using QLBG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class CongDungDAL
    {
        public List<CongDungDTO> GetAllCongDung()
        {
            List<CongDungDTO> congDungList = new List<CongDungDTO>();
            string query = "SELECT MaCongDung, TenCongDung FROM CongDung";

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                CongDungDTO congDung = new CongDungDTO
                {
                    MaCongDung = (int)row["MaCongDung"],
                    TenCongDung = row["TenCongDung"].ToString()
                };
                congDungList.Add(congDung);
            }

            return congDungList;
        }
    }
}
