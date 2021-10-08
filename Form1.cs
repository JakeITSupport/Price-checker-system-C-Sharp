using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price_Checker_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MySqlConnection connect;
        public void con()
        {
            string connectionstring;
            connectionstring = "server=localhost;user id=root;database=db_sunshine_supermarket; password = Info.0515";
            connect = new MySqlConnection(connectionstring);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            string querySelectData = "SELECT * FROM tbl_products where barcode ='" + tb_barcode.Text + "'; ";

            MySqlDataReader reader;

            con();
            connect.Open();
            cmd.CommandText = querySelectData;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                
                tb_price.Text = reader.GetString("price");
                lbl_description.Text = reader.GetString("description");
                lbl_label.Text = reader.GetString("label");
                lbl_company.Text = reader.GetString("company");
                tb_barcode.SelectAll();
            }

            else if (reader.Read() == false)
            {
                tb_price.Text = "Not Found";
                lbl_description.Text = "*";
            }
            connect.Close();
        }

        int timeLeft = 3;
        int timeLeft1 = 30;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                lbl_time.Text = timeLeft + " Seconds";
                tb_barcode.Select();
            }
            else
            {
                tb_barcode.SelectAll();

            }

            if (timeLeft1 > 0)
            {
                timeLeft1 = timeLeft1 - 1;
                lbl_timer.Text = timeLeft1 + "";
            }

            if (lbl_timer.Text == "20")
            {
                tb_price.Text = "Scan Barcode";
                lbl_description.Text = "*";
                lbl_label.Text = "*";
                lbl_label.Text = "*";

                tb_barcode.Select();
            }

            if (timeLeft1 == 0)
            {
                timeLeft1 = 30;
            }
        }
    }
}
