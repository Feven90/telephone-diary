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

namespace TelephoneDiary
{
    public partial class Phone : Form
    {
        SqlConnection con = new SqlConnection("Data Source =.\\sqlexpress2012; Integrated Security = True"); // the database name is (./sqlexpress2012) because of the back slash at the beginning it gives error so just added another back slash to escap that
        public Phone()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open(); //sqlDataAdapter 
            SqlCommand cmd = new SqlCommand("INSERT INTO Mobile (Fname, Lname, Mobile, Email, Catagory) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", con);  //sqlcommand- to send data to the database(insert, update and delete), (sqlDataReader to read data from DB), sqlDataAdapter (to do both read and write on database)(it is slower than the other two)
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully saved .....!");
            Display();
            
        }
        
        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Mobile",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; //we can clear textbox both this way or using Clear()
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1; // to show empty record 
            textBox1.Focus();
        }

        private void Phone_Load(object sender, EventArgs e)
        {
            Display(); // when we run the program all saved data will be displayed 
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e) // properties of grid view, click events at top right, go to mouse click and double click // this will fill the text boxes when we click on a row from the grid
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open(); //sqlDataAdapter 
            SqlCommand cmd = new SqlCommand("DELETE FROM Mobile WHERE (Mobile = '" + textBox3.Text + "')", con); // textBox3.Text - this text box is for Mobile which is the primary key 
            //sqlcommand- to send data to the database(insert, update and delete), (sqlDataReader to read data from DB), sqlDataAdapter (to do both read and write on database)(it is slower than the other two)

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully deleted .....!");
            Display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open(); //sqlDataAdapter 
            SqlCommand cmd = new SqlCommand(@"UPDATE Mobile SET Fname= '"+ textBox1.Text + "', Lname ='" +textBox2.Text + "', Mobile ='" + textBox3.Text + "' , " +
                "Email = '" + textBox4.Text + "', Catagory = '" + comboBox1.Text + "' WHERE (Mobile = '"+ textBox3.Text + "')", con); // textBox3.Text - this text box is for Mobile which is the primary key 
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully  .....!");
            Display();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Mobile Where Mobile like '%" + textBox5.Text + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();


            }
        }

    }
}
