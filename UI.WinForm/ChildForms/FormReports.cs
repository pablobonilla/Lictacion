using Procodesi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WinForm.ChildForms
{
    public partial class FormReports : Form
    {
        public FormReports()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel1.LinkVisited = true;

           
            string url2 = System.Environment.CurrentDirectory;
            string ruta = url2 + "\\"+"Lugar y fecha.pdf";
            System.Diagnostics.Process.Start(ruta);

            
        }

        private void VisitLink2()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel1.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            string url3 = System.Environment.CurrentDirectory;
            string ruta2 = url3 + "\\" + "Garantia Seriedad Oferta.pdf";
            System.Diagnostics.Process.Start(ruta2);


            //System.Diagnostics.Process.Start(@"C:\Users\LocalAdmin\Downloads\PlaProSoft-20220708T234017Z-001\PlaProSoft\LayeredFullLogin-CS-SQL\Lugar y fecha.pdf");
            //C: \Users\LocalAdmin\Downloads\Desktop
        }



        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CrearTablaEmpresas();
            //CrearTablaMinisterio();

            //ReportDocument cryRpt = new ReportDocument();

            //// cryRpt.Load(@"D:\C# Demos\Crystal Reports\CrystalReportDemo\CrystalReportDemo\CrystalReport1.rpt");
            //cryRpt.Load(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Listado de Empresas.rpt");
            frmVisorReport f = new frmVisorReport();
           f.crystalReportViewer1.ReportSource = @"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Listado de Empresas.rpt";
            //f.crystalReportViewer1.ReportSource = @"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Reporte de Proyectos.rpt";
            //f.crystalReportViewer1.RefreshReport();
            f.ShowDialog(this);
            //Cursor.Current = Cursors.Default;

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
            string strSQL = "Select * from empresasA WHERE estado ='ACTIVO'";
            //string strSQL = "SELECT id_Proyecto, nombreProyecto,empresasA.nombreEmpresa, " +
            //    "ministerioA.nombreMinisterio, montoApropiacion, montoGanador, proceso, garantiaSeriedadOferta, " +
            //    "garantiaFielCumplimiento, porcientoAnticipo, numCopiasSobreA, numCopiasSobreB," +
            //    "tiempoMantenimientoOferta,vigenciaPoliza,aperturaSobreA,aperturaSobreB,tiempoEjecucionObra," +
            //    "diaVisitaObra,direccionVisitaObra,fechaEntregaSobreA,fechaEntregaSobreB,Fecha,Motivo, ProyectosA.id_Empresa, ProyectosA.id_Ministerio " +
            //    "FROM ProyectosA JOIN empresasA ON empresasA.id_Empresa = ProyectosA.id_Empresa " +
            //    "JOIN ministerioA ON ministerioA.id_Ministerio = ProyectosA.id_Ministerio WHERE proyectosA.estado ='ACTIVO'";

            SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.WriteXml(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\empresas.xml");
            //ds.WriteXml(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\proyectos.xml");

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

        public void CrearTablaMinisterio()
        {

            // Delete a file by using File class static method...
            if (System.IO.File.Exists(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Ministerio.xml"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Ministerio.xml");
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
            }

            SqlConnection conn = new SqlConnection(@"Data Source=LOCALADMIN-PC;Initial Catalog=PLANPROSOFT;Integrated Security=True");
            conn.Open();
            string strSQL = "Select * from MinisterioA";
            //string strSQL = "SELECT id_Proyecto, nombreProyecto,empresasA.nombreEmpresa, " +
            //    "ministerioA.nombreMinisterio, montoApropiacion, montoGanador, proceso, garantiaSeriedadOferta, " +
            //    "garantiaFielCumplimiento, porcientoAnticipo, numCopiasSobreA, numCopiasSobreB," +
            //    "tiempoMantenimientoOferta,vigenciaPoliza,aperturaSobreA,aperturaSobreB,tiempoEjecucionObra," +
            //    "diaVisitaObra,direccionVisitaObra,fechaEntregaSobreA,fechaEntregaSobreB,Fecha,Motivo, ProyectosA.id_Empresa, ProyectosA.id_Ministerio " +
            //    "FROM ProyectosA JOIN empresasA ON empresasA.id_Empresa = ProyectosA.id_Empresa " +
            //    "JOIN ministerioA ON ministerioA.id_Ministerio = ProyectosA.id_Ministerio WHERE proyectosA.estado ='ACTIVO'";

            SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.WriteXml(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\MinisterioA.xml");
            //ds.WriteXml(@"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\proyectos.xml");

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
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            frmVisorReport f = new frmVisorReport();
            //f.crystalReportViewer1.ReportSource = @"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Criterio Evaluación-Exp. Empres.rpt";
            f.crystalReportViewer1.ReportSource = @"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Criterio Evaluación-Equipos.rpt";
            //f.crystalReportViewer1.RefreshReport();
            f.ShowDialog(this);
            Cursor.Current = Cursors.Default;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmVisorReport f = new frmVisorReport();
            
            f.crystalReportViewer1.ReportSource = @"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\Criterio Evaluación-Exp. Empres.rpt";
            //f.crystalReportViewer1.RefreshReport();
            f.ShowDialog(this);

            Cursor.Current = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                string url2 = @"C:\Proyectos\PlaProSoft\LayeredFullLogin-CS-SQL\UI.WinForm\Reportes\";
                openFileDialog.InitialDirectory = url2;
                //openFileDialog.InitialDirectory = "c:\\";

                //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|Images - pdf files (*.png, *.jpg, *.ico)|*.png;*.jpg;*.ico;*.pdf|pdf files (*.pdf)|*.pdf";

                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true; 

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    System.Diagnostics.Process.Start(filePath);

                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }


        }

        
    }
}
