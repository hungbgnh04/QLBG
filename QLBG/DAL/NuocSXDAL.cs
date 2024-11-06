using QLBG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class NuocSXDAL
    {
        public List<NuocSXDTO> GetAllNuocSX()
        {
            List<NuocSXDTO> nuocSXList = new List<NuocSXDTO>();
            string query = "SELECT MaNuocSX, TenNuocSX FROM NuocSX";

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                NuocSXDTO nuocSX = new NuocSXDTO
                {
                    MaNuocSX = (int)row["MaNuocSX"],
                    TenNuocSX = row["TenNuocSX"].ToString()
                };
                nuocSXList.Add(nuocSX);
            }

            return nuocSXList;
        }
    }
}
