using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HotelManagement
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            button2.Enabled = false;
            int count = 0;

            string connection = "Data source=DESKTOP-L0EEEQT;Initial catalog=HotelDB;Integrated security=true;";
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand("SELECT DISTINCT * FROM Room_category", con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBox2.Items.Add(rdr.GetString(0));
            }
            cmd = new SqlCommand("SELECT COUNT(*) FROM checkin_form", con);
            con.Close();
            con.Open();
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }
            int BILL = count + 1;
            DateTime curr = DateTime.Today;
            label12.Text = BILL.ToString();
            label13.Text = curr.ToString();
            con.Close();
            comboBox1.Items.Add("Drivers Licence");
            comboBox1.Items.Add("Passport");
            comboBox1.Items.Add("Student ID");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            button2.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            int room = Convert.ToInt32(comboBox3.SelectedItem);
            string connection = "Data source=DESKTOP-L0EEEQT;Initial catalog=HotelDB;Integrated security=true;";
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM checkin_form", con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }
            int BILL = count + 1;
            DateTime curr = DateTime.Today;
            label12.Text = BILL.ToString();
            label13.Text = curr.ToString();
            con.Close();
            con.Open();
            cmd = new SqlCommand("INSERT INTO checkin_form VALUES(@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,'CheckedIn',@Value10,@Value11)", con);
            cmd.Parameters.AddWithValue("@Value1", textBox1.Text);
            cmd.Parameters.AddWithValue("@Value2", textBox2.Text);
            cmd.Parameters.AddWithValue("@Value3", textBox3.Text);
            cmd.Parameters.AddWithValue("@Value4", textBox4.Text);
            cmd.Parameters.AddWithValue("@Value5", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@Value6", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@Value7", Convert.ToInt32(comboBox3.SelectedItem));
            cmd.Parameters.AddWithValue("@Value8", Convert.ToInt32(textBox5.Text));
            cmd.Parameters.AddWithValue("@Value10", Convert.ToInt32(BILL));
            cmd.Parameters.AddWithValue("@Value11", curr);
            cmd.ExecuteNonQuery();
            MessageBox.Show("CheckIn Successfull");
            con.Close();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            button2.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            con.Open();
            cmd = new SqlCommand("UPDATE New_room_entry SET Status='Occupied' WHERE Roomno=@room", con);
            cmd.Parameters.AddWithValue("@room", room);
            cmd.ExecuteNonQuery();
            con.Close();






        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (comboBox2.SelectedItem != null)
            {
                string connection = "Data source=DESKTOP-L0EEEQT;Initial catalog=HotelDB;Integrated security=true;";
                con = new SqlConnection(connection);
                con.Open();
                cmd = new SqlCommand("SELECT *  FROM New_room_entry Where Category = @value1 AND Status='Available'",con);
                cmd.Parameters.AddWithValue("@value1", comboBox2.SelectedItem.ToString());
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    comboBox3.Items.Add(rdr.GetInt32(0));
                }
                con.Close();
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Room_category Where Catname=@value1", con);
                cmd.Parameters.AddWithValue("@value1",comboBox2.SelectedItem.ToString());
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBox5.Text = rdr.GetString(1);
                }
                con.Close();


            }
        }
    }
}
