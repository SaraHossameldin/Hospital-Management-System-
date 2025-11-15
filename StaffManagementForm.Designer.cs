using System;
using System.Drawing;
using System.Windows.Forms;

namespace HMS
{
    partial class StaffManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvStaff;
        private Button btnAdd, btnEdit, btnDelete, btnBackToLogin;
        private Panel panelTop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvStaff = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnBackToLogin = new Button();
            panelTop = new Panel();

            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            SuspendLayout();

            // Panel Top for buttons
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 70;
            panelTop.BackColor = Color.LightSteelBlue;
            panelTop.Padding = new Padding(10);

            // Buttons size and style
            Size btnSize = new Size(150, 45);
            Font btnFont = new Font("Segoe UI", 10, FontStyle.Bold);

            btnAdd.Size = btnSize;
            btnAdd.Text = "Add Staff Member";
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = btnFont;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += (s, e) => btnAdd.BackColor = Color.SeaGreen;
            btnAdd.MouseLeave += (s, e) => btnAdd.BackColor = Color.MediumSeaGreen;

            btnEdit.Size = btnSize;
            btnEdit.Text = "Edit Staff Member";
            btnEdit.BackColor = Color.CornflowerBlue;
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = btnFont;
            btnEdit.Click += btnEdit_Click;
            btnEdit.MouseEnter += (s, e) => btnEdit.BackColor = Color.RoyalBlue;
            btnEdit.MouseLeave += (s, e) => btnEdit.BackColor = Color.CornflowerBlue;

            btnDelete.Size = btnSize;
            btnDelete.Text = "Delete Staff Member";
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = btnFont;
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = Color.Red;
            btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = Color.IndianRed;

            btnBackToLogin.Size = btnSize;
            btnBackToLogin.Text = "Back to Login";
            btnBackToLogin.BackColor = Color.Orange;
            btnBackToLogin.ForeColor = Color.White;
            btnBackToLogin.FlatStyle = FlatStyle.Flat;
            btnBackToLogin.Font = btnFont;
            btnBackToLogin.Click += btnBackToLogin_Click;
            btnBackToLogin.MouseEnter += (s, e) => btnBackToLogin.BackColor = Color.DarkOrange;
            btnBackToLogin.MouseLeave += (s, e) => btnBackToLogin.BackColor = Color.Orange;

            // Arrange buttons horizontally in the panel
            int spacing = 20;
            btnAdd.Location = new Point(10, 10);
            btnEdit.Location = new Point(btnAdd.Right + spacing, 10);
            btnDelete.Location = new Point(btnEdit.Right + spacing, 10);
            btnBackToLogin.Location = new Point(btnDelete.Right + spacing, 10);

            panelTop.Controls.Add(btnAdd);
            panelTop.Controls.Add(btnEdit);
            panelTop.Controls.Add(btnDelete);
            panelTop.Controls.Add(btnBackToLogin);

            // DataGridView
            dgvStaff.Dock = DockStyle.Fill;
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.MultiSelect = false;
            dgvStaff.ReadOnly = true;
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.Font = new Font("Segoe UI", 10);
            dgvStaff.BackgroundColor = Color.White;

            // Form properties
            ClientSize = new Size(900, 500);
            Controls.Add(dgvStaff);
            Controls.Add(panelTop);
            Name = "StaffManagementForm";
            Text = "Staff Management";
            BackColor = Color.WhiteSmoke;
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            ResumeLayout(false);
        }
    }
}
