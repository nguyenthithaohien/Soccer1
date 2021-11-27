using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer_Management_Premier_League
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        int startpoint = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startpoint += 1;
            guna2WinProgressIndicator1.Start();
            if (startpoint > 20)
            {
                Login login = new Login();
                guna2WinProgressIndicator1.Stop();

                timer1.Stop();
                this.Hide();
                login.Show();
            }
        }
    }
}


