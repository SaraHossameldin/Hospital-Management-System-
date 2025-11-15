using HMS.Admin_Functionalities;
using HMS.Login_Story;
using System;
using System.Windows.Forms;

namespace HMS
{
    public partial class StaffEditForm : Form
    {
        private readonly StaffService _staffService;
        private readonly Staff? _editing;
        private readonly StaffManagementForm _parentForm;

        public StaffEditForm(StaffService staffService, StaffManagementForm parentForm, Staff? editing = null)
        {
            _staffService = staffService;
            _parentForm = parentForm;
            _editing = editing;

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            if (_editing != null)
            {
                txtUsername.Text = _editing.Username;
                txtEmail.Text = _editing.Email;
                txtDepartment.Text = _editing.Department;
                cbRole.SelectedItem = _editing.Role.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_editing == null)
            {
                var newStaff = new Staff
                {
                    Username = txtUsername.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Department = txtDepartment.Text.Trim(),
                    Role = Enum.Parse<Role>(cbRole.SelectedItem?.ToString() ?? "Receptionist"),
                    Status = StaffStatus.Inactive
                };
                _staffService.Add(newStaff);
            }
            else
            {
                _editing.Username = txtUsername.Text.Trim();
                _editing.Email = txtEmail.Text.Trim();
                _editing.Department = txtDepartment.Text.Trim();
                _editing.Role = Enum.Parse<Role>(cbRole.SelectedItem?.ToString() ?? "Receptionist");

                _staffService.Update(_editing);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
