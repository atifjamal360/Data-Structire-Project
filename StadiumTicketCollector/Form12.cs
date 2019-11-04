using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StadiumTicketCollector
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value==100)
            {
                timer1.Stop();
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
        }
    }
}
