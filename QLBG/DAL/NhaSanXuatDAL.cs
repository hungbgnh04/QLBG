using QLBG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class NhaSanXuatDAL
    {
        public List<NhaSanXuatDTO> GetAllNhaSanXuat()
        {
            List<NhaSanXuatDTO> nhaSanXuatList = new List<NhaSanXuatDTO>();
            string query = "SELECT MaNSX, TenNSX, DiaChi, DienThoai FROM NhaSanXuat";

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                NhaSanXuatDTO nhaSanXuat = new NhaSanXuatDTO
                {
                    MaNSX = (int)row["MaNSX"],
                    TenNSX = row["TenNSX"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                };
                nhaSanXuatList.Add(nhaSanXuat);
            }

            return nhaSanXuatList;
        }

        public NhaSanXuatDTO GetNhaSanXuatById(int maNSX)
        {
            string query = "SELECT MaNSX, TenNSX, DiaChi, DienThoai FROM NhaSanXuat WHERE MaNSX = @MaNSX";
            SqlParameter parameter = new SqlParameter("@MaNSX", maNSX);

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new NhaSanXuatDTO
                {
                    MaNSX = (int)row["MaNSX"],
                    TenNSX = row["TenNSX"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                };
            }
            return null; // Trả về null nếu không tìm thấy nhà sản xuất
        }


    }
}
