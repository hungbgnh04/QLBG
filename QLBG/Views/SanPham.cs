using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBG.Views
{
    public partial class SanPham : UserControl
    {
        public SanPham()
        {
            InitializeComponent();
        }

        private void ChiTietSanPham(object sender, EventArgs e)
        {
            var sp = sender as TheSanPham;
            var chiTietSanPham = new frmChiTietSanPham(sp.MaSP);
            chiTietSanPham.Show();
        }

        private void theSanPham2_Load(object sender, EventArgs e)
        {

        }
    }
}
