using System;
using System.Linq;
using System.Windows.Forms;
using HMS.Admin_Functionalities;

namespace HMS.Doctor_Availability
{
    public partial class DoctorAvailabilityForm : Form
    {
        private readonly Staff _doctor;
        private readonly DoctorAvailabilityService _availService;
        private readonly TimeSpan _slotLength = TimeSpan.FromMinutes(30);

        public DoctorAvailabilityForm(Staff doctor, DoctorAvailabilityService availService)
        {
            InitializeComponent();
            _doctor = doctor;
            _availService = availService;
            lblDoctorName.Text = $"Dr. {_doctor.Username}";
            RefreshList();
        }

        private void btnAddAvailability_Click(object sender, EventArgs e)
        {
            var date = datePicker.Value.Date;
            var startTime = date.Add(pickerStart.Value.TimeOfDay);
            var endTime = date.Add(pickerEnd.Value.TimeOfDay);

            var avail = new DoctorAvailability
            {
                DoctorID = _doctor.StaffID,
                StartAt = startTime,
                EndAt = endTime,
                IsAvailable = true
            };

            var r = _availService.AddAvailability(avail);
            MessageBox.Show(r.Message);
            if (r.Success) RefreshList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAvailabilities.CurrentRow == null) return;
            var id = (int)dgvAvailabilities.CurrentRow.Cells["AvailabilityID"].Value;
            var r = _availService.RemoveAvailability(id);
            MessageBox.Show(r.Message);
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                // Use the new method to get raw availabilities
                var availabilities = _availService.GetRawAvailabilities(_doctor.StaffID)
                    .OrderBy(a => a.StartAt)
                    .ToList();

                // Map for display
                var displayList = availabilities.Select(a => new
                {
                    a.AvailabilityID,
                    Start = a.StartAt,
                    End = a.EndAt,
                    SlotDisplay = $"{a.StartAt:ddd, MMM dd HH:mm} - {a.EndAt:HH:mm}"
                }).ToList();

                dgvAvailabilities.DataSource = null;
                dgvAvailabilities.DataSource = displayList;

                // Hide raw Start/End columns
                if (dgvAvailabilities.Columns["Start"] != null)
                    dgvAvailabilities.Columns["Start"].Visible = false;
                if (dgvAvailabilities.Columns["End"] != null)
                    dgvAvailabilities.Columns["End"].Visible = false;

                if (!displayList.Any())
                    MessageBox.Show("No availabilities found for this doctor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading availabilities: {ex.Message}");
            }
        }


    }
}


