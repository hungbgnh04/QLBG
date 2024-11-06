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

        private void theSanPham2_Load(object sender, EventArgs e)
        {

        }

        private void ThemBtn_Click(object sender, EventArgs e)
        {
            var chiTietSanPham = new frmChiTietSanPham(0, frmChiTietSanPham.Mode.Add);
            chiTietSanPham.Show();
        }

        private void TimBtn_Click(object sender, EventArgs e)
        {

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
