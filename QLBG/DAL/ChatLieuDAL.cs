using QLBG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class ChatLieuDAL
    {
        public List<ChatLieuDTO> GetAllChatLieu()
        {
            List<ChatLieuDTO> chatLieuList = new List<ChatLieuDTO>();
            string query = "SELECT MaChatLieu, TenChatLieu FROM ChatLieu";

            DataTable dataTable = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                ChatLieuDTO chatLieu = new ChatLieuDTO
                {
                    MaChatLieu = (int)row["MaChatLieu"],
                    TenChatLieu = row["TenChatLieu"].ToString()
                };
                chatLieuList.Add(chatLieu);
            }

            return chatLieuList;
        }
    }
}
