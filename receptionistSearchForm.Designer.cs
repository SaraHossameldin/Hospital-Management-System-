namespace HMS
{
    partial class ReceptionistSearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 23);
            this.txtSearch.TabIndex = 0;
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(430, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // lstResults
            //
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 15;
            this.lstResults.Location = new System.Drawing.Point(12, 50);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(760, 379);
            this.lstResults.TabIndex = 2;
            this.lstResults.DoubleClick += new System.EventHandler(this.lstResults_DoubleClick);
            //
            // ReceptionistSearchForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "ReceptionistSearchForm";
            this.Text = "Search Patients";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}