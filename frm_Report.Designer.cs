namespace InfoGuns
{
    partial class frm_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.WeaponsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InfoBaseDataSet = new InfoGuns.InfoBaseDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.WeaponsTableAdapter = new InfoGuns.InfoBaseDataSetTableAdapters.WeaponsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.WeaponsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoBaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // WeaponsBindingSource
            // 
            this.WeaponsBindingSource.DataMember = "Weapons";
            this.WeaponsBindingSource.DataSource = this.InfoBaseDataSet;
            // 
            // InfoBaseDataSet
            // 
            this.InfoBaseDataSet.DataSetName = "InfoBaseDataSet";
            this.InfoBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.WeaponsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InfoGuns.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(600, 366);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // WeaponsTableAdapter
            // 
            this.WeaponsTableAdapter.ClearBeforeFill = true;
            // 
            // frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frm_Report";
            this.Text = "frm_Report";
            this.Load += new System.EventHandler(this.frm_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WeaponsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoBaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource WeaponsBindingSource;
        private InfoBaseDataSet InfoBaseDataSet;
        private InfoBaseDataSetTableAdapters.WeaponsTableAdapter WeaponsTableAdapter;
    }
}