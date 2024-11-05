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

        private void TheSanPham_Resize(object sender, EventArgs e)
        {
            TenLb.Width = HangLb.Width = (int)(this.Width * 0.893);

            HangLb.Location = new Point((this.Width - HangLb.Width) / 2, (int)(this.Height - HangLb.Height - 5));
            TenLb.Location = new Point((this.Width - HangLb.Width) / 2, HangLb.Height - TenLb.Height - 5);
        }
    }
}
