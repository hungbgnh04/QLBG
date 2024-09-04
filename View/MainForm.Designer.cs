namespace QLBG
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sideBarTimer = new System.Windows.Forms.Timer(this.components);
            this.menuPanel = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hideBTN = new FontAwesome.Sharp.IconButton();
            this.closeBTN = new FontAwesome.Sharp.IconButton();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.homePanel = new System.Windows.Forms.Panel();
            this.productPanel = new System.Windows.Forms.Panel();
            this.billPanel = new System.Windows.Forms.Panel();
            this.customerPanel = new System.Windows.Forms.Panel();
            this.accountPanel = new System.Windows.Forms.Panel();
            this.sideBarPanel = new QLBG.RoundedPanel();
            this.billBTN = new FontAwesome.Sharp.IconButton();
            this.homeBTN = new FontAwesome.Sharp.IconPictureBox();
            this.accountBTN = new FontAwesome.Sharp.IconButton();
            this.customerBTN = new FontAwesome.Sharp.IconButton();
            this.productBTN = new FontAwesome.Sharp.IconButton();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.containerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.sideBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeBTN)).BeginInit();
            this.SuspendLayout();
            // 
            // sideBarTimer
            // 
            this.sideBarTimer.Interval = 10;
            this.sideBarTimer.Tick += new System.EventHandler(this.ResizeSideBar);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.White;
            this.menuPanel.Controls.Add(this.iconPictureBox1);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Controls.Add(this.hideBTN);
            this.menuPanel.Controls.Add(this.closeBTN);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1400, 49);
            this.menuPanel.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.GithubAlt;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 49;
            this.iconPictureBox1.Location = new System.Drawing.Point(12, 0);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(49, 49);
            this.iconPictureBox1.TabIndex = 3;
            this.iconPictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(76, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản lý bàn ghế";
            // 
            // hideBTN
            // 
            this.hideBTN.FlatAppearance.BorderSize = 0;
            this.hideBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideBTN.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.hideBTN.IconColor = System.Drawing.Color.Black;
            this.hideBTN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.hideBTN.IconSize = 32;
            this.hideBTN.Location = new System.Drawing.Point(1300, 4);
            this.hideBTN.Name = "hideBTN";
            this.hideBTN.Size = new System.Drawing.Size(46, 42);
            this.hideBTN.TabIndex = 0;
            this.hideBTN.UseVisualStyleBackColor = true;
            this.hideBTN.Click += new System.EventHandler(this.hideBTN_Click);
            // 
            // closeBTN
            // 
            this.closeBTN.FlatAppearance.BorderSize = 0;
            this.closeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBTN.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.closeBTN.IconColor = System.Drawing.Color.Black;
            this.closeBTN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closeBTN.IconSize = 32;
            this.closeBTN.Location = new System.Drawing.Point(1352, 4);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(43, 39);
            this.closeBTN.TabIndex = 0;
            this.closeBTN.UseVisualStyleBackColor = true;
            this.closeBTN.Click += new System.EventHandler(this.closeBTN_Click);
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.Color.Transparent;
            this.containerPanel.Controls.Add(this.contentPanel);
            this.containerPanel.Controls.Add(this.sideBarPanel);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 49);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Padding = new System.Windows.Forms.Padding(10);
            this.containerPanel.Size = new System.Drawing.Size(1400, 951);
            this.containerPanel.TabIndex = 1;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.accountPanel);
            this.contentPanel.Controls.Add(this.customerPanel);
            this.contentPanel.Controls.Add(this.billPanel);
            this.contentPanel.Controls.Add(this.productPanel);
            this.contentPanel.Controls.Add(this.homePanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(260, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.contentPanel.Size = new System.Drawing.Size(1130, 931);
            this.contentPanel.TabIndex = 2;
            // 
            // homePanel
            // 
            this.homePanel.BackColor = System.Drawing.Color.Transparent;
            this.homePanel.Location = new System.Drawing.Point(30, 26);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(300, 300);
            this.homePanel.TabIndex = 0;
            // 
            // productPanel
            // 
            this.productPanel.BackColor = System.Drawing.Color.Transparent;
            this.productPanel.Location = new System.Drawing.Point(394, 26);
            this.productPanel.Name = "productPanel";
            this.productPanel.Size = new System.Drawing.Size(300, 300);
            this.productPanel.TabIndex = 1;
            // 
            // billPanel
            // 
            this.billPanel.BackColor = System.Drawing.Color.Transparent;
            this.billPanel.Location = new System.Drawing.Point(786, 26);
            this.billPanel.Name = "billPanel";
            this.billPanel.Size = new System.Drawing.Size(300, 300);
            this.billPanel.TabIndex = 2;
            // 
            // customerPanel
            // 
            this.customerPanel.BackColor = System.Drawing.Color.Transparent;
            this.customerPanel.Location = new System.Drawing.Point(34, 378);
            this.customerPanel.Name = "customerPanel";
            this.customerPanel.Size = new System.Drawing.Size(300, 300);
            this.customerPanel.TabIndex = 3;
            // 
            // accountPanel
            // 
            this.accountPanel.BackColor = System.Drawing.Color.Transparent;
            this.accountPanel.Location = new System.Drawing.Point(394, 388);
            this.accountPanel.Name = "accountPanel";
            this.accountPanel.Size = new System.Drawing.Size(300, 300);
            this.accountPanel.TabIndex = 4;
            // 
            // sideBarPanel
            // 
            this.sideBarPanel.BackColor = System.Drawing.Color.White;
            this.sideBarPanel.BorderColor = System.Drawing.Color.Silver;
            this.sideBarPanel.BorderWidth = 1;
            this.sideBarPanel.BottomLeft = 20;
            this.sideBarPanel.BottomRight = 20;
            this.sideBarPanel.Controls.Add(this.billBTN);
            this.sideBarPanel.Controls.Add(this.homeBTN);
            this.sideBarPanel.Controls.Add(this.accountBTN);
            this.sideBarPanel.Controls.Add(this.customerBTN);
            this.sideBarPanel.Controls.Add(this.productBTN);
            this.sideBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarPanel.ForeColor = System.Drawing.Color.White;
            this.sideBarPanel.Location = new System.Drawing.Point(10, 10);
            this.sideBarPanel.MaximumSize = new System.Drawing.Size(250, 0);
            this.sideBarPanel.MinimumSize = new System.Drawing.Size(70, 0);
            this.sideBarPanel.Name = "sideBarPanel";
            this.sideBarPanel.Padding = new System.Windows.Forms.Padding(10);
            this.sideBarPanel.Size = new System.Drawing.Size(250, 931);
            this.sideBarPanel.TabIndex = 1;
            this.sideBarPanel.TopLeft = 20;
            this.sideBarPanel.TopRight = 20;
            this.sideBarPanel.Click += new System.EventHandler(this.sideBarPanel_Click);
            // 
            // billBTN
            // 
            this.billBTN.BackColor = System.Drawing.Color.Transparent;
            this.billBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.billBTN.FlatAppearance.BorderSize = 0;
            this.billBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.billBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billBTN.ForeColor = System.Drawing.Color.Black;
            this.billBTN.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.billBTN.IconColor = System.Drawing.Color.Black;
            this.billBTN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.billBTN.IconSize = 56;
            this.billBTN.Location = new System.Drawing.Point(-15, 318);
            this.billBTN.Name = "billBTN";
            this.billBTN.Size = new System.Drawing.Size(281, 60);
            this.billBTN.TabIndex = 0;
            this.billBTN.Text = "Hóa đơn";
            this.billBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.billBTN.UseVisualStyleBackColor = false;
            this.billBTN.Click += new System.EventHandler(this.BTN_Click);
            this.billBTN.MouseEnter += new System.EventHandler(this.BTN_MouseEnter);
            this.billBTN.MouseLeave += new System.EventHandler(this.BTN_MouseLeave);
            // 
            // homeBTN
            // 
            this.homeBTN.BackColor = System.Drawing.Color.Transparent;
            this.homeBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeBTN.ForeColor = System.Drawing.Color.Black;
            this.homeBTN.IconChar = FontAwesome.Sharp.IconChar.GithubAlt;
            this.homeBTN.IconColor = System.Drawing.Color.Black;
            this.homeBTN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.homeBTN.IconSize = 230;
            this.homeBTN.Location = new System.Drawing.Point(10, 10);
            this.homeBTN.Name = "homeBTN";
            this.homeBTN.Size = new System.Drawing.Size(230, 241);
            this.homeBTN.TabIndex = 1;
            this.homeBTN.TabStop = false;
            this.homeBTN.UseGdi = true;
            this.homeBTN.UseIconCache = true;
            this.homeBTN.Click += new System.EventHandler(this.homeBTN_Click);
            // 
            // accountBTN
            // 
            this.accountBTN.BackColor = System.Drawing.Color.Transparent;
            this.accountBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.accountBTN.FlatAppearance.BorderSize = 0;
            this.accountBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountBTN.ForeColor = System.Drawing.Color.Black;
            this.accountBTN.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.accountBTN.IconColor = System.Drawing.Color.Black;
            this.accountBTN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.accountBTN.IconSize = 56;
            this.accountBTN.Location = new System.Drawing.Point(-10, 438);
            this.accountBTN.Name = "accountBTN";
            this.accountBTN.Size = new System.Drawing.Size(281, 60);
            this.accountBTN.TabIndex = 0;
            this.accountBTN.Text = "Tài khoản";
            this.accountBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.accountBTN.UseVisualStyleBackColor = false;
            this.accountBTN.Click += new System.EventHandler(this.BTN_Click);
            this.accountBTN.MouseEnter += new System.EventHandler(this.BTN_MouseEnter);
            this.accountBTN.MouseLeave += new System.EventHandler(this.BTN_MouseLeave);
            // 
            // customerBTN
            // 
            this.customerBTN.BackColor = System.Drawing.Color.Transparent;
            this.customerBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.customerBTN.FlatAppearance.BorderSize = 0;
            this.customerBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customerBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerBTN.ForeColor = System.Drawing.Color.Black;
            this.customerBTN.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.customerBTN.IconColor = System.Drawing.Color.Black;
            this.customerBTN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.customerBTN.IconSize = 56;
            this.customerBTN.Location = new System.Drawing.Point(-3, 378);
            this.customerBTN.Name = "customerBTN";
            this.customerBTN.Size = new System.Drawing.Size(281, 60);
            this.customerBTN.TabIndex = 0;
            this.customerBTN.Text = "Người dùng";
            this.customerBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.customerBTN.UseVisualStyleBackColor = false;
            this.customerBTN.Click += new System.EventHandler(this.BTN_Click);
            this.customerBTN.MouseEnter += new System.EventHandler(this.BTN_MouseEnter);
            this.customerBTN.MouseLeave += new System.EventHandler(this.BTN_MouseLeave);
            // 
            // productBTN
            // 
            this.productBTN.BackColor = System.Drawing.Color.Transparent;
            this.productBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.productBTN.FlatAppearance.BorderSize = 0;
            this.productBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productBTN.ForeColor = System.Drawing.Color.Black;
            this.productBTN.IconChar = FontAwesome.Sharp.IconChar.Couch;
            this.productBTN.IconColor = System.Drawing.Color.Black;
            this.productBTN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.productBTN.IconSize = 56;
            this.productBTN.Location = new System.Drawing.Point(-7, 258);
            this.productBTN.Name = "productBTN";
            this.productBTN.Size = new System.Drawing.Size(281, 60);
            this.productBTN.TabIndex = 0;
            this.productBTN.Text = "Sản phẩm";
            this.productBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.productBTN.UseVisualStyleBackColor = false;
            this.productBTN.Click += new System.EventHandler(this.BTN_Click);
            this.productBTN.MouseEnter += new System.EventHandler(this.BTN_MouseEnter);
            this.productBTN.MouseLeave += new System.EventHandler(this.BTN_MouseLeave);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1400, 1000);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.containerPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.sideBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homeBTN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer sideBarTimer;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel containerPanel;
        private FontAwesome.Sharp.IconButton closeBTN;
        private FontAwesome.Sharp.IconButton hideBTN;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton customerBTN;
        private FontAwesome.Sharp.IconButton billBTN;
        private FontAwesome.Sharp.IconButton productBTN;
        private RoundedPanel sideBarPanel;
        private System.Windows.Forms.Panel contentPanel;
        private FontAwesome.Sharp.IconPictureBox homeBTN;
        private System.Windows.Forms.Panel homePanel;
        private FontAwesome.Sharp.IconButton accountBTN;
        private System.Windows.Forms.Panel productPanel;
        private System.Windows.Forms.Panel customerPanel;
        private System.Windows.Forms.Panel billPanel;
        private System.Windows.Forms.Panel accountPanel;
    }
}

