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
    public partial class SanPham : UserControl
    {
        public SanPham()
        {
            InitializeComponent();
            guna2TabControl1_SelectedIndexChanged(null, null);
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

        private void pgChatLieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = guna2TabControl1.SelectedTab;
            MessageBox.Show(selectedTab.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (selectedTab == pgNuocSX)
            {
                LoadNuocSX();
            }
        }

        private void LoadNuocSX()
        {
            dgvNuocSX.Rows.Clear();
            dgvNuocSX.Rows.Add(1, "Việt Nam");
        }

        private void dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = (Guna2DataGridView)sender;
            var row = dgv.Rows[e.RowIndex];
            using (var frmThuocTinh = new frmThuocTinhSanPham(row, frmThuocTinhSanPham.Mode.View))
            {
                if (frmThuocTinh.ShowDialog() == DialogResult.OK)
                {
                    var result = frmThuocTinh.row;
                    switch (frmThuocTinh.mode)
                    {
                        case frmThuocTinhSanPham.Mode.Add:
                            dgv.Rows.Add(result.Cells[0].Value, result.Cells[1].Value);
                            break;
                        case frmThuocTinhSanPham.Mode.Edit:
                            row.Cells[1].Value = result.Cells[1].Value;
                            break;
                        case frmThuocTinhSanPham.Mode.Delete:
                            dgv.Rows.Remove(row);
                            break;
                        case frmThuocTinhSanPham.Mode.View:
                            break;
                    }
                }
            }
        }

        private void dgvNuocSX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemThuocTinh_Click(object sender, EventArgs e)
        {
            var selectedTab = guna2TabControl1.SelectedTab;
            Guna2DataGridView dgv = null;
            foreach (Control control in selectedTab.Controls)
            {
                if (control is Guna2ShadowPanel)
                {
                    for (int i = 0; i < control.Controls.Count; ++i)
                    {
                        if (control.Controls[i] is Guna2DataGridView)
                        {
                            dgv = control.Controls[i] as Guna2DataGridView;
                            break;
                        }
                    }
                    break;
                }
            }

            if (dgv != null)
            {
                using (var frmThuocTinh = new frmThuocTinhSanPham(new DataGridViewRow(), frmThuocTinhSanPham.Mode.Add))
                {
                    if (frmThuocTinh.ShowDialog() == DialogResult.OK)
                    {
                        var result = frmThuocTinh.row;
                        dgv.Rows.Add(result.Cells[0].Value, result.Cells[1].Value);
                    }
                }
            }
        }
    }
}
