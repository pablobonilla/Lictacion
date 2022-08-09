using CrystalDecisions.CrystalReports.Engine;
using Procodesi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WinForm.ChildForms
{
    public partial class FormCalendar : Form
    {
        public FormCalendar()
        {
            InitializeComponent();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CrearTablaEmpresas();
            //ReportDocument cryRpt = new ReportDocument();

            //// cryRpt.Load(@"D:\C# Demos\Crystal Reports\CrystalReportDemo\CrystalReportDemo\CrystalReport1.rpt");
            //cryRpt.Load(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Listado de Empresas.rpt");
            frmVisorReport f = new frmVisorReport();
            f.crystalReportViewer1.ReportSource = @"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Reporte de Proyectos.rpt";
            //f.crystalReportViewer1.RefreshReport();
            f.ShowDialog(this);
            Cursor.Current = Cursors.Default;

            //// crystalReportViewer1.ReportSource = cryRpt;

            ////crystalReportViewer1.Refresh();

            //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"X:\ASD.pdf");

            //MessageBox.Show("Exported Successful");

            Cursor.Current = Cursors.Default;
        }

        public void CrearTablaEmpresas()
        {

            // Delete a file by using File class static method...
            if (System.IO.File.Exists(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\empresas.xml"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\empresas.xml");
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
            }

            SqlConnection conn = new SqlConnection(@"Data Source=LOCALADMIN-PC;Initial Catalog=PLANPROSOFT;Integrated Security=True");
            conn.Open();
            //string strSQL = "Select * from empresas";
            string strSQL = "SELECT id_Proyecto, nombreProyecto,empresasA.nombreEmpresa, " +
                "ministerioA.nombreMinisterio, montoApropiacion, montoGanador, proceso, garantiaSeriedadOferta, " +
                "garantiaFielCumplimiento, porcientoAnticipo, numCopiasSobreA, numCopiasSobreB," +
                "tiempoMantenimientoOferta,vigenciaPoliza,aperturaSobreA,aperturaSobreB,tiempoEjecucionObra," +
                "diaVisitaObra,direccionVisitaObra,fechaEntregaSobreA,fechaEntregaSobreB,Fecha,Motivo, ProyectosA.id_Empresa, ProyectosA.id_Ministerio " +
                "FROM ProyectosA JOIN empresasA ON empresasA.id_Empresa = ProyectosA.id_Empresa " +
                "JOIN ministerioA ON ministerioA.id_Ministerio = ProyectosA.id_Ministerio WHERE proyectosA.estado ='ACTIVO'";

            SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //ds.WriteXml(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\empresas.xml");
            ds.WriteXml(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\proyectos.xml");

            conn.Close();


            //conn.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("select * from EmpresasA WHERE estado ='ACTIVO' ", conn);
            //DataTable data = new DataTable();
            //sda.Fill(data);
            //dataGridView1.DataSource = data;
            //

            //operation oper = new operation();
            //DataSet ds = oper.ExDataSet(" SELECT * FROM COMERCIAL.COSA0800");
            //ds.Tables[0].WriteXml(@"C:\Proyectos\Procodesi\Procodesi\Reportes\COSA0800.xml");

        }
    }
}
