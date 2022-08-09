using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Procodesi
{
    public partial class frmVisorReport : Form
    {
        public frmVisorReport()
        {
            InitializeComponent();
        }

        private void frmVisorReport_Load(object sender, EventArgs e)
        {
            generarTabla();
            ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load(@"C:\Proyectos\Procodesi\Procodesi\bin\Debug\Reportes\Listado de Clientes.rpt");
            //crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.RefreshReport();
            crystalReportViewer1.Refresh();
        }

        private void Listado_de_Clientes1_InitReport(object sender, EventArgs e)
        {

        }

        void generarTabla()
        {
            // Delete a file by using File class static method...
            if (System.IO.File.Exists(@"C:\Proyectos\Procodesi\Procodesi\Reportes\COSA0800.xml"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"C:\Proyectos\Procodesi\Procodesi\Reportes\COSA0800.xml");

                    

                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
            }

            //operation oper = new operation();
            //DataSet ds = oper.ExDataSet(" SELECT * FROM COMERCIAL.COSA0800");
            //ds.Tables[0].WriteXml(@"C:\Proyectos\Procodesi\Procodesi\Reportes\COSA0800.xml");



        }
    }
}
