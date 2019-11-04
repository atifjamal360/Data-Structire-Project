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
using System.Threading;

namespace StadiumTicketCollector
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=TCA;User ID=sa;Password=corem3");
        public Form1()
        {
            InitializeComponent();      
        }
        
        public void splashStart()
        {
            Application.Run(new Form12());
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (un.Text == "" || pass.Text =="")
            {
                MessageBox.Show("Please Enter Fields");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "select * from signup_table where name = '"+un.Text+"' and pass ='"+pass.Text+"'";
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataAdapter adt = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    if (dt.Rows.Count>0)
                    {
                        Form3 f3 = new Form3();
                        f3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username and password");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
            }
        }
    }
}