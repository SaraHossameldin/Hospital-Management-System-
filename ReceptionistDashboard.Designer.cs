using System;
using System.Windows.Forms;
using System.Drawing;

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
            btnSearchPatient.Location = new Point(444, 322);
            btnSearchPatient.Size = new Size(214, 67);
            btnSearchPatient.Text = "Search for Patient";
            btnSearchPatient.Click += btnSearchPatient_Click;
            Controls.Add(btnSearchPatient);
            // 
            // ReceptionistDashboard
            // 
            ClientSize = new Size(1143, 750);
            Text = "Receptionist Dashboard";
            ResumeLayout(false);
        }
    }
}

