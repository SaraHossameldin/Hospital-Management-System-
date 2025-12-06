using System.Drawing;
using System.Windows.Forms;

namespace HMS
{
    partial class ReceptionistDashboard
    {
        private Button btnSearchPatient;

        private void InitializeComponent()
        {
            btnSearchPatient = new Button();
            SuspendLayout();

            // 
            // btnSearchPatient
            // 
            btnSearchPatient.Text = "Search for Patient";
            btnSearchPatient.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearchPatient.BackColor = Color.MediumSlateBlue;
            btnSearchPatient.ForeColor = Color.White;
            btnSearchPatient.FlatStyle = FlatStyle.Flat;
            btnSearchPatient.FlatAppearance.BorderSize = 0;
            btnSearchPatient.Size = new Size(250, 50);
            btnSearchPatient.Location = new Point(60, 50);
            btnSearchPatient.Cursor = Cursors.Hand;
            btnSearchPatient.Click += btnSearchPatient_Click;
            btnSearchPatient.MouseEnter += (s, e) => btnSearchPatient.BackColor = Color.SlateBlue;
            btnSearchPatient.MouseLeave += (s, e) => btnSearchPatient.BackColor = Color.MediumSlateBlue;

            // 
            // ReceptionistDashboard
            // 
            ClientSize = new Size(300, 150);  // compact window
            Controls.Add(btnSearchPatient);
            Text = "Receptionist Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.WhiteSmoke; // modern look
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            ResumeLayout(false);
        }
    }
}
