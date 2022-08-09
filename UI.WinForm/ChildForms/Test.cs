using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UI.WinForm.ChildForms
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        // connection string :

        SqlConnection conn = new SqlConnection(@"Data Source=LOCALADMIN-PC;Initial Catalog=PLANPROSOFT;Integrated Security=True");
        //connectionString = "Server=(local);DataBase= MyCompanyTest; integrated security= true";//Establecer la cadena de conexión.
        //save data in database :-)

        private void btnsave_Click(object sender, EventArgs e)
        {
            
            if (txtid.Text == "" || txtname.Text == "" || txtsalery.Text == "" || txttax.Text == "" || txtage.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("please fill the cell first");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("insert into Register(id,name,gender,salery,age,tax)values('" + txtid.Text + "','" + txtname.Text + "','" + comboBox1.Text + "','" + txtsalery.Text + "','" + txtage.Text + "','" + txttax.Text + "')", conn);

                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("data entered succesfully. . . .");
                    panel1.Enabled = false;

                }
            
        }
        // view the data in datagridview :-)

        private void btnview_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            //conn.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("select * from Register",conn);
            //DataTable data = new DataTable();
            //sda.Fill(data);
            //dataGridView1.DataSource = data;
            load_data();
            //conn.Close();

            
        }

        private void load_data()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from ministerio", conn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            conn.Close();
        }
        // double click event for updating and deleting the data from database :-)

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            panel1.Enabled = true;
            txtid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtsalery.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtage.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txttax.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();


        }
        //update the data :-)

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (panel1.Enabled == true)
            {

                if (txtid.Text == "" || txtname.Text == "" || txtsalery.Text == "" || txttax.Text == "" || txtage.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("please fill the cell first");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("UPDATE Register SET id ='" + txtid.Text + "',name = '" + txtname.Text + "',Gender = '" + comboBox1.Text + "', Salery = '" + txtsalery.Text + "',age = '" + txtage.Text + "',tax = '" + txttax.Text + "' where id ='" + txtid.Text + "'", conn);

                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("data updated succesfully. . . .");
                    load_data();
                    panel1.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("please select what you want to update");
            }
           
            
        }

        //delete btn c0ding :-)

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (panel1.Enabled == true)
            {

                if (txtid.Text == "" || txtname.Text == "" || txtsalery.Text == "" || txttax.Text == "" || txtage.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("please select the record");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("delete from Register where id ='" + txtid.Text + "'", conn);

                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("data deleted succesfully. . . .");
                    load_data();
                    panel1.Enabled = false; 
                }
               
            }
            else
            {
                MessageBox.Show("please select the record first");
            }
           
        }

        //to insert the new entry :-*

        private void btnnew_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = false;
            panel1.Enabled = true;
            
            txtid.Text = "";
            txtname.Text = "";
            txtsalery.Text = "";
            txtage.Text = "";
            txttax.Text = "";
            comboBox1.Text = "";
        }

        //search the data from database by name :-*

        private void srchbtn_Click(object sender, EventArgs e)
        {

            if (txtnamesrch.Text == "")
            {
                MessageBox.Show("cells are empty");
            }
            
            else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Register where name LIKE '%"+txtnamesrch.Text+"%'", conn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
