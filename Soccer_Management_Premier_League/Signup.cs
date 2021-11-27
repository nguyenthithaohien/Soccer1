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

namespace Soccer_Management_Premier_League
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        string strcon = @"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True";
        SqlConnection sqlcon = null;
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            if (Usertextbox.Text == "")
            {
                MessageBox.Show("Please fill in the Username!");
                Usertextbox.Focus();
            }
            else if (PassTestbox.Text == "")
            {
                MessageBox.Show("Please fill in the Password!");
                PassTestbox.Focus();
            }
            else if (RwPassTestbox.Text == "")
            {
                MessageBox.Show("Please fill in the Rewrite Password!");
                RwPassTestbox.Focus();
            }
            else if (PassTestbox.Text != RwPassTestbox.Text)
            {
                MessageBox.Show("Password and Rewrite Password must be the same!");
                RwPassTestbox.Focus();
                RwPassTestbox.SelectAll();
            }
            else if (EmailTextbox.Text == "")
            {
                MessageBox.Show("Please fill in the Email");
                EmailTextbox.Focus();
            }
            else
            {
                try
                {
                    if (sqlcon == null)
                    {
                        sqlcon = new SqlConnection(strcon);
                    }
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    string user = Usertextbox.Text.Trim();
                    string pass = PassTestbox.Text.Trim();
                    string email = EmailTextbox.Text.Trim();


                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.CommandText = "insert into ACCOUNT values ('" + user + "', '" + pass + "', '" + email + "')";

                    sqlcmd.Connection = sqlcon;
                    int kq = sqlcmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Sign up successfully \nNow we need you to answer 3 next secrect questions to protect your account!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _2ndPassWord second = new _2ndPassWord();
                        this.Hide();
                        second.Show();
                    }
                    else
                    {
                        MessageBox.Show("Fail to sign up", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Your Username has been existed. \nPlease try again!");
                    Usertextbox.Focus();
                    Usertextbox.SelectAll();
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }
    }
}
