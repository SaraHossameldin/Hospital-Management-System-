using HMS.Admin_Functionalities;
using HMS.Login_Story;
using HMS.Registration;
using System;
using System.IO;
using System.Windows.Forms;

namespace HMS
{
    public partial class DoctorDashboard : Form
    {
        private readonly Staff _doctor;
        private readonly AuthService _auth;
        private readonly PatientService _patientService;
        private readonly StaffService _staffService;

        public DoctorDashboard(Staff doctor, AuthService auth, PatientService patientService, StaffService staffService)
        {
            InitializeComponent();

            _doctor = doctor;
            _auth = auth;
            _patientService = patientService;
            _staffService = staffService;

            // Set the form title to the doctor's name
            this.Text = $"Doctor Dashboard - Dr. {_doctor.Username}";
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            using var loginForm = new LoginForm(_auth, _patientService, _staffService);
            loginForm.ShowDialog();
            this.Close();
        }
    }
}

