using System;
using System.Linq;
using System.Windows.Forms;
using HMS.Admin_Functionalities;
using HMS.Registration;

namespace HMS.Appointment_Booking
{
    public partial class MyAppointmentsForm : Form
    {
        private readonly Patient _patient;
        private readonly AppointmentService _apptService;
        private readonly IAppointmentRepository _apptRepo;
        private readonly DoctorAvailabilityService _availService;
        private readonly StaffRepository _staffRepo;

        public MyAppointmentsForm(Patient patient, AppointmentService apptService, IAppointmentRepository apptRepo, DoctorAvailabilityService availService, StaffRepository staffRepo)
        {
            InitializeComponent();

            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _apptService = apptService ?? throw new ArgumentNullException(nameof(apptService));
            _apptRepo = apptRepo ?? throw new ArgumentNullException(nameof(apptRepo));
            _availService = availService ?? throw new ArgumentNullException(nameof(availService));
            _staffRepo = staffRepo ?? throw new ArgumentNullException(nameof(staffRepo));

            RefreshList();
        }

        public void RefreshList()
        {
            try
            {
                var list = _apptRepo.GetByPatient(_patient.PatientID)
                    .Where(a => a.Status == "Booked")
                    .OrderBy(a => a.StartAt)
                    .Select(a =>
                    {
                        var doctor = _staffRepo.GetById(a.DoctorID);
                        string docName = doctor != null ? $"Dr. {doctor.Username}" : "Unknown";
                        string dept = doctor != null ? doctor.Department : "Unknown";

                        return new
                        {
                            a.AppointmentID,
                            Doctor = docName,
                            Department = dept,
                            Date = $"{a.StartAt:ddd, MMM dd} {a.StartAt:HH:mm}-{a.EndAt:HH:mm}",
                            Start = a.StartAt,
                            End = a.EndAt,
                            Status = a.Status
                        };
                    })
                    .ToList();

                dgvMyAppointments.DataSource = null;
                dgvMyAppointments.AutoGenerateColumns = true;
                dgvMyAppointments.DataSource = list;

                if (dgvMyAppointments.Columns.Contains("AppointmentID"))
                    dgvMyAppointments.Columns["AppointmentID"].Visible = false;
                if (dgvMyAppointments.Columns.Contains("Start"))
                    dgvMyAppointments.Columns["Start"].Visible = false;
                if (dgvMyAppointments.Columns.Contains("End"))
                    dgvMyAppointments.Columns["End"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvMyAppointments.CurrentRow == null) return;

            if (!int.TryParse(dgvMyAppointments.CurrentRow.Cells["AppointmentID"].Value?.ToString(), out int id))
            {
                MessageBox.Show("Invalid appointment selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var res = _apptService.CancelAppointment(id, _patient.PatientID);
            MessageBox.Show(res.Message, res.Success ? "Canceled" : "Error", MessageBoxButtons.OK,
                res.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            RefreshList();
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dgvMyAppointments.CurrentRow.Cells["AppointmentID"].Value?.ToString(), out int apptId))
            {
                MessageBox.Show("Invalid appointment selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var appt = _apptRepo.GetById(apptId);
            if (appt == null)
            {
                MessageBox.Show("Appointment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshList();
                return;
            }

            using var bookingForm = new BookingForm(_patient, _staffRepo, _availService, _apptService, _apptRepo);
            bookingForm.SetReschedulingAppointment(apptId);
            bookingForm.PreselectDoctor(appt.DoctorID);

            var dr = bookingForm.ShowDialog();

            // Always refresh list after rescheduling
            RefreshList();
        }
    }
}
