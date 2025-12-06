using System.Drawing;
using System.Windows.Forms;

namespace HMS
{
    partial class ReceptionistSearchForm
    {
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvResults;
        private Label lblMessage;

        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvResults = new DataGridView();
            lblMessage = new Label();

            ((System.ComponentModel.ISupportInitialize)(dgvResults)).BeginInit();
            SuspendLayout();

            // txtSearch
            txtSearch.Location = new Point(20, 20);
            txtSearch.Size = new Size(400, 25);
            txtSearch.Font = new Font("Segoe UI", 10);

            // btnSearch
            btnSearch.Location = new Point(440, 18);
            btnSearch.Size = new Size(90, 40);
            btnSearch.Text = "Search";
            btnSearch.BackColor = Color.MediumSeaGreen;
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += btnSearch_Click;
            btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = Color.SeaGreen;
            btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = Color.MediumSeaGreen;

            // lblMessage
            lblMessage.Location = new Point(550, 20);
            lblMessage.Size = new Size(200, 25);
            lblMessage.Font = new Font("Segoe UI", 10);
            lblMessage.Text = "";

            // dgvResults
            dgvResults.Location = new Point(20, 60);
            dgvResults.Size = new Size(760, 400);
            dgvResults.ReadOnly = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.CellDoubleClick += dgvResults_CellDoubleClick;

            // Form
            ClientSize = new Size(800, 480);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(lblMessage);
            Controls.Add(dgvResults);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search Patients";

            ((System.ComponentModel.ISupportInitialize)(dgvResults)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
