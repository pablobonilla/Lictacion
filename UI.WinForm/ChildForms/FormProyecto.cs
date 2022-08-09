using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WinForm.ChildForms
{
    public partial class FormProyecto : Form
    {
        private Image defaultPhoto = Properties.Resources.defaultImageProfileUser;//Foto predeterminada para usuarios que no tienen una foto agregada.
        public FormProyecto()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=LOCALADMIN-PC;Initial Catalog=PLANPROSOFT;Integrated Security=True");

        private void FormProyecto_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT id_Proyecto, nombreProyecto,empresasA.nombreEmpresa, " +
                 "ministerioA.nombreMinisterio, montoApropiacion, montoGanador, proceso, garantiaSeriedadOferta, " +
                 "garantiaFielCumplimiento, porcientoAnticipo, numCopiasSobreA, numCopiasSobreB," +
                 "tiempoMantenimientoOferta,vigenciaPoliza,aperturaSobreA,aperturaSobreB,tiempoEjecucionObra," +
                 "diaVisitaObra,direccionVisitaObra,fechaEntregaSobreA,fechaEntregaSobreB,Fecha,Motivo, ProyectosA.id_Empresa, ProyectosA.id_Ministerio " +
                 "FROM ProyectosA JOIN empresasA ON empresasA.id_Empresa = ProyectosA.id_Empresa " +
                 "JOIN ministerioA ON ministerioA.id_Ministerio = ProyectosA.id_Ministerio WHERE proyectosA.estado ='ACTIVO'", conn);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen; //MediumSlateBlue

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "NOMBRE PROYECTO";
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].HeaderText = "EMPRESA";
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].HeaderText = "MINISTERIO";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            

            //dataGridView1.Columns[3].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].HeaderText = "DIRECCION";
            //dataGridView1.Columns[5].Width = 230;
            //dataGridView1.Columns[6].HeaderText = "TELEFONO";
            //dataGridView1.Columns[6].Width = 100;
            //dataGridView1.Columns[7].Visible = false;

            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildForms.FormProyectoMaintenance f3 = new ChildForms.FormProyectoMaintenance(); // Instantiate a Form3 object.
            f3.lblMsg.Text = "crear";
            f3.lblTitle.Text = "Creando Proyecto";
           // f3.txtFechaInicio.Text =  DateTime.Now.ToString("dd/MM/yyyy");
            f3.txtFechaInicio.Text = DateTime.Now.ToString();
            //f3.Show();
            f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            f3.ShowDialog();
        }

        private void FormProyecto_Activated(object sender, EventArgs e)
        {
            load_data();
        }

        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            load_data();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            {//Editar ministerio.
                if (dataGridView1.RowCount <= 0)
                {
                    MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dataGridView1.SelectedCells.Count > 1)
                {

                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string nombreProyecto= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string nombreEmpresa = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    string nombreMinisterio = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    string montoAprobacion = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    string montoGanador = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                    string proceso = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    string garantiaSeriedad = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    string garantiaFiel = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    string porcientoAnticipo = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    string copiasSobreA = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    string copiasSobreB = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                    string mantOferta = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    string vigencia = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    string aperturaSobreA = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                    string aperturaSobreB = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                    string tiempoEjecucionObra = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                    string diaVisitaObra = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                    string direccionVisitaObra = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                    string fechaEntregaSobreA = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                    string fechaEntregaSobreB = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                    string fechainicio = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
                    string motivo = dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
                    string id_Empresa = dataGridView1.SelectedRows[0].Cells[23].Value.ToString();
                    string id_Ministerio = dataGridView1.SelectedRows[0].Cells[24].Value.ToString();

                    ChildForms.FormProyectoMaintenance f3 = new ChildForms.FormProyectoMaintenance(); // Instantiate a Form3 object.
                                       
                    
                    f3.lblId.Text = id;
                    //f3.PictureBoxPhoto.Image = Image.FromFile(logo);

                    //if (logo.Length > 10)
                    //{
                    //    f3.PictureBoxPhoto.Image = new Bitmap(logo);
                    //}
                    //else
                    //    f3.PictureBoxPhoto.Image = new Bitmap(defaultPhoto); 
                    
                    
                    f3.txtNombre.Text = nombreProyecto;
                    f3.txtMinisterio.Text = nombreMinisterio;
                    f3.lblNombreEmpresa.Text = nombreEmpresa;
                    f3.LblNombreMinisterio.Text = nombreMinisterio;
                    f3.txtEmpresa.Text = nombreEmpresa;

                    f3.txtMontoApropiacion.Text = montoAprobacion;
                    f3.txtMontoGanador.Text = montoGanador;
                    f3.txtProceso.Text = proceso;
                    f3.txtSeriedad.Text = garantiaSeriedad;
                    f3.txtGarantiaFielCumplimiento.Text = garantiaFiel;
                  //  f3.txtGarantiaContrato.Text = gara;
                    f3.txtAnticipo.Text = porcientoAnticipo;
                    f3.txtCopiasSobreA.Text = copiasSobreA;
                    f3.txtCopiasSobreB.Text = copiasSobreB;
                    f3.txtTiempoOferta.Text = mantOferta;
                    f3.txtVigenciaPoliza.Text = vigencia;
                    f3.txtAperturaSobreA.Text = aperturaSobreA;
                    f3.txtAperturaSobreB.Text = aperturaSobreB;
                    f3.txtAnticipo.Text = porcientoAnticipo;
                    f3.txtTiempoEjecucion.Text= tiempoEjecucionObra;

                    f3.txtDiaVisita.Text = diaVisitaObra;
                    f3.txtDireccionVisita.Text = direccionVisitaObra;
                    f3.txtFechaInicio.Text = fechainicio;
                    f3.txtFechaEntregaSobreA.Text= fechaEntregaSobreA;
                    f3.txtFechaEntregaSobreB.Text = fechaEntregaSobreB;
                    f3.txtMotivo.Text = motivo;
                    f3.lblEmpresa.Text = id_Empresa;
                    f3.lblMinisterio.Text = id_Ministerio;

                    f3.lblMsg.Text = "editar";
                    f3.lblTitle.Text = "Editando Proyecto";
                    f3.btnSave.Text = "Actualizar";
                    
                    f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                    f3.ShowDialog();
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormProyecto_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter("SELECT id_Proyecto, nombreProyecto,empresasA.nombreEmpresa, " +
                "ministerioA.nombreMinisterio, montoApropiacion, montoGanador, proceso, garantiaSeriedadOferta, " +
                "garantiaFielCumplimiento, porcientoAnticipo, numCopiasSobreA, numCopiasSobreB," +
                "tiempoMantenimientoOferta,vigenciaPoliza,aperturaSobreA,aperturaSobreB,tiempoEjecucionObra," +
                "diaVisitaObra,direccionVisitaObra,fechaEntregaSobreA,fechaEntregaSobreB,Fecha,Motivo, ProyectosA.id_Empresa, ProyectosA.id_Ministerio " +
                "FROM ProyectosA JOIN empresasA ON empresasA.id_Empresa = ProyectosA.id_Empresa " +
                "JOIN ministerioA ON ministerioA.id_Ministerio = ProyectosA.id_Ministerio WHERE proyectosA.estado ='ACTIVO'", conn);

                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();
            }

            else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id_Proyecto, nombreProyecto,empresasA.nombreEmpresa, " +
                "ministerioA.nombreMinisterio, montoApropiacion, montoGanador, proceso, garantiaSeriedadOferta, " +
                "garantiaFielCumplimiento, porcientoAnticipo, numCopiasSobreA, numCopiasSobreB," +
                "tiempoMantenimientoOferta,vigenciaPoliza,aperturaSobreA,aperturaSobreB,tiempoEjecucionObra," +
                "diaVisitaObra,direccionVisitaObra,fechaEntregaSobreA,fechaEntregaSobreB,Fecha,Motivo, ProyectosA.id_Empresa, ProyectosA.id_Ministerio " +
                "FROM ProyectosA JOIN empresasA ON empresasA.id_Empresa = ProyectosA.id_Empresa " +
                "JOIN ministerioA ON ministerioA.id_Ministerio = ProyectosA.id_Ministerio WHERE proyectosA.estado ='ACTIVO' and nombreProyecto LIKE '%" + txtSearch.Text + "%' or proyectosA.estado ='ACTIVO' and empresasA.nombreEmpresa LIKE '%" + txtSearch.Text + "%' or proyectosA.estado ='ACTIVO' and ministerioA.nombreMinisterio LIKE '%" + txtSearch.Text + "%' ", conn);

                //SqlDataAdapter sda = new SqlDataAdapter("select * from ProyectoA where nombreMinisterio LIKE '%" + txtSearch.Text + "%'", conn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            {//Editar ministerio.
                if (dataGridView1.RowCount <= 0)
                {
                    MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dataGridView1.SelectedCells.Count > 1)
                {
                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string nombreProyecto = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string nombreEmpresa = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    string nombreMinisterio = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    string montoAprobacion = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    string montoGanador = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                    string proceso = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    string garantiaSeriedad = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    string garantiaFiel = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    string porcientoAnticipo = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    string copiasSobreA = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    string copiasSobreB = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                    string mantOferta = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    string vigencia = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    string aperturaSobreA = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                    string aperturaSobreB = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                    string tiempoEjecucionObra = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                    string diaVisitaObra = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                    string direccionVisitaObra = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                    string fechaEntregaSobreA = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                    string fechaEntregaSobreB = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                    string fechainicio = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
                    string motivo = dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
                    string id_Empresa = dataGridView1.SelectedRows[0].Cells[23].Value.ToString();
                    string id_Ministerio = dataGridView1.SelectedRows[0].Cells[24].Value.ToString();

                    ChildForms.FormProyectoMaintenance f3 = new ChildForms.FormProyectoMaintenance(); // Instantiate a Form3 object.


                    f3.lblId.Text = id;
                    //f3.PictureBoxPhoto.Image = Image.FromFile(logo);

                    //if (logo.Length > 10)
                    //{
                    //    f3.PictureBoxPhoto.Image = new Bitmap(logo);
                    //}
                    //else
                    //    f3.PictureBoxPhoto.Image = new Bitmap(defaultPhoto); 


                    f3.txtNombre.Text = nombreProyecto;
                    f3.txtMinisterio.Text = nombreMinisterio;
                    f3.lblNombreEmpresa.Text = nombreEmpresa;
                    f3.LblNombreMinisterio.Text = nombreMinisterio;
                    f3.txtEmpresa.Text = nombreEmpresa;

                    f3.txtMontoApropiacion.Text = montoAprobacion;
                    f3.txtMontoGanador.Text = montoGanador;
                    f3.txtProceso.Text = proceso;
                    f3.txtSeriedad.Text = garantiaSeriedad;
                    f3.txtGarantiaFielCumplimiento.Text = garantiaFiel;
                    //  f3.txtGarantiaContrato.Text = gara;
                    f3.txtAnticipo.Text = porcientoAnticipo;
                    f3.txtCopiasSobreA.Text = copiasSobreA;
                    f3.txtCopiasSobreB.Text = copiasSobreB;
                    f3.txtTiempoOferta.Text = mantOferta;
                    f3.txtVigenciaPoliza.Text = vigencia;
                    f3.txtAperturaSobreA.Text = aperturaSobreA;
                    f3.txtAperturaSobreB.Text = aperturaSobreB;
                    f3.txtAnticipo.Text = porcientoAnticipo;
                    f3.txtTiempoEjecucion.Text = tiempoEjecucionObra;

                    f3.txtDiaVisita.Text = diaVisitaObra;
                    f3.txtDireccionVisita.Text = direccionVisitaObra;
                    f3.txtFechaInicio.Text = fechainicio;
                    f3.txtFechaEntregaSobreA.Text = fechaEntregaSobreA;
                    f3.txtFechaEntregaSobreB.Text = fechaEntregaSobreB;
                    f3.txtMotivo.Text = motivo;
                    f3.lblEmpresa.Text = id_Empresa;
                    f3.lblMinisterio.Text = id_Ministerio;



                    f3.lblMsg.Text = "borrar";
                    f3.lblTitle.Text = "Eliminando Proyecto";
                    f3.btnSave.Text = "Eliminar";

                    


                    f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                    f3.ShowDialog();
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void FormProyecto_Load_1(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
