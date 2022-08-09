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
    public partial class FormMinisterio : Form
    {
        private Image defaultPhoto = Properties.Resources.defaultImageProfileUser;//Foto predeterminada para usuarios que no tienen una foto agregada.
        public FormMinisterio()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=LOCALADMIN-PC;Initial Catalog=PLANPROSOFT;Integrated Security=True");

        private void FormMinisterio_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from MinisterioA where estado ='ACTIVO' ", conn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "NOMBRE";
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].HeaderText = "E-MAIL";
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "DIRECCION";
            dataGridView1.Columns[5].Width = 230;
            dataGridView1.Columns[6].HeaderText = "TELEFONO";
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Visible = false;

            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildForms.FormMinisterioMaintenance f3 = new ChildForms.FormMinisterioMaintenance(); // Instantiate a Form3 object.
            f3.lblMsg.Text = "crear";
            f3.lblTitle.Text = "Creando Ministerio";
            //f3.Show();
            f3.ShowDialog();
            f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
        }

        private void FormMinisterio_Activated(object sender, EventArgs e)
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
                    string nombre= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string email = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    string direccion = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    string telefono = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    string logo = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                    
                    ChildForms.FormMinisterioMaintenance f3 = new ChildForms.FormMinisterioMaintenance(); // Instantiate a Form3 object.

                    
                    
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

                    f3.lblMsg.Text = "editar";
                    f3.lblTitle.Text = "Editando Ministerio";
                    f3.btnSave.Text = "Actualizar";
                    
                    f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                    f3.ShowDialog();
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormMinisterio_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from MinisterioA WHERE estado ='ACTIVO' ", conn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();
            }

            else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from MinisterioA where nombreMinisterio LIKE '%" + txtSearch.Text + "%'", conn);
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
                    string nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string email = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    string direccion = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    string telefono = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    string logo = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                                        
                    ChildForms.FormMinisterioMaintenance f3 = new ChildForms.FormMinisterioMaintenance(); // Instantiate a Form3 object.
                    //f3.Show();
                    
                    f3.lblId.Text = id;
                    f3.txtNombre.Text = nombre;
                    f3.txtEmail.Text = email;
                    f3.txtDireccion.Text = direccion;
                    f3.txtPhone.Text = telefono;

                    f3.lblMsg.Text = "borrar";
                    f3.lblTitle.Text = "Eliminando Ministerio";
                    f3.btnSave.Text = "Eliminar";

                    if (logo.Length > 10)
                    {
                        f3.PictureBoxPhoto.Image = new Bitmap(logo);
                    }
                    else
                        f3.PictureBoxPhoto.Image = new Bitmap(defaultPhoto);



                    f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                    f3.ShowDialog();
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
