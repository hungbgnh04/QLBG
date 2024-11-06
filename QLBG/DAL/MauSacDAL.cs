using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBG.DTO;

namespace QLBG.DAL
{
    public class MauSacDAL
    {
        public List<MauSacDTO> GetAllMauSac()
        {
            List<MauSacDTO> mauSacList = new List<MauSacDTO>();
            string query = "SELECT MaMau, TenMau FROM MauSac";

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                MauSacDTO mauSac = new MauSacDTO
                {
                    MaMau = (int)row["MaMau"],
                    TenMau = row["TenMau"].ToString()
                };
                mauSacList.Add(mauSac);
            }

            return mauSacList;
        }
    }
}
