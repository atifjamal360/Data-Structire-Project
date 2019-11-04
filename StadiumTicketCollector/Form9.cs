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

namespace StadiumTicketCollector
{
    public partial class Form9 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=TCA;User ID=sa;Password=corem3");
        SqlCommand cmd;
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from price_table where id = 2", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            textBox1.Text = dr[2].ToString();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill price Field.");
            }
            else
            {
                try
                {
                    Int32 val1 = Convert.ToInt32(textBox1.Text);
                    Int32 val2 = Convert.ToInt32(numericUpDown1.Value);
                    Int32 val3 = val1 * val2;
                    textBox7.Text = val3.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }    
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Feilds");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into cust_detail values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + numericUpDown1.Value + "','" + textBox7.Text + "')";
                    cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    conn.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    numericUpDown1.Value = 1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
