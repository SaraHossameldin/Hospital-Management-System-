using System;
using System.Drawing;
using System.Windows.Forms;

namespace HMS
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnManageStaff;
        private Button btnLogout;
        private Label lblTitle;
        private Panel panelContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Panel container
            panelContainer = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(230, 245, 255) // soft blue
            };

            // Title label
            lblTitle = new Label()
            {
                Text = "Admin Dashboard",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 70, 140),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 120
            };

            // Buttons width/height
            int buttonWidth = 220;
            int buttonHeight = 60;
            int spacingX = 40;

            btnManageStaff = new Button()
            {
                Text = "Manage Staff",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Size = new Size(buttonWidth, buttonHeight),
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnManageStaff.FlatAppearance.BorderSize = 0;
            btnManageStaff.Click += btnManageStaff_Click;
            btnManageStaff.MouseEnter += (s, e) => btnManageStaff.BackColor = Color.SeaGreen;
            btnManageStaff.MouseLeave += (s, e) => btnManageStaff.BackColor = Color.MediumSeaGreen;

            btnLogout = new Button()
            {
                Text = "Back to Login",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Size = new Size(buttonWidth, buttonHeight),
                BackColor = Color.Orange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += btnLogout_Click;
            btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = Color.DarkOrange;
            btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = Color.Orange;

            // Center buttons horizontally next to each other
            int totalWidth = buttonWidth * 2 + spacingX;
            int startX = (Screen.PrimaryScreen.Bounds.Width - totalWidth) / 2;
            int buttonY = 200;

            btnManageStaff.Location = new Point(startX, buttonY);
            btnLogout.Location = new Point(startX + buttonWidth + spacingX, buttonY);

            panelContainer.Controls.Add(lblTitle);
            panelContainer.Controls.Add(btnManageStaff);
            panelContainer.Controls.Add(btnLogout);

            Controls.Add(panelContainer);

            // Full screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "Admin Dashboard";
        }

    }
}
