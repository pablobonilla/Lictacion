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
    public partial class FormEmpresaMaintenance : Form
    {
        private Image defaultPhoto = Properties.Resources.defaultImageProfileUser;//Foto predeterminada para usuarios que no tienen una foto agregada.

        public FormEmpresaMaintenance()
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
            else if (txtDireccion.Text == "")
            {
                MessageBox.Show("DIRECCION EN BLANCO, CORRIJA POR FAVOR", "PlaProSoft.- Mensaje");
                txtEmail.Focus();
            }

            else if (email_bien_escrito(txtEmail.Text) == false)
            {
                MessageBox.Show("CORREO ELECTRÓNICO INCORRECTO, CORRIJA POR FAVOR", "PlaProSoft.- Mensaje");
                txtEmail.Focus();
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
                SqlDataAdapter sda = new SqlDataAdapter("insert into EmpresasA" +
                    "(nombreEmpresa,nombreLogo,rnc,rpe,direccion,telefono,nombreFiador,cedulaFiador, nombreRepresentanteLegal, correoEmpresa, enmiendas, nombreDirectorProyecto, cedulaDirector, nombreIngResidente1, cedulaIngResidente1, nombreIngResidente2, cedulaIngResidente2, nombreIngResidente3, cedulaIngResidente3, nombreSeguridad, cedulaSeguridad, nombreEncargadoOficinaT, cedulaEncargadoOficinaT, nombreEncargadoTopoG,nombreArqResidente1, cedulaArqResidente1, nombreArqResidente2, cedulaArqResidente2, nombreArqResidente3, cedulaArqResidente3, nombreAgeDesignado1, nombreAgeDesignado2,nombreAgeDesignado3,estado)" +
                    "values('" + txtNombre.Text + "','" + lblLogo.Text + "','" + txtRNC.Text + "','" + 
                    txtRPE.Text + "','" + txtDireccion.Text + "','" + txtPhone.Text + "','" + txtNombreFiador.Text + 
                    "','" + txtCedulaFiador.Text + "','" + txtRepreLegal.Text + "','" + txtEmail.Text + "','" + txtEnmiendas.Text + "','" + txtNombreDirector.Text + "','" + txtCedulaDirector.Text + "','" + txtNombreResidente1.Text + "','" + txtCedulaResidente1.Text + "','" + txtNombreResidente2.Text + "','" + txtCedulaResidente2.Text + "','" + txtNombreResidente3.Text + "','" + txtCedulaResidente3.Text + "','" + txtNombreEncSeg.Text + "','" + txtCedulaSeguridad.Text + "','" + txtNombreEncOficina.Text + "','" + txtCedulaOficina.Text + "','" + txtNombreTopo.Text + "','" + txtNombreArq1.Text + "','" +txtCedulaArq1.Text + "','" + txtNombreArq2.Text + "','" + txtCedulaArq2.Text + "','" + txtNombreArq3.Text + "','" + txtCedulaArq3.Text + "','" + txtNombreDesignado1.Text + "','" + txtNombreDesignado2.Text + "','" + txtNombreDesignado3.Text + "','" +

                    estado + "')", conn);

                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("REGISTRO GUARDADO EXITOSAMENTE. . . .","Mensaje");
                this.Close();
                ChildForms.FormEmpresa f3 = new ChildForms.FormEmpresa(); // Instantiate a Form3 object.
               
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
                               
                
                SqlDataAdapter sda = new SqlDataAdapter("UPDATE EmpresasA SET " +
                    "nombreEmpresa ='" + txtNombre.Text + 
                    "',direccion = '"  + txtDireccion.Text + "', telefono = '" + txtPhone.Text + 
                    "', nombreLogo = '" + lblLogo.Text + "', rnc ='" + txtRNC.Text + 
                    "',rpe = '" + txtRPE.Text + "',  nombreFiador = '" + txtNombreFiador.Text + 
                    "',cedulaFiador ='" + txtCedulaFiador.Text + "',nombreRepresentanteLegal = '" + txtRepreLegal.Text + 
                    "',  correoEmpresa = '" + txtEmail.Text + "', enmiendas ='" + txtEnmiendas.Text + 
                    "',nombreDirectorProyecto = '" + txtNombreDirector.Text +  "', cedulaDirector = '" + txtCedulaDirector.Text + 
                    "',nombreIngResidente1 ='" + txtNombreResidente1.Text + "',cedulaIngResidente1 = '" + txtCedulaResidente1.Text + 
                    "',nombreIngResidente2 = '" + txtNombreResidente2.Text + "',cedulaIngResidente2 ='" + txtCedulaResidente2.Text + 
                    "',cedulaIngResidente3 = '" + txtCedulaResidente3.Text + "',nombreIngResidente3 = '" + txtNombreResidente3.Text + 
                    "',nombreSeguridad ='" + txtNombreEncSeg.Text + "', cedulaSeguridad = '" + txtCedulaSeguridad.Text + 
                    "', nombreEncargadoOficinaT = '" + txtNombreEncOficina.Text + "', nombreEncargadoTopoG ='" + txtNombreTopo.Text + 
                    "', nombreArqResidente1 = '" + txtNombreResidente1.Text + "', cedulaArqResidente1 = '" + txtCedulaResidente1.Text +
                    "', nombreArqResidente2 = '" + txtNombreResidente2.Text + "', cedulaArqResidente2 = '" + txtCedulaResidente1.Text +
                    "', nombreArqResidente3 = '" + txtNombreResidente3.Text + "', cedulaArqResidente3 = '" + txtCedulaResidente3.Text +
                    "', nombreAgeDesignado1 = '" + txtNombreDesignado1.Text + "', nombreAgeDesignado2 = '" + txtNombreDesignado2.Text + 
                    "', nombreAgeDesignado3 = '" + txtNombreDesignado3.Text + "', cedulaEncargadoOficinaT ='" +txtCedulaOficina.Text  +        
                    "' where id_Empresa ='" + lblId.Text + "'", conn);
                                               
                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("REGISTRO ACTUALIZADO EXITOSAMENTE. . . .", "Mensaje");
                this.Close();
                ChildForms.FormMinisterio f3 = new ChildForms.FormMinisterio(); // Instantiate a Form3 object.

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
                SqlDataAdapter sda = new SqlDataAdapter("UPDATE EmpresasA SET " +
                    "estado ='" + estadoS + "' where id_Empresa ='" + lblId.Text + "'", conn);
                
                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();
                
                MessageBox.Show("REGISTRO BORRADO EXITOSAMENTE. . . .", "Mensaje");
                this.Close();
                ChildForms.FormMinisterio f3 = new ChildForms.FormMinisterio(); // Instantiate a Form3 object.

                f3.Refresh();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            {//Agregar una imagen al cuadro de imagen para la foto del usuario.
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Images(.jpg,.png)|*.png;*.jpg";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string dire = openFile.FileName;
                    lblLogo.Text = dire;
                    PictureBoxPhoto.Image = new Bitmap(openFile.FileName);
                }
            }
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            PictureBoxPhoto.Image = defaultPhoto;
            lblLogo.Text = "";
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
    }
}
