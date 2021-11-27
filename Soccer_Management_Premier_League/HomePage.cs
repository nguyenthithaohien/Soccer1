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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Club_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Registration());
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            
            childForm.FormBorderStyle = FormBorderStyle.None;
            this.panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManagePlayer());
        }

        private void Btn_MatchSchedule_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddMatch());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddResult());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Ranking());
        }

        private void Btn_exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Referee());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Coach());
        }
    }
}
