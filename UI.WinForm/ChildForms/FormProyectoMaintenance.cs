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
using System.Text.RegularExpressions;
using UI.WinForm.Utils;

namespace UI.WinForm.ChildForms
{
    public partial class FormProyectoMaintenance : Form
    {
        private Image defaultPhoto = Properties.Resources.defaultImageProfileUser;//Foto predeterminada para usuarios que no tienen una foto agregada.

        public FormProyectoMaintenance()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LOCALADMIN-PC;Initial Catalog=PLANPROSOFT;Integrated Security=True");
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("NOMBRE EN BLANCO, CORRIJA POR FAVOR", "PlaProSoft.- Mensaje");
                txtNombre.Focus();
            }
            else if(txtMinisterio.Text == "  Seleccionar Ministerio") { 
                MessageBox.Show("DEBES SELECCIONAR UN MINISTERIO", "PlaProSoft.- Mensaje");
                txtMinisterio.Focus();
            }
            //  Seleccionar Empresa
            else if (txtEmpresa.Text == "  Seleccionar Empresa")
            {
                MessageBox.Show("DEBES SELECCIONAR UNA EMPRESA", "PlaProSoft.- Mensaje");
                txtEmpresa.Focus();
            }


            else
                if (lblMsg.Text == "editar")
                {
                    editarDatos();
                }
                else if (lblMsg.Text == "crear")
                {
                    guardarDatos();
                }

