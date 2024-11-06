using QLBG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class HinhDangDAL
    {
        public List<HinhDangDTO> GetAllHinhDang()
        {
            List<HinhDangDTO> hinhDangList = new List<HinhDangDTO>();
            string query = "SELECT MaHinhDang, TenHinhDang FROM HinhDang";

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                HinhDangDTO hinhDang = new HinhDangDTO
                {
                    MaHinhDang = (int)row["MaHinhDang"],
                    TenHinhDang = row["TenHinhDang"].ToString()
                };
                hinhDangList.Add(hinhDang);
            }
            return hinhDangList;
        }

    }
}
