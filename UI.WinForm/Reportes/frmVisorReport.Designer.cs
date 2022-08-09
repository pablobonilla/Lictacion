namespace Procodesi
{
    partial class frmVisorReport
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
            this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
//            this.Listado_de_Clientes2 = new Procodesi.Reportes.Listado_de_Clientes();
  //          this.Listado_de_Clientes1 = new Procodesi.Reportes.Listado_de_Clientes();
            this.SuspendLayout();
            // 
            // reportDocument1
            // 
            this.reportDocument1.FileName = "rassdk://C:\\Proyectos\\Procodesi\\Procodesi\\Reportes\\Listado de Clientes.rpt";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(651, 529);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Listado_de_Clientes1
            // 
            //this.Listado_de_Clientes1.InitReport += new System.EventHandler(this.Listado_de_Clientes1_InitReport);
            // 
            // frmVisorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 529);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmVisorReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVisorReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVisorReport_Load);
            this.ResumeLayout(false);

        }

        #endregion
        //private COSA0800 COSA08001;
        //private Listado_de_Clientes Listado_de_Clientes1;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
       // private Reportes.Listado_de_Clientes Listado_de_Clientes1;
       // private Reportes.Listado_de_Clientes Listado_de_Clientes2;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}