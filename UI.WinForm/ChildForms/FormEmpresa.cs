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
    public partial class FormEmpresa : Form
    {
        private Image defaultPhoto = Properties.Resources.defaultImageProfileUser;//Foto predeterminada para usuarios que no tienen una foto agregada.
        public FormEmpresa()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=LOCALADMIN-PC;Initial Catalog=PLANPROSOFT;Integrated Security=True");

        private void FormEmpresa_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {                                               
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from EmpresasA where estado ='ACTIVO' ", conn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; //MediumSlateBlue

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "NOMBRE";
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Visible = false;            
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[6].HeaderText = "E-MAIL";
            //dataGridView1.Columns[6].Width = 120;
            //dataGridView1.Columns[3].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].HeaderText = "DIRECCION";
            dataGridView1.Columns[6].Width = 230;
            dataGridView1.Columns[7].HeaderText = "TELEFONO";
            dataGridView1.Columns[7].Width = 100;
            //dataGridView1.Columns[7].Visible = false;
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
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[28].Visible = false;
            dataGridView1.Columns[29].Visible = false;
            dataGridView1.Columns[30].Visible = false;
            dataGridView1.Columns[31].Visible = false;
            dataGridView1.Columns[32].Visible = false;
            dataGridView1.Columns[33].Visible = false;
            dataGridView1.Columns[34].Visible = false;
            dataGridView1.Columns[35].Visible = false;

            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildForms.FormEmpresaMaintenance f3 = new ChildForms.FormEmpresaMaintenance(); // Instantiate a Form3 object.
            f3.lblMsg.Text = "crear";
            f3.lblTitle.Text = "Creando Empresa";
            //f3.Show();
            f3.ShowDialog();
            f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
        }

        private void FormEmpresa_Activated(object sender, EventArgs e)
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
            {//Editar Empresa.
                if (dataGridView1.RowCount <= 0)
                {
                    MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dataGridView1.SelectedCells.Count > 1)
                {

                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string logo = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    string rnc = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    string rpe = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    string direccion = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    string telefono = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

                    string nombreFiador = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    string cedulaFiador = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    string nombreRepresentanteLegal = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    string email = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                    string enmiendas = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    string nombreDirectorProyecto = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    string cedulaDirector = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();

                    string nombreIngResidente1 = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                    string cedulaIngResidente1 = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                    string nombreIngResidente2 = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                    string cedulaIngResidente2 = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                    string nombreIngResidente3 = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                    string cedulaIngResidente3 = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                    string nombreSeguridad = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
                    string cedulaSeguridad = dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
                    string nombreEncargadoOficinaT = dataGridView1.SelectedRows[0].Cells[23].Value.ToString();

                    string cedulaEncargadoOficinaT = dataGridView1.SelectedRows[0].Cells[24].Value.ToString();
                    string nombreEncargadoTopoG = dataGridView1.SelectedRows[0].Cells[25].Value.ToString();
                    string nombreArqResidente1 = dataGridView1.SelectedRows[0].Cells[26].Value.ToString();
                    string cedulaArqResidente1 = dataGridView1.SelectedRows[0].Cells[27].Value.ToString();
                    string nombreArqResidente2 = dataGridView1.SelectedRows[0].Cells[28].Value.ToString();
                    string cedulaArqResidente2 = dataGridView1.SelectedRows[0].Cells[29].Value.ToString();
                    string cedulaArqResidente3 = dataGridView1.SelectedRows[0].Cells[30].Value.ToString();
                    string nombreArqResidente3 = dataGridView1.SelectedRows[0].Cells[31].Value.ToString();
                    string nombreAgeDesignado1 = dataGridView1.SelectedRows[0].Cells[32].Value.ToString();
                    string nombreAgeDesignado2 = dataGridView1.SelectedRows[0].Cells[33].Value.ToString();
                    string nombreAgeDesignado3 = dataGridView1.SelectedRows[0].Cells[34].Value.ToString();


                    ChildForms.FormEmpresaMaintenance f3 = new ChildForms.FormEmpresaMaintenance(); // Instantiate a Form3 object.

                    
                    
                    f3.lblId.Text = id;
                    //f3.PictureBoxPhoto.Image = Image.FromFile(logo);

                    if (logo.Length > 10)
                    {
                        f3.PictureBoxPhoto.Image = new Bitmap(logo);
                    }
                    else
                        f3.PictureBoxPhoto.Image = new Bitmap(defaultPhoto); 
                    
                    f3.lblLogo.Text = logo;
                    f3.txtNombre.Text = nombre;
                    f3.txtEmail.Text = email;
                    f3.txtDireccion.Text = direccion;
                    f3.txtPhone.Text = telefono;
                    f3.txtRNC.Text = rnc;
                    f3.txtRPE.Text = rpe;
                    f3.txtNombreFiador.Text = nombreFiador;
                    f3.txtCedulaFiador.Text = cedulaFiador;
                    f3.txtRepreLegal.Text = nombreRepresentanteLegal;
                    f3.txtEmail.Text = email;
                    f3.txtEnmiendas.Text = enmiendas;
                    f3.txtNombreDirector.Text = nombreDirectorProyecto;
                    f3.txtCedulaDirector.Text = cedulaDirector;
                    f3.txtNombreResidente1.Text = nombreIngResidente1;
                    f3.txtNombreResidente2.Text = nombreIngResidente2;
                    f3.txtNombreResidente3.Text = nombreIngResidente3;
                    f3.txtCedulaResidente1.Text = cedulaIngResidente1;
                    f3.txtCedulaResidente2.Text = cedulaIngResidente2;
                    f3.txtCedulaResidente3.Text = cedulaIngResidente3;
                    f3.txtCedulaArq1.Text = cedulaArqResidente1;
                    f3.txtCedulaArq2.Text = cedulaArqResidente2;
                    f3.txtCedulaArq3.Text = cedulaArqResidente3;
                    f3.txtNombreArq1.Text = nombreArqResidente1;
                    f3.txtNombreArq2.Text = nombreArqResidente2;
                    f3.txtNombreArq3.Text = nombreArqResidente3;
                    f3.txtNombreEncSeg.Text = nombreSeguridad;
                    f3.txtCedulaSeguridad.Text = cedulaSeguridad;
                    f3.txtNombreEncOficina.Text = nombreEncargadoOficinaT;
                    f3.txtCedulaOficina.Text = cedulaEncargadoOficinaT;
                    f3.txtNombreTopo.Text = nombreEncargadoTopoG;

                    f3.txtNombreResidente1.Text = nombreArqResidente1;
                    f3.txtCedulaResidente1.Text = cedulaArqResidente1;
                    f3.txtNombreResidente2.Text = nombreArqResidente2;
                    f3.txtCedulaResidente2.Text = cedulaArqResidente2;
                    f3.txtNombreResidente3.Text = nombreArqResidente3;
                    f3.txtCedulaResidente3.Text = cedulaArqResidente3;
                    f3.txtNombreDesignado1.Text = nombreAgeDesignado1;
                    f3.txtNombreDesignado2.Text = nombreAgeDesignado2;
                    f3.txtNombreDesignado3.Text = nombreAgeDesignado3;

                    f3.lblMsg.Text = "editar";
                    f3.lblTitle.Text = "Editando Empresa";
                    f3.btnSave.Text = "Actualizar";
                    
                    f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                    f3.ShowDialog();
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormEmpresa_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from EmpresasA WHERE estado ='ACTIVO' ", conn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();
            }

            else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from EmpresasA where nombreEmpresa LIKE '%" + txtSearch.Text + "%'", conn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            {//Editar Empresa.
                if (dataGridView1.RowCount <= 0)
                {
                    MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dataGridView1.SelectedCells.Count > 1)
                {

                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string logo = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    string rnc = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    string rpe = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();                                                                                          
                    string direccion = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    string telefono = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

                    string nombreFiador = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    string cedulaFiador = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    string nombreRepresentanteLegal = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    string email = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                    string enmiendas = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    string nombreDirectorProyecto = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    string cedulaDirector = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();

                    string nombreIngResidente1 = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                    string cedulaIngResidente1 = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                    string nombreIngResidente2 = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                    string cedulaIngResidente2 = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                    string nombreIngResidente3 = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                    string cedulaIngResidente3 = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                    string nombreSeguridad = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
                    string cedulaSeguridad = dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
                    string nombreEncargadoOficinaT = dataGridView1.SelectedRows[0].Cells[23].Value.ToString();

                    string cedulaEncargadoOficinaT = dataGridView1.SelectedRows[0].Cells[24].Value.ToString();
                    string nombreEncargadoTopoG = dataGridView1.SelectedRows[0].Cells[25].Value.ToString();
                    string nombreArqResidente1 = dataGridView1.SelectedRows[0].Cells[26].Value.ToString();
                    string cedulaArqResidente1 = dataGridView1.SelectedRows[0].Cells[27].Value.ToString();
                    string nombreArqResidente2 = dataGridView1.SelectedRows[0].Cells[28].Value.ToString();
                    string cedulaArqResidente2 = dataGridView1.SelectedRows[0].Cells[29].Value.ToString();
                    string cedulaArqResidente3 = dataGridView1.SelectedRows[0].Cells[30].Value.ToString();
                    string nombreArqResidente3 = dataGridView1.SelectedRows[0].Cells[31].Value.ToString();
                    string nombreAgeDesignado1= dataGridView1.SelectedRows[0].Cells[32].Value.ToString();
                    string nombreAgeDesignado2 = dataGridView1.SelectedRows[0].Cells[33].Value.ToString();
                    string nombreAgeDesignado3 = dataGridView1.SelectedRows[0].Cells[34].Value.ToString();
                                        

                    ChildForms.FormEmpresaMaintenance f3 = new ChildForms.FormEmpresaMaintenance(); // Instantiate a Form3 object.
                    //f3.Show();
                    
                    f3.lblId.Text = id;
                    f3.txtNombre.Text = nombre;
                    f3.txtEmail.Text = email;
                    f3.txtDireccion.Text = direccion;
                    f3.txtPhone.Text = telefono;

                    f3.lblMsg.Text = "borrar";
                    f3.lblTitle.Text = "Eliminando Empresa";
                    f3.btnSave.Text = "Eliminar";

                    if (logo.Length > 10)
                    {
                        f3.PictureBoxPhoto.Image = new Bitmap(logo);
                    }
                    else
                        f3.PictureBoxPhoto.Image = new Bitmap(defaultPhoto);

                    f3.txtRNC.Text = rnc;
                    f3.txtNombreFiador.Text = nombreFiador;
                    f3.txtCedulaFiador.Text = cedulaFiador;
                    f3.txtRepreLegal.Text = nombreRepresentanteLegal;


                    f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                    f3.ShowDialog();
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
