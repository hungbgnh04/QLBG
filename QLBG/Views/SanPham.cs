using QLBG.DAL;
using QLBG.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLBG.Views
{
    public partial class SanPham : UserControl
    {
        private ProductDAL productDAL = new ProductDAL();

        public SanPham()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            SanPhamPanel.Controls.Clear();
            List<ProductDTO> productList = productDAL.GetAllProducts();
            Console.WriteLine("Total products retrieved: " + productList.Count);
            foreach (var product in productList)
            {
                Console.WriteLine("Product ID: " + product.MaHang);
                TheSanPham theSanPham = new TheSanPham();
                theSanPham.LoadProductData(product); 
                SanPhamPanel.Controls.Add(theSanPham); 
            }
        }

        private void ThemBtn_Click(object sender, EventArgs e)
        {
            var chiTietSanPham = new frmChiTietSanPham(0, frmChiTietSanPham.Mode.Add);
            chiTietSanPham.Show();
        }

        private void TimBtn_Click(object sender, EventArgs e)
        {
            // Implement search functionality if needed
        }

        private void guna2TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimBtn_Click(sender, e);
            }
        }
    }
}
