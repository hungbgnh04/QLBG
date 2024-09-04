using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QLBG
{

    public partial class MainForm : Form
    {
        private List<IconButton> btnList;
        private List<Panel> pnlList;
        private bool isSideBarExpanded = true;
        private IconButton currentButton;
        private Panel leftBorderBtn;

        public bool IsSideBarExpanded
        {
            get => isSideBarExpanded;
            set => isSideBarExpanded = value;
        }

        public MainForm()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            sideBarPanel.Controls.Add(leftBorderBtn);
            btnList = new List<IconButton>();
            pnlList = new List<Panel>();

            btnList.Add(productBTN);
            pnlList.Add(productPanel);

            btnList.Add(billBTN);
            pnlList.Add(billPanel);

            btnList.Add(customerBTN);
            pnlList.Add(customerPanel);

            btnList.Add(accountBTN);
            pnlList.Add(accountPanel);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach(Component c in contentPanel.Controls)
            {
                if (c is Panel)
                {
                    Panel pnl = (Panel)c;
                    pnl.Dock = DockStyle.Fill;
                }
            }
            homePanel.BringToFront();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            
        }

        private void ResizeSideBar(object sender, EventArgs e)
        {
            if (isSideBarExpanded)
            {
                sideBarPanel.Width -= 10;
                if (sideBarPanel.Width <= sideBarPanel.MinimumSize.Width)
                {
                    sideBarTimer.Stop();
                    isSideBarExpanded = false;
                    if (currentButton != null)
                    {
                        leftBorderBtn.Visible = false;
                        leftBorderBtn.SendToBack();
                        currentButton.ImageAlign = ContentAlignment.MiddleCenter;
                    }
                }
            }
            else
            {
                sideBarPanel.Width += 10;
                if (sideBarPanel.Width >= sideBarPanel.MaximumSize.Width)
                {
                    sideBarTimer.Stop();
                    isSideBarExpanded = true;
                    if (currentButton != null)
                    {
                        leftBorderBtn.Visible = true;
                        leftBorderBtn.BringToFront();
                        currentButton.ImageAlign = ContentAlignment.MiddleRight;
                    }
                }
            }
            sideBarPanel.Invalidate();
            sideBarPanel.Update();
        }

        private void sideBarPanel_Click(object sender, EventArgs e)
        {
            sideBarTimer.Start();
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hideBTN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null && senderBtn != homeBTN)
            {
                Reset();
                currentButton = (IconButton)senderBtn;
                currentButton.BackColor = Color.White;
                //currentButton.BackColor = Color.FromArgb(200, 150, 150);
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = color;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentButton.Location.Y);
                if (isSideBarExpanded)
                {
                    currentButton.ImageAlign = ContentAlignment.MiddleRight;
                    leftBorderBtn.Visible = true;
                    leftBorderBtn.BringToFront();
                } else
                {
                    leftBorderBtn.Visible = false;
                    currentButton.ImageAlign = ContentAlignment.MiddleCenter;
                    leftBorderBtn.SendToBack();
                }
                int index = btnList.IndexOf(currentButton);
                pnlList[index].BringToFront();
            }
        }

        private void Reset()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Transparent;
                currentButton.ForeColor = Color.Black;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = Color.Black;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(247, 101, 163));
            //ActivateButton(sender, Color.FromArgb(37, 36, 81));
        }

        private void BTN_MouseEnter(object sender, EventArgs e)
        {
            if (currentButton != (IconButton)sender)
            {
                IconButton btn = sender as IconButton;
                btn.ForeColor = Color.White;
                btn.IconColor = Color.White;
                btn.BackColor = Color.FromArgb(247, 101, 163);
            }
        }

        private void BTN_MouseLeave(object sender, EventArgs e)
        {
            if (currentButton != (IconButton)sender)
            {
                IconButton btn = sender as IconButton;
                btn.ForeColor = Color.Black;
                btn.IconColor = Color.Black;
                btn.BackColor = Color.Transparent;
            }
        }

        private void homeBTN_Click(object sender, EventArgs e)
        {
            Reset();
            currentButton = null;
            leftBorderBtn.Visible = false;
            homePanel.BringToFront();
        }
    }
}
