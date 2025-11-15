using HMS.Admin_Functionalities;
using HMS.Login_Story;
using HMS.Registration;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HMS
{
    public partial class StaffManagementForm : Form
    {
        private readonly AuthService _authService;
        private readonly PatientService _patientService;
        private readonly StaffService _staffService;

        public StaffManagementForm(AuthService authService, PatientService patientService, StaffService staffService)
        {
            _authService = authService;
            _patientService = patientService;
            _staffService = staffService;

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            RefreshGrid();
        }

        public void RefreshGrid()
        {
            dgvStaff.DataSource = _staffService.GetAll()
                .Select(s => new
                {
                    s.StaffID,
                    s.Username,
                    s.Email,
                    s.Department,
                    Status = s.Status.ToString(),
                    Role = s.Role.ToString()
                })
                .ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new StaffEditForm(_staffService, this);
            if (form.ShowDialog() == DialogResult.OK) RefreshGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow == null) return;

            int id = (int)dgvStaff.CurrentRow.Cells[0].Value;
            Staff? staff = _staffService.GetById(id);
            if (staff == null) return;

            using var form = new StaffEditForm(_staffService, this, staff);
            if (form.ShowDialog() == DialogResult.OK) RefreshGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow == null) return;
            int id = (int)dgvStaff.CurrentRow.Cells[0].Value;
            _staffService.Delete(id);
            RefreshGrid();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            // Simply hide this form, show login form
            this.Hide();
            Application.OpenForms.OfType<LoginForm>().First().Show();
        }
    }
}
