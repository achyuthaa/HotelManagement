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


namespace HotelManagement
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader rd;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "") {
                button1.Enabled = true;
                string categoryname = textBox1.Text;
                string rent = textBox2.Text;
                string connect = "Data Source=DESKTOP-L0EEEQT;Initial Catalog=HotelDB;Integrated Security=true;";
                con = new SqlConnection(connect);
                con.Open();
                cmd = new SqlCommand("INSERT INTO Room_category VALUES(@Value1,@Value2)", con);
                cmd.Parameters.AddWithValue("@Value1",categoryname);
                cmd.Parameters.AddWithValue("@Value2", rent);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The Room Category "+categoryname+" is Added");
                con.Close();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text!= "")
            {
                button1.Enabled=true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
    }
}
