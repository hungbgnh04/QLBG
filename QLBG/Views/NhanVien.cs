using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace QLBG.Views
{
    public partial class NhanVien : UserControl
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RoundCorners(this, 60);
        }

        private void RoundCorners(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Add(9);

            string imagePath = Path.Combine(Application.StartupPath, "EmployeeImages", "ic_user.png");
            if (File.Exists(imagePath))
            {
                for (int i = 0; i < 9; i++)
                {
                    guna2DataGridView1.Rows[i].Cells[1].Value = Image.FromFile(imagePath);
                    guna2DataGridView1.Rows[i].Cells[2].Value = "Dian Cooper";
                    guna2DataGridView1.Rows[i].Cells[3].Value = "(239)555-2020";
                    guna2DataGridView1.Rows[i].Cells[4].Value = "Cilacap";
                    guna2DataGridView1.Rows[i].Cells[5].Value = "Jan 21,2020 -13:30";
                    guna2DataGridView1.Rows[i].Cells[6].Value = "Jan 21,2020";
                    guna2DataGridView1.Rows[i].Cells[7].Value = "Jan 21,2020";
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tệp ảnh: " + imagePath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
