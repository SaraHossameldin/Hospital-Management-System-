using System.Windows.Forms;

namespace HMS.Doctor_Availability
{
    partial class DoctorAvailabilityForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblDoctorName;
        private DataGridView dgvAvailabilities;
        private DateTimePicker datePicker;
        private DateTimePicker pickerStart;
        private DateTimePicker pickerEnd;
        private Button btnAddAvailability;
        private Button btnRemove;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDoctorName = new Label();
            this.datePicker = new DateTimePicker();
            this.pickerStart = new DateTimePicker();
            this.pickerEnd = new DateTimePicker();
            this.btnAddAvailability = new Button();
            this.btnRemove = new Button();
            this.dgvAvailabilities = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailabilities)).BeginInit();
            this.SuspendLayout();

            // lblDoctorName
            this.lblDoctorName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblDoctorName.ForeColor = Color.MediumBlue;
            this.lblDoctorName.Location = new Point(20, 20);
            this.lblDoctorName.Size = new Size(this.ClientSize.Width - 40, 50);
            this.lblDoctorName.TextAlign = ContentAlignment.MiddleLeft;
            this.lblDoctorName.BringToFront();

            // datePicker
            this.datePicker.Format = DateTimePickerFormat.Short;
            this.datePicker.Location = new Point(20, 80);
            this.datePicker.Width = 150;

            // pickerStart
            this.pickerStart.Format = DateTimePickerFormat.Time;
            this.pickerStart.ShowUpDown = true;
            this.pickerStart.Location = new Point(180, 80);
            this.pickerStart.Width = 180;

            // pickerEnd
            this.pickerEnd.Format = DateTimePickerFormat.Time;
            this.pickerEnd.ShowUpDown = true;
            this.pickerEnd.Location = new Point(380, 80);
            this.pickerEnd.Width = 180;

            // btnAddAvailability
            this.btnAddAvailability.Text = "Add Availability";
            this.btnAddAvailability.BackColor = Color.SlateBlue;
            this.btnAddAvailability.ForeColor = Color.White;
            this.btnAddAvailability.Location = new Point(600, 80);
            this.btnAddAvailability.Size = new Size(180, 40);
            this.btnAddAvailability.Click += btnAddAvailability_Click;

            // btnRemove
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.BackColor = Color.IndianRed;
            this.btnRemove.ForeColor = Color.White;
            this.btnRemove.Location = new Point(800, 80);
            this.btnRemove.Size = new Size(180, 40);
            this.btnRemove.Click += btnRemove_Click;

            // dgvAvailabilities
            this.dgvAvailabilities.Location = new Point(20, 150);
            this.dgvAvailabilities.Size = new Size(1700, 900);
            this.dgvAvailabilities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailabilities.ReadOnly = true;
            this.dgvAvailabilities.MultiSelect = false;
            this.dgvAvailabilities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Form
            this.ClientSize = new Size(2000, 450);
            this.Controls.Add(this.lblDoctorName);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.pickerStart);
            this.Controls.Add(this.pickerEnd);
            this.Controls.Add(this.btnAddAvailability);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dgvAvailabilities);
            this.Text = "Doctor Availability";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailabilities)).EndInit();
            this.ResumeLayout(false);
        }


        #endregion
    }
}
