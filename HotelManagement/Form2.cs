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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                int roomno = Convert.ToInt32(textBox1.Text);
                string roomcategory = textBox2.Text;
                string connect = "Data source=DESKTOP-L0EEEQT;Initial Catalog=HotelDB;Integrated Security=true;";
                con = new SqlConnection(connect);
                con.Open();
                cmd = new SqlCommand("INSERT INTO New_room_entry VALUES(" + roomno + ",'" + roomcategory + "','Available')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("The New Room " + roomno + " " +roomcategory+" is Added");


            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
                button1.Enabled = false;
            
        }
    }
}
