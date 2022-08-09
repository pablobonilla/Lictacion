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
    public partial class FormMinisterioMaintenance : Form
    {
        private Image defaultPhoto = Properties.Resources.defaultImageProfileUser;//Foto predeterminada para usuarios que no tienen una foto agregada.

        public FormMinisterioMaintenance()
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
                SqlDataAdapter sda = new SqlDataAdapter("insert into MinisterioA" +
                    "(nombreMinisterio,email,direccion,telefono,estado,nombreLogo)" +
                    "values('" + txtNombre.Text + "','" + txtEmail.Text + "','" + txtDireccion.Text + "','" + txtPhone.Text + "','" + estado + "','" + lblLogo.Text + "')", conn);

                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("REGISTRO GUARDADO EXITOSAMENTE. . . .");
                this.Close();
                ChildForms.FormMinisterio f3 = new ChildForms.FormMinisterio(); // Instantiate a Form3 object.
               
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
                               
                
                SqlDataAdapter sda = new SqlDataAdapter("UPDATE MinisterioA SET " +
                    "nombreMinisterio ='" + txtNombre.Text + "',email = '" + txtEmail.Text + "',direccion = '"
                    + txtDireccion.Text + "', telefono = '" + txtPhone.Text + "', nombreLogo = '" + lblLogo.Text + "' where id_Ministerio ='" + lblId.Text + "'", conn);
                                
                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("REGISTRO ACTUALIZADO EXITOSAMENTE. . . .");
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
                SqlDataAdapter sda = new SqlDataAdapter("UPDATE MinisterioA SET " +
                    "estado ='" + estadoS + "' where id_Ministerio ='" + lblId.Text + "'", conn);
                
                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();
                
                MessageBox.Show("REGISTRO BORRADO EXITOSAMENTE. . . .");
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
    }
}
