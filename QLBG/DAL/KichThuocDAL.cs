﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLBG.DTO;

namespace QLBG.DAL
{
    public class KichThuocDAL
    {
        public List<KichThuocDTO> GetAllKichThuoc()
        {
            List<KichThuocDTO> kichThuocList = new List<KichThuocDTO>();
            string query = "SELECT MaKichThuoc, TenKichThuoc FROM KichThuoc";

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                KichThuocDTO kichThuoc = new KichThuocDTO
                {
                    MaKichThuoc = (int)row["MaKichThuoc"],
                    TenKichThuoc = row["TenKichThuoc"].ToString()
                };
                kichThuocList.Add(kichThuoc);
            }

            return kichThuocList;
        }

    }
}
