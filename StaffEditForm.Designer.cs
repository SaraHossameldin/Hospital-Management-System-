using System;
using System.Drawing;
using System.Windows.Forms;

namespace HMS
{
    partial class StaffEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername, txtEmail, txtDepartment;
        private ComboBox cbRole;
        private Button btnSave;
        private Label lblRole, lblUsername, lblEmail, lblDepartment;
        private Panel panelMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelMain = new Panel();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            txtDepartment = new TextBox();
            cbRole = new ComboBox();
            btnSave = new Button();
            lblRole = new Label();
            lblUsername = new Label();
            lblEmail = new Label();
            lblDepartment = new Label();

            // Back Button
            Button btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Size = new Size(120, 50);
            btnBack.BackColor = Color.Gray;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnBack.Click += BtnBack_Click;

            SuspendLayout();

            // panelMain
            panelMain.Dock = DockStyle.Fill;
            panelMain.BackColor = Color.FromArgb(220, 240, 255); // soft light blue
            panelMain.Padding = new Padding(30);

            // Labels
            int labelWidth = 200;
            int controlWidth = 250;
            int controlHeight = 35;
            int startY = 30;
            int spacingY = 60;

            lblRole.Text = "Role:";
            lblRole.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(0, 60, 120);
            lblRole.Size = new Size(labelWidth, controlHeight);
            lblRole.Location = new Point(30, startY);

            lblUsername.Text = "Username:";
            lblUsername.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(0, 60, 120);
            lblUsername.Size = new Size(labelWidth, controlHeight);
            lblUsername.Location = new Point(30, startY + spacingY);

            lblEmail.Text = "Email:";
            lblEmail.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(0, 60, 120);
            lblEmail.Size = new Size(labelWidth, controlHeight);
            lblEmail.Location = new Point(30, startY + spacingY * 2);

            lblDepartment.Text = "Department:";
            lblDepartment.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblDepartment.ForeColor = Color.FromArgb(0, 60, 120);
            lblDepartment.Size = new Size(labelWidth, controlHeight);
            lblDepartment.Location = new Point(30, startY + spacingY * 3);

            // ComboBox
            cbRole.Items.AddRange(new object[] { "Admin", "Doctor", "Receptionist" });
            cbRole.Font = new Font("Segoe UI", 12);
            cbRole.BackColor = Color.White;
            cbRole.Size = new Size(controlWidth, controlHeight);
            cbRole.Location = new Point(lblRole.Right + 20, startY);

            // TextBoxes
            txtUsername.Font = new Font("Segoe UI", 12);
            txtUsername.BackColor = Color.White;
            txtUsername.Size = new Size(controlWidth, controlHeight);
            txtUsername.Location = new Point(lblUsername.Right + 20, startY + spacingY);

            txtEmail.Font = new Font("Segoe UI", 12);
            txtEmail.BackColor = Color.White;
            txtEmail.Size = new Size(controlWidth, controlHeight);
            txtEmail.Location = new Point(lblEmail.Right + 20, startY + spacingY * 2);

            txtDepartment.Font = new Font("Segoe UI", 12);
            txtDepartment.BackColor = Color.White;
            txtDepartment.Size = new Size(controlWidth, controlHeight);
            txtDepartment.Location = new Point(lblDepartment.Right + 20, startY + spacingY * 3);

            // Save Button
            btnSave.Text = "Save";
            btnSave.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSave.Size = new Size(140, 50);
            btnSave.BackColor = Color.MediumSeaGreen;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(lblDepartment.Right + 20, startY + spacingY * 4);
            btnSave.Click += btnSave_Click;

            // Back Button
            btnBack.Location = new Point(btnSave.Right + 20, startY + spacingY * 4);

            // Add controls to panel
            panelMain.Controls.Add(lblRole);
            panelMain.Controls.Add(cbRole);
            panelMain.Controls.Add(lblUsername);
            panelMain.Controls.Add(txtUsername);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblDepartment);
            panelMain.Controls.Add(txtDepartment);
            panelMain.Controls.Add(btnSave);
            panelMain.Controls.Add(btnBack);

            // Form
            Controls.Add(panelMain);
            ClientSize = new Size(600, 450);
            Text = "Edit Staff Member";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}

