using HMS.Registration;
using System;
using System.Windows.Forms;

namespace HMS
{
    public partial class ReceptionistDashboard : Form
    {
        private readonly PatientService _patientService;

        public ReceptionistDashboard(PatientService patientService)
        {
            _patientService = patientService;
            InitializeComponent(); // calls the Designer code
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            new ReceptionistSearchForm(_patientService).Show();
            this.Hide();
        }
    }
}
