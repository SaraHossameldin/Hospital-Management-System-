using HMS.Admin_Functionalities;
using HMS.Login_Story;
using HMS.Registration;
using System;
using System.Windows.Forms;

namespace HMS
{
    public partial class AdminDashboard : Form
    {
        private readonly StaffService _staffService;
        private readonly AuthService _authService;
        private readonly PatientService _patientService;

        public AdminDashboard(AuthService authService, PatientService patientService, StaffService staffService)
        {
            InitializeComponent();
            _staffService = staffService;
            _authService = authService;
            _patientService = patientService;
            this.WindowState = FormWindowState.Maximized;
        }

        private StaffManagementForm? _staffForm = null;

        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            if (_staffForm == null || _staffForm.IsDisposed)
            {
                _staffForm = new StaffManagementForm(_authService, _patientService, _staffService);
                _staffForm.FormClosed += (s, args) => this.Show();
            }

            _staffForm.Show();
            this.Hide();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_authService, _patientService, _staffService);
            loginForm.Show();
            this.Close();
        }
    }
}

