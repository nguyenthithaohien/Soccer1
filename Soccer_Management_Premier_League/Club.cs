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
    public partial class Club : Form
    {
        Registration registration;
        public Club(Registration rs)
        {
            InitializeComponent();
            registration = rs;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                Club_Ptx.Image = Image.FromFile(opf.FileName);
        }

        private bool Verify()
        {
            if (ID_Txt.Text == "" || Name_Txt.Text == "" || Nation_Txt.Text == "" || Address_Txt.Text == ""
                || City_Txt.Text == "" || Club_Ptx.Image == null)
                return false;

            return true;
        }
        private void Check()
        {
            if (ID_Txt.Text == "")
            {
                MessageBox.Show("Please enter your id of club");
            }
            else if (Name_Txt.Text == "")
            {
                MessageBox.Show("Please enter your name of club");
            }
            else if (Nation_Txt.Text == "")
            {
                MessageBox.Show("Please enter your nationality of club");
            }
            else if (Address_Txt.Text == "")
            {
                MessageBox.Show("Please enter your address of club");
            }
            else if (City_Txt.Text == "")
            {
                MessageBox.Show("Please enter your city of club");
            }
            else if (Club_Ptx.Image == null)
            {
                MessageBox.Show("Please enter your image of club");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check();

            if (Verify())
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    string id = ID_Txt.Text;
                    string name = Name_Txt.Text;
                    string diaChi = Address_Txt.Text;
                    string stadium = Stadium_Txt.Text;
                    string quocGia = Nation_Txt.Text;
                    string thanhPho = City_Txt.Text;
                    DateTime dateTime = Founded_Date.Value;

                    MemoryStream ms = new MemoryStream();
                    Club_Ptx.Image.Save(ms, Club_Ptx.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    connection.Open();
                    string query = "insert into CLUB(CLBID, CLBNAME, DAYBUILT, ADDRESS,STADIUM, NATION, CITY,Pic) values(@id,@name,@dateTime,@diaChi,@stadium,@quocGia,@thanhPho, @img)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@dateTime", dateTime);
                    command.Parameters.AddWithValue("@diaChi", diaChi);
                    command.Parameters.AddWithValue("@stadium", stadium);
                    command.Parameters.AddWithValue("@quocGia", quocGia);
                    command.Parameters.AddWithValue("@thanhPho", thanhPho);
                    command.Parameters.AddWithValue("@img", img);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Add Successfully");
                        registration.LoadClubs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ID_Txt.Text = "";
            Name_Txt.Text = "";
            Address_Txt.Text = "";
            Stadium_Txt.Text = "";
            Nation_Txt.Text = "";
            City_Txt.Text = "";
            Club_Ptx.Image = null;
        }


        
    }
}
