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
    public partial class EditCoach : Form
    {
        Coach coach;
        public EditCoach(Coach c)
        {
            InitializeComponent();
            coach = c;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                string idCoach = tbID.Text;
                string id = ID_Txt.Text;
                string name = Name_Txt.Text;
                string type = Type_Txt.Text;
                string quocGia = Nation_Txt.Text;
                DateTime dateTime = Birth_Date.Value;

                connection.Open();
                string query = "Update COACH set IDCLB = @id, COACHNAME = @name,NATIONALITY = @quocGia, DAY_BORN = @dateTime, TYPE_COACH = @type where IDCOACH = '" + idCoach + "'";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@quocGia", quocGia);
                command.Parameters.AddWithValue("@dateTime", dateTime);
                command.Parameters.AddWithValue("@type", type);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully");
                    coach.LoadCoach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
