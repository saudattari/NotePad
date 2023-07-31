using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox
{
    public partial class Form1 : Form
    {
        string address = "Data Source=DESKTOP-BTIF83O\\SQLEXPRESS;Initial Catalog=Notepad;Integrated Security=True";
        public string st;
        string undo;
        public Form1()
        {
            InitializeComponent();
            showdata();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("File is Empty");
            }
            else
            {
            insert();
            showdata();
            }
        }
        private void insert()
        {

            SqlConnection con = new SqlConnection(address);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Note(Notes) VALUES('" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Text Saved Succuesfully");
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(address);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(Note_Id) FROM Note";
            string x = cmd.ExecuteScalar().ToString();
            int count = Convert.ToInt32(x);
            con.Close();
            showdata();
            if(count == 0)
            {
                MessageBox.Show("Sorry! No Record Found In Database");
            }
            else{
                SqlConnection conn = new SqlConnection(address);
                con.Open();
                SqlCommand cm = conn.CreateCommand();
                cm.CommandText = "DELETE FROM Note WHERE Note_Id='" + Convert.ToInt32(st) + "'";
                cm.ExecuteNonQuery();
                conn.Close();
                showdata();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(address);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(Note_Id) FROM Note";
            string x = cmd.ExecuteScalar().ToString();
            int count = Convert.ToInt32(x);
            con.Close();
            showdata();
            if (count == 0)
            {
                MessageBox.Show("Sorry! No Record Found In Database");
            }
            else
            {
                string z = textBox1.Text;
                SqlConnection conn = new SqlConnection(address);
                con.Open();
                SqlCommand cm = conn.CreateCommand();
                cm.CommandText = "UPDATE Note SET Notes = '" + z + "' WHERE Note_Id ='" + Convert.ToInt32(st) + "'";
                cm.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             st= gridviews.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = gridviews.SelectedRows[0].Cells[1].Value.ToString();
        }
        private void showdata()
        {
            SqlConnection con = new SqlConnection(address);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM Note", con);
            da.Fill(dt);
            gridviews.DataSource = dt;
            con.Close();
        }
    }
}
