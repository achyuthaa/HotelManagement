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
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*textBox1.Enabled = true;
            textBox1.Text = "";*/
            if (textBox1.Text != "")
            {
                int room = Convert.ToInt32(textBox1.Text);
                string connection = "Data source=DESKTOP-L0EEEQT;Initial catalog=HotelDB;Integrated security=true;";
                con = new SqlConnection(connection);
                con.Open();
                cmd = new SqlCommand("select * from checkin_form where roomno=@value1 and status='CheckedIn'", con);
                cmd.Parameters.AddWithValue("@value1", room);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBox2.Text = rdr.GetInt32(9).ToString();
                    textBox3.Text = rdr.GetDateTime(10).ToString();
                    DateTime curr = DateTime.Today;
                    textBox4.Text = curr.ToString();
                    textBox5.Text = rdr.GetString(5);
                    textBox6.Text = rdr.GetInt32(7).ToString();
                    DateTime d1 = rdr.GetDateTime(10);
                    TimeSpan diff = curr - d1;
                    textBox7.Text = diff.ToString();
                    textBox8.Text = rdr.GetString(0);
                    textBox9.Text = (diff.TotalDays * rdr.GetInt32(7)).ToString();
                    
                }
                con.Close();



            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            //textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button2.Enabled = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int room = Convert.ToInt32(textBox1.Text);
                button2.Enabled = true;
                string connection = "Data source=DESKTOP-L0EEEQT;Initial catalog=HotelDB;Integrated security=true;";
                con = new SqlConnection(connection);
                con.Open();
                cmd = new SqlCommand("update checkin_form set status='CheckedOut' where roomno=@value1", con);
                cmd.Parameters.AddWithValue("@value1", Convert.ToInt32(textBox1.Text));
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("Update New_room_entry set Status='Available' where Roomno=@value2", con);
                cmd.Parameters.AddWithValue("@value2", room);
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";

                MessageBox.Show("Room No " + room + " successfully checked out");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

        }
    }
}
