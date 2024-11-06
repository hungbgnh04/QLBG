using QLBG.DAL;
using QLBG.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBG.Views
{
    public partial class TheSanPham : UserControl
    {
        public int MaSP { get; set; }

        public Color FIllColor
        {
            get
            {
                return guna2ShadowPanel1.FillColor;
            }
            set
            {
                guna2ShadowPanel1.FillColor = value;
                this.Update();
            }
        }

        public TheSanPham()
        {
            InitializeComponent();
        }

        public void LoadProductData(ProductDTO product)
        {
            MaSP = product.MaHang;
            TenLb.Text = product.TenHangHoa;
            HangLb.Text = GetManufacturerName(product.MaNSX);
            if (!string.IsNullOrEmpty(product.Anh) && File.Exists(product.Anh))
            {
                PictureBoxAnh.Image = Image.FromFile(product.Anh);
                PictureBoxAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                PictureBoxAnh.Image = null; 
            }
        }

        private string GetManufacturerName(int maNSX)
        {
            NhaSanXuatDAL nhaSanXuatDAL = new NhaSanXuatDAL();
            var nhaSanXuat = nhaSanXuatDAL.GetNhaSanXuatById(maNSX);
            return nhaSanXuat?.TenNSX ?? "Unknown";
        }

        private void TheSanPham_Resize(object sender, EventArgs e)
        {
            TenLb.Width = HangLb.Width = (int)(this.Width * 0.893);
            HangLb.Location = new Point((this.Width - HangLb.Width) / 2, (int)(this.Height - HangLb.Height - 5));
            TenLb.Location = new Point((this.Width - HangLb.Width) / 2, HangLb.Height - TenLb.Height - 5);
        }

        private void TenLb_Click_1(object sender, EventArgs e)
        {
            var chiTietSanPham = new frmChiTietSanPham(MaSP, frmChiTietSanPham.Mode.View);
            chiTietSanPham.Show();
        }
    }
}
