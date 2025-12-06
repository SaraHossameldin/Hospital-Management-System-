using System.Windows.Forms;

namespace HMS.Appointment_Booking
{
    partial class BookingForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvDoctorSlots;
        private ComboBox comboSpecialty;
        private Button btnFilter;
        private Button btnBook;
        private Button btnMyAppointments;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dgvDoctorSlots = new DataGridView();
            this.comboSpecialty = new ComboBox();
            this.btnFilter = new Button();
            this.btnBook = new Button();
            this.btnMyAppointments = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorSlots)).BeginInit();
            this.SuspendLayout();

            // comboSpecialty
            this.comboSpecialty.Location = new System.Drawing.Point(20, 20);
            this.comboSpecialty.Size = new System.Drawing.Size(200, 25);

            // btnFilter
            this.btnFilter.Location = new System.Drawing.Point(230, 20);
            this.btnFilter.Size = new System.Drawing.Size(100, 35);
            this.btnFilter.Text = "Filter";
            this.btnFilter.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.FlatStyle = FlatStyle.Flat;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // dgvDoctorSlots
            this.dgvDoctorSlots.Location = new System.Drawing.Point(20, 60);
            this.dgvDoctorSlots.Size = new System.Drawing.Size(1500, 800);
            this.dgvDoctorSlots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctorSlots.ReadOnly = true;
            this.dgvDoctorSlots.MultiSelect = false;
            this.dgvDoctorSlots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // btnBook
            this.btnBook.Location = new System.Drawing.Point(20, 900);
            this.btnBook.Size = new System.Drawing.Size(180, 40);
            this.btnBook.Text = "Book Appointment";
            this.btnBook.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.FlatStyle = FlatStyle.Flat;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);

            // btnMyAppointments
            this.btnMyAppointments.Location = new System.Drawing.Point(220, 900);
            this.btnMyAppointments.Size = new System.Drawing.Size(180, 40);
            this.btnMyAppointments.Text = "My Appointments";
            this.btnMyAppointments.BackColor = System.Drawing.Color.MediumPurple;
            this.btnMyAppointments.ForeColor = System.Drawing.Color.White;
            this.btnMyAppointments.FlatStyle = FlatStyle.Flat;
            this.btnMyAppointments.FlatAppearance.BorderSize = 0;
            this.btnMyAppointments.Click += new System.EventHandler(this.btnMyAppointments_Click);

            // BookingForm
            this.ClientSize = new System.Drawing.Size(2000, 1000);
            this.Controls.Add(this.comboSpecialty);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dgvDoctorSlots);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnMyAppointments);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Booking Form";

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorSlots)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
