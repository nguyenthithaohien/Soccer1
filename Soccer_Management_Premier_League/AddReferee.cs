using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer_Management_Premier_League
{
    public partial class AddReferee : Form
    {
        Referee referee;
        public AddReferee(Referee rf)
        {
            InitializeComponent();
            referee = rf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Verify())
            {
                string name = text_name.Text;
                string nationality = text_nation.Text;
                string type = cbType.SelectedItem.ToString();
                DateTime dt = date_birth.Value;


                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "insert into REFEREE(REF_NAME,NATIONALITY, DAY_BORN, TYPE_REF) values(@name,@nationality,@dt,@type)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@nationality", nationality);
                    command.Parameters.AddWithValue("@dt", dt);
                    command.Parameters.AddWithValue("@type", type);


                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Add Successfully");
                        referee.LoadReferee();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    connection.Close();
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Verify()
        {
            if (text_name.Text == "" || text_nation.Text == "" || cbType.Text == "")
                return false;
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text_name.Text = "";
            text_nation.Text = "";
            cbType.Text = "";
        }
    }
}
