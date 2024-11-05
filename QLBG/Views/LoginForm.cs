using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Configuration;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace QLBG.Views
{

    public partial class LoginForm : Form
    {
        private string emailToChangePass = "";
        private int stateOTPKind = 0;
        private int countDownOTPSecond = 60;
        private Thread thread;
        private string OTPCode;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private SqlConnect sqlconnect;
        string connectionString = @"Data Source=DANMINHTRAN\SQLEXPRESS;Initial Catalog=THONG_TIN_DANG_NHAP;Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();
            lackPassword.Visible = false;
            lackUsername.Visible = false;
            incorrectInfo.Visible = false;
            lackPassAgainSignUp.Visible = false;
            lackOTPLabel.Visible = false;
            wrongOTPLabel.Visible = false;
            signUpPanel.Visible = false;
            createNewPassPanel.Visible = false;
            OTPVerifyPanel.Visible = false;
            lackEmailSignUp.Visible = false;
            lackPassSignUp.Visible = false;
            lackUserSignUp.Visible = false;
            duplicateAcc.Visible = false;
            pnlForgotPassword.Visible = false;
            emailNotFound.Visible = false;
            emailNotType.Visible = false;
            panel1.MouseDown += DraggablePanel_MouseDown;
            panel1.MouseMove += DraggablePanel_MouseMove;
            panel1.MouseUp += DraggablePanel_MouseUp;
            sqlconnect = new SqlConnect(connectionString);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RoundCorners(this, 60);
            RoundCorners(btnUpdatePass, 60);
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

        private void initThread()
        {
            thread = new Thread(countDown);
            thread.IsBackground = true;
            thread.Start();
        }

        private void countDown()
        {
            int count = countDownOTPSecond;
            this.Invoke(new Action(() =>
            {
                btnOTP.Enabled = false;
                btnOTP.Visible = false;
                btnCountDown.Visible = true;
                btnCountDown.Location = btnOTP.Location;
            }));
            while (count > -1)
            {
                this.Invoke(new Action(() =>
                {
                    btnCountDown.Text = count.ToString();
                }));
                count--;
                Thread.Sleep(1000);
            }
            this.Invoke(new Action(() =>
            {
                btnOTP.Enabled = true;
                btnOTP.Visible = true;
                btnCountDown.Visible = false;
                OTPCode = "";
            }));
        }

        private string randDomOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private async Task<bool> SendEmailAsync(string toEmail, string otp)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(Properties.Resources.emailToSentOTP);
                mail.To.Add(toEmail);
                mail.Subject = "Your OTP Code";
                mail.Body = $"Your OTP Code is : {otp}";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.
                    NetworkCredential(Properties.Resources.emailToSentOTP, Properties.Resources.passwordApp);
                SmtpServer.EnableSsl = true;

                // Gửi email dưới nền
                await SmtpServer.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send OTP email or email not exist: " + ex.Message);
                return false;
            }
        }



        private void DraggablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
                this.Opacity = 0.5;
            }
        }

        private void DraggablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void DraggablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            this.Opacity = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") lackUsername.Visible = true;
            else lackUsername.Visible = false;
            if (textBox2.Text == "") lackPassword.Visible = true;
            else lackPassword.Visible = false;
            if (lackUsername.Visible == false && lackPassword.Visible == false)
            {
                if (sqlconnect.CheckLogin(textBox1.Text, textBox2.Text))
                {
                    incorrectInfo.Visible = false;
                    this.Hide();
                    //Form3 form3 = new Form3(textBox1.Text, "Login Successful!");
                    //form3.Show();
                    string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}")
                    { CreateNoWindow = true });
                    //Form2 form2 = new Form2();
                    //form2.Show();
                }
                else
                {
                    incorrectInfo.Visible = true;
                }
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            btnLogin.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = System.Drawing.Color.Lime;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = panel1.BackColor;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            signUpPanel.Visible = true;
            panel2.Dock = DockStyle.Right;
            signUpPanel.Dock = DockStyle.Left;
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Left;
            signUpPanel.Visible = false;
        }

        private void label12_Click_2(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Left;
            signUpPanel.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }



        private void initOTPPanelSetting(string noiceText)
        {
            OTPVerifyPanel.Visible = true;
            OTPVerifyPanel.Dock = DockStyle.Left;
            label7.AutoSize = false;
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Dock = DockStyle.Fill;
            label7.Text = noiceText;
            initThread();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ForeColor = System.Drawing.Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = System.Drawing.Color.Lime;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.ForeColor = System.Drawing.Color.Black;

        }

        private void backToLogin_MouseHover(object sender, EventArgs e)
        {
            backToLogin.ForeColor = System.Drawing.Color.Lime;
        }

        private void backToLogin_MouseLeave(object sender, EventArgs e)
        {
            backToLogin.ForeColor = System.Drawing.Color.White;
        }

        private void backToLogin_MouseMove(object sender, EventArgs e)
        {
            backToLogin.ForeColor = System.Drawing.Color.Lime;
        }

        private void signUpLabel_MouseHover(object sender, EventArgs e)
        {
            signUpLabel.ForeColor = System.Drawing.Color.Lime;
        }

        private void signUpLabel_MouseLeave(object sender, EventArgs e)
        {
            signUpLabel.ForeColor = System.Drawing.Color.White;
        }

        private void signUpLabel_MouseMove(object sender, EventArgs e)
        {
            signUpLabel.ForeColor = System.Drawing.Color.Lime;
        }

        private void signUpLabel_MouseHover_1(object sender, EventArgs e)
        {
            signUpLabel.ForeColor = System.Drawing.Color.Lime;
        }

        private void signUpLabel_MouseLeave_1(object sender, EventArgs e)
        {
            signUpLabel.ForeColor = System.Drawing.Color.White;
        }

        private void signUpLabel_MouseMove(object sender, MouseEventArgs e)
        {
            signUpLabel.ForeColor = System.Drawing.Color.Lime;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void signUpPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            pnlForgotPassword.Visible = true;
            panel2.Dock = DockStyle.Right;
            pnlForgotPassword.Dock = DockStyle.Left;
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            label8.ForeColor = System.Drawing.Color.Lime;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = System.Drawing.Color.White;
        }

        private void label8_MouseMove(object sender, MouseEventArgs e)
        {
            label8.ForeColor = System.Drawing.Color.Lime;
        }

        private async void btnOTP_Click(object sender, EventArgs e)
        {
            // Disable the button to prevent multiple clicks
            btnOTP.Enabled = false;

            string email = textBox5.Text; // Lấy email từ TextBox
            string otp = randDomOTP();     // Tạo OTP

            // Gửi email dưới nền
            bool isSuccess = await SendEmailAsync(email, otp);

            if (isSuccess)
            {
                MessageBox.Show("OTP sent successfully!");
            }

            // Kích hoạt lại nút sau khi hoàn thành
            btnOTP.Enabled = true;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                lackOTPLabel.Visible = true;
            }
            else
            {
                if (textBox10.Text == OTPCode)
                {
                    if (stateOTPKind == 0)
                    {
                        lackOTPLabel.Visible = false;
                        sqlconnect.addingAccontToSQL(textBox4.Text, textBox3.Text, textBox5.Text);
                        OTPVerifyPanel.Visible = false;
                        signUpPanel.Visible = false;
                        panel2.Dock = DockStyle.Left;
                        //Form3 form3 = new Form3("", "Sign up successful");
                        //form3.Show();
                    }
                    else
                    {
                        OTPVerifyPanel.Visible = false;
                        createNewPassPanel.Visible = true;
                        createNewPassPanel.Dock = DockStyle.Left;
                        creatNewPassLabel.Text = "Create new password for account " + emailToChangePass;
                        creatNewPassLabel.AutoSize = false;
                        creatNewPassLabel.TextAlign = ContentAlignment.MiddleCenter;
                        creatNewPassLabel.Dock = DockStyle.Fill;
                        stateOTPKind = 0;
                    }
                }
                else
                {
                    wrongOTPLabel.Visible = true;
                }
            }
        }

        private void button1_MouseHover_1(object sender, EventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.Lime;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {
        }

        private void label16_MouseHover(object sender, EventArgs e)
        {
            label16.ForeColor = System.Drawing.Color.Lime;
        }

        private void label16_MouseLeave(object sender, EventArgs e)
        {
            label16.ForeColor = System.Drawing.Color.White;
        }

        private void label16_MouseMove(object sender, MouseEventArgs e)
        {
            label16.ForeColor = System.Drawing.Color.Lime;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            thread.Abort();
            if (stateOTPKind == 0)
            {
                OTPVerifyPanel.Visible = false;
                signUpPanel.Visible = true;
                signUpPanel.Dock = DockStyle.Left;
            }
            else
            {
                OTPVerifyPanel.Visible = false;
                pnlForgotPassword.Visible = true;
                pnlForgotPassword.Dock = DockStyle.Left;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void NoLabel_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Left;
            pnlForgotPassword.Visible = false;
        }

        private async void btnGetPass_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu email chưa được nhập
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                emailNotType.Visible = true;
            }
            else
            {
                // Kiểm tra nếu email tồn tại trong cơ sở dữ liệu
                if (!sqlconnect.CheckEmailExist(textBox7.Text))
                {
                    emailNotFound.Visible = true;
                }
                else
                {
                    emailNotFound.Visible = false;
                    emailNotType.Visible = false;

                    // Tạo OTP và gửi email
                    OTPCode = randDomOTP();
                    bool isSent = await SendEmailAsync(textBox7.Text, OTPCode); // Gọi hàm gửi email

                    if (isSent)
                    {
                        pnlForgotPassword.Visible = false;
                        string noiceText = "We have just sent the OTP code to email address "
                            + textBox7.Text +
                            ", please enter the code to change new password.";
                        initOTPPanelSetting(noiceText);
                        stateOTPKind = 1;
                        emailToChangePass = textBox7.Text;
                    }
                    else
                    {
                        MessageBox.Show("Failed to send OTP email. Please try again.");
                    }
                }
            }
        }


        private void btnGetPass_MouseHover(object sender, EventArgs e)
        {
            btnGetPass.ForeColor = System.Drawing.Color.Black;
        }

        private void btnGetPass_MouseLeave(object sender, EventArgs e)
        {
            btnGetPass.ForeColor = System.Drawing.Color.Lime;
        }

        private void btnGetPass_MouseMove(object sender, MouseEventArgs e)
        {
            btnGetPass.ForeColor = System.Drawing.Color.Black;
        }

        private void label19_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                lackNewPassLabel.Visible = true;
            }
            else
            {
                if (textBox8.Text == "")
                {
                    lackNewPassAgainLabel.Visible = true;
                }
                else
                {
                    if (textBox8.Text != textBox11.Text)
                    {
                        newPassNotMatchLabel.Visible = true;
                    }
                    else
                    {
                        newPassNotMatchLabel.Visible = false;
                        sqlconnect.updatePassword(emailToChangePass, textBox8.Text);
                        createNewPassPanel.Visible = false;
                        //Form3 form3 = new Form3("", "Change password successful!");
                        //form3.Show();
                        panel2.Dock = DockStyle.Left;
                    }
                }
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            createNewPassPanel.Visible = false;
            pnlForgotPassword.Visible = true;
        }

        private void label18_MouseHover(object sender, EventArgs e)
        {
            label18.ForeColor = System.Drawing.Color.Lime;
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            label18.ForeColor = System.Drawing.Color.White;
        }

        private void label18_MouseMove(object sender, MouseEventArgs e)
        {
            label18.ForeColor = System.Drawing.Color.Lime;
        }

        private void btnUpdatePass_MouseHover(object sender, EventArgs e)
        {
            btnUpdatePass.ForeColor = System.Drawing.Color.Black;
        }

        private void btnUpdatePass_MouseLeave(object sender, EventArgs e)
        {
            btnUpdatePass.ForeColor = System.Drawing.Color.Lime;
        }

        private void btnUpdatePass_MouseMove(object sender, MouseEventArgs e)
        {
            btnUpdatePass.ForeColor = System.Drawing.Color.Black;
        }

        private void label26_MouseHover(object sender, EventArgs e)
        {
            label26.ForeColor = System.Drawing.Color.Lime;
        }

        private void label26_MouseLeave(object sender, EventArgs e)
        {
            label26.ForeColor = System.Drawing.Color.White;
        }

        private void label26_MouseMove(object sender, MouseEventArgs e)
        {
            label26.ForeColor = System.Drawing.Color.Lime;
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void createNewPassPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void createNewPassPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class SqlConnect
    {
        private readonly string connectionString;
        public SqlConnect(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void updatePassword(string email, string newPassword)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "UPDATE TaiKhoan SET Password=@password WHERE Email=@email";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@password", newPassword);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        public bool CheckEmailExist(string email)
        {
            bool isValid = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT COUNT(1) FROM TaiKhoan WHERE Email=@email";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        isValid = (count == 1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            return isValid;
        }

        public bool CheckLogin(string username, string password)
        {
            bool isValid = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT COUNT(1) FROM TaiKhoan WHERE Username=@username AND Password=@password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        isValid = (count == 1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            return isValid;
        }

        public bool CheckSignUpDuplicateAccount(string username, string email)
        {
            bool isValid = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT COUNT(1) FROM TaiKhoan WHERE Username=@username OR Email=@email";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        isValid = (count > 0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            return isValid;
        }

        public void addingAccontToSQL(string username, string password, string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO TaiKhoan(Username,Password,Email) VALUES(@username,@password,@email)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
