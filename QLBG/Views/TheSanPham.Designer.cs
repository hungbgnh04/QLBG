namespace QLBG.Views
{
    partial class TheSanPham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheSanPham));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.HangLb = new System.Windows.Forms.Label();
            this.TenLb = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.HangLb);
            this.guna2ShadowPanel1.Controls.Add(this.TenLb);
            this.guna2ShadowPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 15;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(280, 400);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // HangLb
            // 
            this.HangLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HangLb.Location = new System.Drawing.Point(15, 327);
            this.HangLb.Name = "HangLb";
            this.HangLb.Size = new System.Drawing.Size(250, 60);
            this.HangLb.TabIndex = 5;
            this.HangLb.Text = "Hòa Phát";
            this.HangLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TenLb
            // 
            this.TenLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenLb.Location = new System.Drawing.Point(15, 260);
            this.TenLb.Margin = new System.Windows.Forms.Padding(20);
            this.TenLb.Name = "TenLb";
            this.TenLb.Size = new System.Drawing.Size(250, 60);
            this.TenLb.TabIndex = 4;
            this.TenLb.Text = "Ghế gỗ vải";
            this.TenLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(280, 250);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            // 
            // TheSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Margin = new System.Windows.Forms.Padding(25);
            this.Name = "TheSanPham";
            this.Size = new System.Drawing.Size(280, 400);
            this.Resize += new System.EventHandler(this.TheSanPham_Resize);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        public System.Windows.Forms.Label HangLb;
        public System.Windows.Forms.Label TenLb;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
