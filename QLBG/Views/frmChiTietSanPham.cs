using Guna.UI2.WinForms;
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
    public partial class frmChiTietSanPham : Form
    {
        public enum Mode
        {
            View,
            Edit,
            Add
        }

        private int id;
        public Mode mode;

        public frmChiTietSanPham(int id, Mode mode)
        {
            InitializeComponent();
            this.id=id;
            this.mode=mode;
            Init();
        }

        private void Init()
        {
            switch (mode)
            {
                case Mode.Edit:
                    HeaderLb.Text = "SỬA SẢN PHẨM";
                    SuaPanel.BringToFront();
                    for (int i = 0; i < ThongTinPanel.Controls.Count; i++)
                    {
                        if (ThongTinPanel.Controls[i] is Guna2TextBox)
                        {
                            ((Guna2TextBox)ThongTinPanel.Controls[i]).Enabled = true;
                            ((Guna2TextBox)ThongTinPanel.Controls[i]).BorderThickness = 1;
                        }
                        if (ThongTinPanel.Controls[i] is Guna2ComboBox)
                        {
                            ((Guna2ComboBox)ThongTinPanel.Controls[i]).Enabled = true;
                            ((Guna2ComboBox)ThongTinPanel.Controls[i]).BorderThickness = 1;
                        }
                    }
                    txtMa.Enabled = false;
                    txtSoLuong.Enabled = false;
                    SuaPanel.Location = ViewPanel.Location;
                    break;
                case Mode.Add:
                    HeaderLb.Text = "THÊM SẢN PHẨM";
                    ThemPanel.BringToFront();
                    for (int i = 0; i < ThongTinPanel.Controls.Count; i++)
                    {
                        if (ThongTinPanel.Controls[i] is Guna2TextBox)
                        {
                            ((Guna2TextBox)ThongTinPanel.Controls[i]).Enabled = true;
                            ((Guna2TextBox)ThongTinPanel.Controls[i]).BorderThickness = 1;
                        }
                        if (ThongTinPanel.Controls[i] is Guna2ComboBox)
                        {
                            ((Guna2ComboBox)ThongTinPanel.Controls[i]).Enabled = true;
                            ((Guna2ComboBox)ThongTinPanel.Controls[i]).BorderThickness = 1;
                        }
                    }
                    txtMa.Visible = false;
                    lbMa.Visible = false;
                    txtSoLuong.Visible = false;
                    lbSoLuong.Visible = false;
                    ThemPanel.Location = ViewPanel.Location;
                    break;
                default:
                    HeaderLb.Text = "CHI TIẾT SẢN PHẨM";
                    ViewPanel.BringToFront();
                    for (int i = 0; i < ThongTinPanel.Controls.Count; i++)
                    {
                        if (ThongTinPanel.Controls[i] is Guna2TextBox)
                        {
                            ((Guna2TextBox)ThongTinPanel.Controls[i]).Enabled = false;
                            ((Guna2TextBox)ThongTinPanel.Controls[i]).BorderThickness = 0;
                        }
                        if (ThongTinPanel.Controls[i] is Guna2ComboBox)
                        {
                            ((Guna2ComboBox)ThongTinPanel.Controls[i]).Enabled = false;
                            ((Guna2ComboBox)ThongTinPanel.Controls[i]).BorderThickness = 0;
                        }
                    }
                    break;
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            mode = Mode.Edit;
            Init();
        }

        private void HuyBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.View;
            Init();
        }

        private void ThoatBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
