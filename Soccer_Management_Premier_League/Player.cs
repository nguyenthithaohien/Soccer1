using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Soccer_Management_Premier_League
{
    public partial class Player : Form
    {
        ManagePlayer mp;
        public Player(ManagePlayer managePlayer)
        {
            InitializeComponent();
            mp = managePlayer;
            //GetClub();
        }

        private bool Verify()
        {
            if (CLBID_txt.Text == "" || Name_txt.Text == "" || Nationality_txt.Text == ""
                || Number_txt.Text == "" || Player_Ptx.Image == null)
                return false;

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Name_txt.Text = "";
            
            Nationality_txt.Text = "";
            Number_txt.Text = "";
            Player_Ptx.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                Player_Ptx.Image = Image.FromFile(opf.FileName);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (CLBID_txt.Text == "")
            {
                MessageBox.Show("Please enter your id of player");
            }
            else if (Name_txt.Text == "")
            {
                MessageBox.Show("Please enter your name of player");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter your role of player");
            }
            else if (Nationality_txt.Text == "")
            {
                MessageBox.Show("Please enter your nationality of player");
            }
            else if (Number_txt.Text == "")
            {
                MessageBox.Show("Please enter your number of player");
            }
            else if (Player_Ptx.Image == null)
            {
                MessageBox.Show("Please enter your image of player");
            }
            else { 

                string id = CLBID_txt.Text;
                string name = Name_txt.Text;
                string role = comboBox1.Text;
                string nationality = Nationality_txt.Text;
                int number = int.Parse(Number_txt.Text.ToString());
                DateTime dt = dateTimePicker1.Value;

                MemoryStream ms = new MemoryStream();
                Player_Ptx.Image.Save(ms, Player_Ptx.Image.RawFormat);
                byte[] img = ms.ToArray();

                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "insert into FOOTBALL_PLAYER(IDCLB, PLNAME,NATIONALITY, VITRI,NUMBER, DAY_BORN,PIC) values(@id,@name,@nationality,@role,@number,@dt,@img)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@nationality", nationality);
                    command.Parameters.AddWithValue("@role", role);
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@dt", dt);
                    command.Parameters.AddWithValue("@img", img);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Add Successfully");
                        Name_txt.Text = "";

                        Nationality_txt.Text = "";
                        Number_txt.Text = "";
                        Player_Ptx.Image = null;
                        mp.LoadPlayers();

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
    }
}
