using System;
using System.Linq;
using System.Windows.Forms;
using HMS.Registration;

namespace HMS
{
    public partial class ReceptionistSearchForm : Form
    {
        private readonly PatientRepository _patientRepo;

        public ReceptionistSearchForm(PatientRepository repo)
        {
            InitializeComponent();
            _patientRepo = repo;

            // Load all patients initially
            LoadPatients();
        }

        // Load all or filtered patients
        private void LoadPatients(string keyword = "")
        {
            var patients = string.IsNullOrWhiteSpace(keyword)
                ? _patientRepo.GetAll().ToList()
                : _patientRepo.Search(keyword).ToList();

            if (patients.Any())
            {
                dgvResults.DataSource = patients
                    .Select(p => new { p.PatientID, p.FirstName, p.LastName, p.PhoneNumber, p.Email })
                    .ToList();
                lblMessage.Text = string.IsNullOrWhiteSpace(keyword)
                    ? $"{patients.Count} patients found"
                    : $"{patients.Count} results for \"{keyword}\"";
            }
            else
            {
                dgvResults.DataSource = null;
                lblMessage.Text = string.IsNullOrWhiteSpace(keyword)
                    ? "No patients found."
                    : $"No results for \"{keyword}\"";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text?.Trim();
            LoadPatients(kw);
        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResults.CurrentRow == null) return;

            int id = (int)dgvResults.CurrentRow.Cells["PatientID"].Value;
            var patient = _patientRepo.GetById(id);
            if (patient != null)
            {
                var detailsForm = new PatientDetailsForm(patient);
                detailsForm.ShowDialog();
            }
        }
    }
}
