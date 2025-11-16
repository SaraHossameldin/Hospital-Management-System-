using HMS.Registration;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HMS
{
    public partial class ReceptionistSearchForm : Form
    {
        private readonly PatientService _patientService;

        public ReceptionistSearchForm(PatientService patientService)
        {
            _patientService = patientService;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var results = _patientService.Search(txtSearch.Text.Trim()).ToList();
            lstResults.Items.Clear();
            if (!results.Any())
            {
                lstResults.Items.Add("No records found");
                return;
            }

            foreach (var p in results)
                lstResults.Items.Add($"{p.PatientID} | {p.Username} | {p.FirstName} {p.LastName}");
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem == null || lstResults.SelectedItem.ToString() == "No records found") return;

            var id = int.Parse(lstResults.SelectedItem.ToString().Split('|')[0].Trim());
            var p = _patientService.GetById(id);
            if (p != null) new PatientDetailsForm(p).ShowDialog();
        }
    }
}