                else if (lblMsg.Text == "borrar")
                {
                    borrarDatos();
                }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Form3 f3 = new Form3(); // Instantiate a Form3 object.
            //f3.Show(); // Show Form3 and
            this.Close(); // closes the Form2 instance.
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";


            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        void guardarDatos()
        {
            try
            {
                string estado = "ACTIVO";

                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("insert into ProyectosA" +
                    "(nombreProyecto,montoApropiacion,montoGanador,id_Ministerio,proceso,garantiaSeriedadOferta,garantiaFielCumplimiento,porcientoAnticipo, numCopiasSobreA, numCopiasSobreB, tiempoMantenimientoOferta, vigenciaPoliza, aperturaSobreA, aperturaSobreB, tiempoEjecucionObra, diaVisitaObra, fechaEntregaSobreA, fechaEntregaSobreB, Fecha, Motivo, id_Empresa, estado)" +
                    "values('" + txtNombre.Text + "','" + txtMontoApropiacion.Text + "','" + txtMontoGanador.Text + "','" +
                    lblMinisterio.Text + "','" + txtProceso.Text + "','" + txtSeriedad.Text + "','" + txtGarantiaFielCumplimiento.Text +
                    "','" + txtAnticipo.Text + "','" + txtCopiasSobreA.Text + "','" + txtCopiasSobreB.Text + "','" + txtTiempoOferta.Text + "','" + txtVigenciaPoliza.Text + "','" + txtAperturaSobreA.Text + "','" + txtAperturaSobreB.Text + "','" + txtTiempoEjecucion.Text + "','" + txtDiaVisita.Text + "','" + txtFechaEntregaSobreA.Text + "','" + txtFechaEntregaSobreB.Text + "','" + txtFechaInicio.Text + "','" + txtMotivo.Text + "','" + lblEmpresa.Text + "','" +
                    estado + "')", conn);

                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("REGISTRO GUARDADO EXITOSAMENTE. . . .","Mensaje");
                this.Close();
                ChildForms.FormProyecto f3 = new ChildForms.FormProyecto(); // Instantiate a Form3 object.
               
                f3.Refresh();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        void editarDatos()
        {
            try
            {
                //string estado = "ACTIVO";

                conn.Close();
                conn.Open();

                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //PictureBoxPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);


                SqlDataAdapter sda = new SqlDataAdapter("UPDATE ProyectosA SET " +
                    "nombreProyecto ='" + txtNombre.Text +
                    "',montoApropiacion = '" + txtMontoApropiacion.Text + "', montoGanador = '" + txtMontoGanador.Text +
                    "', id_Ministerio = '" + lblMinisterio.Text + "', proceso ='" + txtProceso.Text +
                    "',garantiaSeriedadOferta = '" + txtSeriedad.Text + "',  garantiaFielCumplimiento = '" + txtGarantiaFielCumplimiento.Text +
                    "',porcientoAnticipo ='" + txtAnticipo.Text + "',numCopiasSobreA = '" + txtCopiasSobreA.Text +
                    "',numCopiasSobreB = '" + txtCopiasSobreB.Text + "', tiempoMantenimientoOferta ='" + txtTiempoOferta.Text +
                    "',vigenciaPoliza = '" + txtVigenciaPoliza.Text + "', aperturaSobreA = '" + txtAperturaSobreA.Text +
                    "',aperturaSobreB ='" + txtAperturaSobreB.Text + "',tiempoEjecucionObra = '" + txtTiempoEjecucion.Text +
                    "',diaVisitaObra = '" + txtDiaVisita.Text + "',direccionVisitaObra ='" + txtDireccionVisita.Text +
                    "',fechaEntregaSobreA = '" + txtFechaEntregaSobreA.Text + "',fechaEntregaSobreB = '" + txtFechaEntregaSobreB.Text +
                    "',Fecha ='" + txtFechaInicio.Text + "', Motivo = '" + txtMotivo.Text +
                    "', id_Empresa = '" + lblEmpresa.Text + 
                    "' where id_Proyecto ='" + lblId.Text + "'", conn);

                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("REGISTRO ACTUALIZADO EXITOSAMENTE. . . .", "Mensaje");
                this.Close();
                ChildForms.FormProyecto f3 = new ChildForms.FormProyecto(); // Instantiate a Form3 object.

                f3.Refresh();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        void borrarDatos()
        {
            try
            {
               
                conn.Open();
                string estadoS = "INACTIVO";
                SqlDataAdapter sda = new SqlDataAdapter("UPDATE ProyectosA SET " +
                    "estado ='" + estadoS + "' where id_Proyecto ='" + lblId.Text + "'", conn);
                
                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();
                
                MessageBox.Show("REGISTRO BORRADO EXITOSAMENTE. . . .", "Mensaje");
                this.Close();
                ChildForms.FormProyecto f3 = new ChildForms.FormProyecto(); // Instantiate a Form3 object.

                f3.Refresh();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormProyectoMaintenance_Load(object sender, EventArgs e)
        {
            llenarCombos();
        }


        void llenarCombos()
        {
           
            conn.Open();
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombreMinisterio, id_Ministerio FROM MinisterioA where estado = 'ACTIVO' ORDER BY nombreMinisterio", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtMinisterio.DataSource = dt; // setting the datasource property of combobox
            txtMinisterio.DisplayMember = "nombreMinisterio"; // Display Member which will display on screen
            txtMinisterio.ValueMember = "id_Ministerio";
            //lblMinisterio.Text = txtMinisterio.ValueMember;

            conn.Close();

            conn.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT nombreEmpresa, id_Empresa FROM EmpresasA where estado = 'ACTIVO' ORDER BY nombreEmpresa", conn);
            DataTable dt1= new DataTable();
            da1.Fill(dt1);
            txtEmpresa.DataSource = dt1; // setting the datasource property of combobox
            txtEmpresa.DisplayMember = "nombreEmpresa"; // Display Member which will display on screen
            txtEmpresa.ValueMember = "id_Empresa";
            //lblMinisterio.Text = txtMinisterio.ValueMember;

            conn.Close();

            if (lblMsg.Text == "editar" || lblMsg.Text == "borrar")
            {

                txtMinisterio.Text = LblNombreMinisterio.Text;
                txtEmpresa.Text = lblNombreEmpresa.Text;
            }



        }

        private void txtMinisterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMinisterio.Text= txtMinisterio.SelectedValue.ToString();
        }

        private void txtEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEmpresa.Text = txtEmpresa.SelectedValue.ToString();
        }
    }
}
