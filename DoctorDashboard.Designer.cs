using System;
using System.Drawing;
using System.Windows.Forms;

namespace HMS
{
    partial class DoctorDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Button btnAppointments;
        private Button btnPatientRecords;
        private Button btnPrescriptions;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            SuspendLayout();

            this.BackColor = Color.FromArgb(230, 245, 255);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            lblWelcome = new Label()
            {
                Text = "Welcome, Doctor",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 70, 140),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 120
            };

            Size btnSize = new Size(250, 60);
            Font btnFont = new Font("Segoe UI", 14, FontStyle.Bold);
            int spacing = 30;

            int centerX = (Screen.PrimaryScreen.Bounds.Width - btnSize.Width) / 2;
            int startY = lblWelcome.Bottom + 50;

            btnAppointments = new Button()
            {
                Text = "Appointments",
                Size = btnSize,
                Font = btnFont,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(centerX, startY)
            };
            btnAppointments.FlatAppearance.BorderSize = 0;
            btnAppointments.Click += BtnAppointments_Click;

            btnPatientRecords = new Button()
            {
                Text = "Patient Records",
                Size = btnSize,
                Font = btnFont,
                BackColor = Color.CornflowerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(centerX, startY + (btnSize.Height + spacing))
            };
            btnPatientRecords.FlatAppearance.BorderSize = 0;
            btnPatientRecords.Click += BtnPatientRecords_Click;

            btnPrescriptions = new Button()
            {
                Text = "Prescriptions",
                Size = btnSize,
                Font = btnFont,
                BackColor = Color.Orange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(centerX, startY + (btnSize.Height + spacing) * 2)
            };
            btnPrescriptions.FlatAppearance.BorderSize = 0;
            btnPrescriptions.Click += BtnPrescriptions_Click;

            btnLogout = new Button()
            {
                Text = "Logout",
                Size = btnSize,
                Font = btnFont,
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(centerX, startY + (btnSize.Height + spacing) * 3)
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += BtnLogout_Click;

            Controls.Add(lblWelcome);
            Controls.Add(btnAppointments);
            Controls.Add(btnPatientRecords);
            Controls.Add(btnPrescriptions);
            Controls.Add(btnLogout);

            ResumeLayout(false);
        }
        // Dummy event handlers
        private void BtnAppointments_Click(object sender, EventArgs e) { }
        private void BtnPatientRecords_Click(object sender, EventArgs e) { }
        private void BtnPrescriptions_Click(object sender, EventArgs e) { }
    }
}
