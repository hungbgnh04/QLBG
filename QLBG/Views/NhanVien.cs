using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using QLBG.DAL;

namespace QLBG.Views
{
    public partial class NhanVien : UserControl
    {
        private readonly DatabaseHelper dbHelper;

        public NhanVien()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            InitializeDataGridView();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RoundCorners(this, 60);
            LoadEmployeeData();
            lblSoLuongNhanVien.Text = $"{guna2DataGridView1.Rows.Count}";
            comboBoxSortBy.Items.Add("Mã Nhân Viên");
            comboBoxSortBy.Items.Add("Tên Nhân Viên");
            comboBoxSortBy.SelectedIndex = 0;
            textBoxTenDeTimKiem.KeyDown += textBoxTenDeTimKiem_KeyDown;
            comboBoxSortBy.SelectedIndexChanged += ComboBoxSortBy_SelectedIndexChanged;
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

        private void InitializeDataGridView()
        {
            guna2DataGridView1.Columns.Clear();

            // Cột Mã Nhân Viên
            DataGridViewTextBoxColumn maNVCol = new DataGridViewTextBoxColumn
            {
                Name = "MaNV",
                HeaderText = "Mã Nhân Viên"
            };
            guna2DataGridView1.Columns.Add(maNVCol);

            // Cột ảnh
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                Name = "Anh",
                HeaderText = "Ảnh",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            guna2DataGridView1.Columns.Add(imgCol);

            // Cột tên nhân viên
            DataGridViewTextBoxColumn tenNVCol = new DataGridViewTextBoxColumn
            {
                Name = "TenNV",
                HeaderText = "Tên Nhân Viên"
            };
            guna2DataGridView1.Columns.Add(tenNVCol);

            // Cột giới tính
            DataGridViewTextBoxColumn gioiTinhCol = new DataGridViewTextBoxColumn
            {
                Name = "GioiTinh",
                HeaderText = "Giới Tính"
            };
            guna2DataGridView1.Columns.Add(gioiTinhCol);

            // Cột ngày sinh
            DataGridViewTextBoxColumn ngaySinhCol = new DataGridViewTextBoxColumn
            {
                Name = "NgaySinh",
                HeaderText = "Ngày Sinh"
            };
            guna2DataGridView1.Columns.Add(ngaySinhCol);

            // Cột điện thoại
            DataGridViewTextBoxColumn dienThoaiCol = new DataGridViewTextBoxColumn
            {
                Name = "DienThoai",
                HeaderText = "Điện Thoại"
            };
            guna2DataGridView1.Columns.Add(dienThoaiCol);

            // Cột địa chỉ
            DataGridViewTextBoxColumn diaChiCol = new DataGridViewTextBoxColumn
            {
                Name = "DiaChi",
                HeaderText = "Địa Chỉ"
            };
            guna2DataGridView1.Columns.Add(diaChiCol);

            // Cột tên công việc
            DataGridViewTextBoxColumn tenCVCol = new DataGridViewTextBoxColumn
            {
                Name = "TenCV",
                HeaderText = "Công Việc"
            };
            guna2DataGridView1.Columns.Add(tenCVCol);
        }

        private void LoadEmployeeData()
        {
            DataTable employees = dbHelper.GetEmployeesWithJob();
            guna2DataGridView1.Rows.Clear();

            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imageDirectory = Path.Combine(projectDirectory, "Resources", "EmployeeImages");
            string defaultImagePath = Path.Combine(imageDirectory, "ic_user.png");

            foreach (DataRow row in employees.Rows)
            {
                int rowIndex = guna2DataGridView1.Rows.Add();
                DataGridViewRow dgvRow = guna2DataGridView1.Rows[rowIndex];

                // Thêm dữ liệu vào cột Mã Nhân Viên
                dgvRow.Cells["MaNV"].Value = row["MaNV"].ToString();

                // Lấy tên ảnh từ cơ sở dữ liệu và tạo đường dẫn đầy đủ
                string imageName = row["Anh"].ToString();
                string imagePath = Path.Combine(imageDirectory, imageName);

                // Kiểm tra nếu ảnh tồn tại thì tải ảnh, nếu không sử dụng ảnh mặc định
                if (!string.IsNullOrEmpty(imageName) && File.Exists(imagePath))
                {
                    dgvRow.Cells["Anh"].Value = Image.FromFile(imagePath);
                }
                else if (File.Exists(defaultImagePath))
                {
                    dgvRow.Cells["Anh"].Value = Image.FromFile(defaultImagePath);
                }
                else
                {
                    dgvRow.Cells["Anh"].Value = DBNull.Value;
                }

                // Các cột khác
                dgvRow.Cells["TenNV"].Value = row["TenNV"].ToString();
                dgvRow.Cells["GioiTinh"].Value = Convert.ToBoolean(row["GioiTinh"]) ? "Nam" : "Nữ";
                dgvRow.Cells["NgaySinh"].Value = Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy");
                dgvRow.Cells["DienThoai"].Value = row["DienThoai"].ToString();
                dgvRow.Cells["DiaChi"].Value = row["DiaChi"].ToString();
                dgvRow.Cells["TenCV"].Value = row["TenCV"].ToString();
            }
        }

        private void ComboBoxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = comboBoxSortBy.SelectedItem.ToString();
            DataGridViewColumn columnToSort = null;

            if (sortBy == "Mã Nhân Viên")
            {
                columnToSort = guna2DataGridView1.Columns["MaNV"];
            }
            else if (sortBy == "Tên Nhân Viên")
            {
                columnToSort = guna2DataGridView1.Columns["TenNV"];
            }

            // Kiểm tra nếu cột tồn tại trước khi sắp xếp
            if (columnToSort != null)
            {
                guna2DataGridView1.Sort(columnToSort, System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                MessageBox.Show("Không tìm thấy cột để sắp xếp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = "EmployeeData.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Employees");

                        // Tiêu đề cột
                        for (int i = 0; i < guna2DataGridView1.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = guna2DataGridView1.Columns[i].HeaderText;
                        }

                        // Dữ liệu từ DataGridView
                        for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < guna2DataGridView1.Columns.Count; j++)
                            {
                                var cellValue = guna2DataGridView1.Rows[i].Cells[j].Value;
                                worksheet.Cell(i + 2, j + 1).Value = cellValue is DBNull ? "" : cellValue.ToString();
                            }
                        }

                        // Lưu file
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnTaoNhanVien_Click(object sender, EventArgs e)
        {
            // Xử lý logic tạo nhân viên
        }

        private void btnTimKiemTheoTen_Click(object sender, EventArgs e)
        {
            string searchName = textBoxTenDeTimKiem.Text.Trim().ToLower();

            // Nếu ô tìm kiếm trống, hiển thị tất cả các hàng
            if (string.IsNullOrEmpty(searchName))
            {
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            // Lọc các hàng trong DataGridView dựa trên tên nhân viên
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["TenNV"].Value != null &&
                    row.Cells["TenNV"].Value.ToString().ToLower().Contains(searchName))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void textBoxTenDeTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím Enter được nhấn
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemTheoTen_Click(sender, e); // Gọi sự kiện tìm kiếm
                e.Handled = true;
                e.SuppressKeyPress = true; // Ngăn không cho âm thanh beep
            }
        }
    }
}
