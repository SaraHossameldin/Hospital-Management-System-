using System.Drawing;
using System.Windows.Forms;

namespace HMS.Appointment_Booking
{
    partial class MyAppointmentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvMyAppointments;
        private Button btnCancel;
        private Button btnReschedule;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            dgvMyAppointments = new DataGridView();
            btnCancel = new Button();
            btnReschedule = new Button();

            this.SuspendLayout();

            // DataGridView
            dgvMyAppointments.Location = new Point(20, 20);
            dgvMyAppointments.Size = new Size(1000, 400); // taller to show multiple rows
            dgvMyAppointments.ReadOnly = true;
            dgvMyAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyAppointments.MultiSelect = false;
            dgvMyAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyAppointments.AllowUserToAddRows = false;
            dgvMyAppointments.AllowUserToDeleteRows = false;
            dgvMyAppointments.RowHeadersVisible = false;
            dgvMyAppointments.Font = new Font("Segoe UI", 10);

            // Cancel button
            btnCancel.Location = new Point(20, 440);
            btnCancel.Size = new Size(180, 45);
            btnCancel.Text = "Cancel Appointment";
            btnCancel.BackColor = Color.OrangeRed;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            btnCancel.MouseEnter += (s, e) => { btnCancel.BackColor = Color.DarkRed; };
            btnCancel.MouseLeave += (s, e) => { btnCancel.BackColor = Color.OrangeRed; };

            // Reschedule button
            btnReschedule.Location = new Point(220, 440);
            btnReschedule.Size = new Size(200, 45);
            btnReschedule.Text = "Reschedule Appointment";
            btnReschedule.BackColor = Color.DodgerBlue;
            btnReschedule.ForeColor = Color.White;
            btnReschedule.FlatStyle = FlatStyle.Flat;
            btnReschedule.FlatAppearance.BorderSize = 0;
            btnReschedule.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReschedule.Click += new System.EventHandler(this.btnReschedule_Click);
            btnReschedule.MouseEnter += (s, e) => { btnReschedule.BackColor = Color.RoyalBlue; };
            btnReschedule.MouseLeave += (s, e) => { btnReschedule.BackColor = Color.DodgerBlue; };

            // Form
            this.ClientSize = new Size(2000, 1000); // fits content nicely
            this.Controls.Add(dgvMyAppointments);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnReschedule);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "My Appointments";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.ResumeLayout(false);
        }
    }
}
