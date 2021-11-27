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

namespace Soccer_Management_Premier_League
{
    public partial class EditReferee : Form
    {
        Referee referee;
        public EditReferee(Referee rf)
        {
            InitializeComponent();
            referee = rf;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                string name = text_name.Text;
                string type = text_type.Text;
                string quocGia = text_nation.Text;
                DateTime dateTime = date_birth.Value;

                connection.Open();

                string query = "Update REFEREE set IDREF = @id, REF_NAME = @name, NATIONALITY = @quocGia, DAY_BORN=@dateTime, TYPE_REF = @type where REF_NAME = '" + name + "'";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@quocGia", quocGia);
                command.Parameters.AddWithValue("@dateTime", dateTime);
                command.Parameters.AddWithValue("@type", type);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully");
                    referee.LoadReferee();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this referee", "Remove Referee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Delete from REFEREE where REF_NAME = '" + text_name.Text + "'";


                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Referee Removed", "Remove referee", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
