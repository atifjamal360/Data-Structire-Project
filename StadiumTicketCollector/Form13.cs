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
    public partial class Form13 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=TCA;User ID=sa;Password=corem3");
        public Form13()
        {
            InitializeComponent();
            string query = "select * from price_table";
            SqlDataAdapter dataadapt = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dataadapt.Fill(dt);
            noe.DataSource = dt;
            noe.DisplayMember = "name";
        }

        private void button1_Click(object sender, EventArgs e) //insert
        {
            if (enclo_name.Text == "" || enclo_price.Text == "")
            {
                MessageBox.Show("Please Enter Feilds");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into price_table values('" + enclo_name.Text + "','" + enclo_price.Text + "')";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully Inserted");
                    conn.Close();

                    enclo_name.Text = "";
                    enclo_price.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            try
            {
                conn.Open();
                string query = "update price_table set name='"+enclo_name.Text+"',price='"+enclo_price.Text+"' where name='"+noe.Text+"'";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
                conn.Close();

                enclo_name.Text = "";
                enclo_price.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button4_Click(object sender, EventArgs e)//clear
        {
            enclo_name.Text = "";
            enclo_price.Text = "";
        }

        private void noe_Click(object sender, EventArgs e)//click on dropdown of combobox
        {
            SqlDataAdapter daadp = new SqlDataAdapter("select * from price_table", conn);
            DataTable dt = new DataTable();
            daadp.Fill(dt);
            noe.DataSource = dt;
            noe.Update();
            noe.DisplayMember = "name";
        }

        private void button5_Click(object sender, EventArgs e)//Search button
        {
            try
            {
                conn.Open();
                string query = "select * from price_table where name = '" + noe.Text + "'";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    enclo_name.Text = dr.GetValue(1).ToString();
                    enclo_price.Text = dr.GetValue(2).ToString();
              
                }

                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)//truncate table
        {
            try
            {
                conn.Open();
                string query = "Truncate table price_table";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully All Data Delete");
                conn.Close();
                noe.Text = "";
                enclo_name.Text = "";
                enclo_price.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
