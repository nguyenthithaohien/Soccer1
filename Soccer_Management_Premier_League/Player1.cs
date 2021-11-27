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
    public partial class Player1 : Form
    {
        ManagePlayer mp;
        public Player1(ManagePlayer managePlayer)
        {
            InitializeComponent();
            mp = managePlayer;
            //GetClub();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                Player_Ptx.Image = Image.FromFile(opf.FileName);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this player", "Remove Player", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Delete from FOOTBALL_PLAYER where PLNAME = '" + Name_txt.Text + "'";

                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Player Removed", "Remove player", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mp.LoadPlayers();

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //LoadClubs();

                    connection.Close();
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                string id = CLBID_txt.Text;
                string name = Name_txt.Text;
                int number = int.Parse(Number_txt.Text);
                string quocGia = Nationality_txt.Text;
                //string thanhPho = City_Txt.Text;
                DateTime dateTime = dateTimePicker1.Value;
                string role = comboBox1.Text;

                MemoryStream ms = new MemoryStream();
                Player_Ptx.Image.Save(ms, Player_Ptx.Image.RawFormat);
                byte[] img = ms.ToArray();

                connection.Open();
                string query = "Update FOOTBALL_PLAYER set IDCLB = @id, PLNAME = @name,NATIONALITY = @quocGia, VITRI = @role,NUMBER = @number, DAY_BORN = @dateTime,PIC = @img where PLNAME = '" + name + "'";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@dateTime", dateTime);
                command.Parameters.AddWithValue("@number", number);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@quocGia", quocGia);
                command.Parameters.AddWithValue("@img", img);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully");
                    mp.LoadPlayers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
