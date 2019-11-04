using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StadiumTicketCollector
{
    public partial class Form14 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=TCA;User ID=sa;Password=corem3");
        public Form14()
        {
            InitializeComponent();
            SqlDataAdapter da = new SqlDataAdapter("select * from cust_detail", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnic.DataSource = dt;
            cnic.DisplayMember = "cust_cnic";     
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select * from cust_detail where cust_cnic = '" + cnic.Text + "'";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr.GetValue(0).ToString();
                textBox4.Text = dr.GetValue(2).ToString();
                textBox5.Text = dr.GetValue(3).ToString();
                textBox6.Text = dr.GetValue(4).ToString();
                textBox3.Text = dr.GetValue(5).ToString();
                textBox7.Text = dr.GetValue(6).ToString();
              
            }

            conn.Close();
         
        }

        private void cnic_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daadp = new SqlDataAdapter("select * from cust_detail", conn);
            DataTable dt = new DataTable();
            daadp.Fill(dt);
            cnic.DataSource = dt;
            cnic.Update();
            cnic.DisplayMember = "cust_cnic";
        }
    }
}
