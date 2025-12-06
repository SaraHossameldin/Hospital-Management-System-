using HMS.Admin_Functionalities;
using HMS.Login_Story;
using HMS.Registration;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HMS.Appointment_Booking
{
    public partial class BookingForm : Form
    {
        private readonly Patient _patient;
        private readonly StaffRepository _staffRepo;
        private readonly DoctorAvailabilityService _availService;
        private readonly AppointmentService _apptService;
        private readonly IAppointmentRepository _apptRepo;

        // Only set when rescheduling
        private int? _reschedulingApptId = null;

        public BookingForm(
            Patient patient,
            StaffRepository staffRepo,
            DoctorAvailabilityService availService,
            AppointmentService apptService,
            IAppointmentRepository apptRepo)
        {
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _staffRepo = staffRepo ?? throw new ArgumentNullException(nameof(staffRepo));
            _availService = availService ?? throw new ArgumentNullException(nameof(availService));
            _apptService = apptService ?? throw new ArgumentNullException(nameof(apptService));
            _apptRepo = apptRepo ?? throw new ArgumentNullException(nameof(apptRepo));

            InitializeComponent();
            LoadSpecialties();
            LoadDoctorSlots();
        }

        public void SetReschedulingAppointment(int apptId)
        {
            _reschedulingApptId = apptId;
        }

        public void PreselectDoctor(int doctorId)
        {
            var doctor = _staffRepo.GetById(doctorId);
            if (doctor == null) return;

            if (!string.IsNullOrEmpty(doctor.Department))
            {
                if (!comboSpecialty.Items.Contains(doctor.Department))
                    comboSpecialty.Items.Add(doctor.Department);
                comboSpecialty.SelectedItem = doctor.Department;
            }

            LoadDoctorSlots(doctor.Department ?? "");

            for (int i = 0; i < dgvDoctorSlots.Rows.Count; i++)
            {
                var row = dgvDoctorSlots.Rows[i];
                if (row.IsNewRow) continue;
                if (row.Cells["StaffID"].Value is int id && id == doctorId)
                {
                    row.Selected = true;
                    dgvDoctorSlots.FirstDisplayedScrollingRowIndex = i;
                    return;
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (dgvDoctorSlots.CurrentRow == null)
            {
                MessageBox.Show("Please select a doctor and slot to book.", "Select slot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(dgvDoctorSlots.CurrentRow.Cells["StaffID"].Value?.ToString(), out int docId) ||
                !DateTime.TryParse(dgvDoctorSlots.CurrentRow.Cells["Start"].Value?.ToString(), out DateTime start) ||
                !DateTime.TryParse(dgvDoctorSlots.CurrentRow.Cells["End"].Value?.ToString(), out DateTime end))
            {
                MessageBox.Show("Selected row contains invalid slot data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = _apptService.BookAppointment(_patient.PatientID, docId, start, end);
            MessageBox.Show(result.Message, result.Success ? "Success" : "Error", MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (!result.Success) return;

            // If rescheduling, cancel old appointment
            if (_reschedulingApptId.HasValue)
            {
                var oldAppt = _apptRepo.GetById(_reschedulingApptId.Value);
                if (oldAppt != null)
                {
                    oldAppt.Status = "Cancelled";
                    _apptRepo.Update(oldAppt);
                }
                _reschedulingApptId = null;

                // Close modal BookingForm after reschedule
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Normal booking: refresh slots
                string specialtyFilter = comboSpecialty.SelectedItem?.ToString() ?? "";
                LoadDoctorSlots(specialtyFilter == "All Specialties" ? "" : specialtyFilter);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadSpecialties()
        {
            comboSpecialty.Items.Clear();

            string[] hardcodedSpecialties = new string[]
            {
                "All Specialties", "Cardiology", "Dermatology", "Neurology",
                "Pediatrics", "Orthopedics", "Radiology", "Health", "General Medicine"
            };

            comboSpecialty.Items.AddRange(hardcodedSpecialties);
            comboSpecialty.SelectedIndex = 0;

            comboSpecialty.SelectedIndexChanged -= ComboSpecialty_SelectedIndexChanged;
            comboSpecialty.SelectedIndexChanged += ComboSpecialty_SelectedIndexChanged;
        }

        private void ComboSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboSpecialty.SelectedItem?.ToString() ?? "";
            LoadDoctorSlots(selected == "All Specialties" ? "" : selected);
        }

        private void LoadDoctorSlots(string specialtyFilter = "")
        {
            try
            {
                var doctors = _staffRepo.GetAll()
                    .Where(d => d.Role == Role.Doctor && d.Status == StaffStatus.Active)
                    .ToList();

                if (!string.IsNullOrWhiteSpace(specialtyFilter))
                    doctors = doctors.Where(d => (d.Department ?? "").Equals(specialtyFilter, StringComparison.OrdinalIgnoreCase)).ToList();

                var combined = doctors.SelectMany(d =>
                    _availService.GetOpenSlots(d.StaffID, TimeSpan.FromMinutes(30))
                    .Select(s => new
                    {
                        d.StaffID,
                        DoctorName = $"Dr. {d.Username}",
                        Department = d.Department ?? "",
                        SlotDisplay = $"{s.start:ddd, MMM dd HH:mm} - {s.end:HH:mm}",
                        Start = s.start,
                        End = s.end
                    })
                ).OrderBy(x => x.Start).ToList();

                dgvDoctorSlots.DataSource = null;
                dgvDoctorSlots.AutoGenerateColumns = true;
                dgvDoctorSlots.DataSource = combined;

                if (dgvDoctorSlots.Columns.Contains("Start")) dgvDoctorSlots.Columns["Start"].Visible = false;
                if (dgvDoctorSlots.Columns.Contains("End")) dgvDoctorSlots.Columns["End"].Visible = false;
                if (dgvDoctorSlots.Columns.Contains("SlotDisplay")) dgvDoctorSlots.Columns["SlotDisplay"].HeaderText = "Slot";
                if (dgvDoctorSlots.Columns.Contains("DoctorName")) dgvDoctorSlots.Columns["DoctorName"].HeaderText = "Doctor";

                if (dgvDoctorSlots.Rows.Count > 0 && dgvDoctorSlots.CurrentRow == null)
                {
                    dgvDoctorSlots.Rows[0].Selected = true;
                    dgvDoctorSlots.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor slots: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMyAppointments_Click(object sender, EventArgs e)
        {
            using var myForm = new MyAppointmentsForm(_patient, _apptService, _apptRepo, _availService, _staffRepo);
            myForm.ShowDialog();
            // Refresh slots after returning
            LoadDoctorSlots(comboSpecialty.SelectedItem?.ToString() == "All Specialties" ? "" : comboSpecialty.SelectedItem?.ToString() ?? "");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string specialtyFilter = comboSpecialty.SelectedItem?.ToString() ?? "";
            LoadDoctorSlots(specialtyFilter == "All Specialties" ? "" : specialtyFilter);
        }
    }
}
