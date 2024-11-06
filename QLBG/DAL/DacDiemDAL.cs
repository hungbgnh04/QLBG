using QLBG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class DacDiemDAL
    {
        public List<DacDiemDTO> GetAllDacDiem()
        {
            List<DacDiemDTO> dacDiemList = new List<DacDiemDTO>();
            string query = "SELECT MaDacDiem, TenDacDiem FROM DacDiem";

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                DacDiemDTO dacDiem = new DacDiemDTO
                {
                    MaDacDiem = (int)row["MaDacDiem"],
                    TenDacDiem = row["TenDacDiem"].ToString()
                };
                dacDiemList.Add(dacDiem);
            }

            return dacDiemList;
        }
    }
}