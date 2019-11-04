using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StadiumTicketCollector
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=TCA;User ID=sa;Password=corem3");
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (un.Text == "" || pass.Text == "" || cpass.Text == "" || email.Text=="")
            {
                MessageBox.Show("Please Enter Feilds");
            }
            else
            {
                try
                {
                    string gender = "";
                    conn.Open();
                    if (radioButton1.Checked == true)
                    {
                        gender = radioButton1.Text;
                    }
                    else
                    {
                        gender = radioButton2.Text;
                    }
                    string query = "insert into signup_table values('" + un.Text + "','" + pass.Text + "','" + cpass.Text + "','" + email.Text + "','" + gender + "')";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Account Create success");
                    conn.Close();
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
    }
}
