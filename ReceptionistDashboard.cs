using HMS.Registration;
using System;
using System.Windows.Forms;

namespace HMS
{
    public partial class ReceptionistDashboard : Form
    {
        private readonly PatientRepository _patientRepo;

        public ReceptionistDashboard(PatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            new ReceptionistSearchForm(_patientRepo).Show();
            this.Hide();
        }

    }
}
