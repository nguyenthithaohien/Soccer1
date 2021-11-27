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
    public partial class Club1 : Form
    {
        Registration registration;
        public Club1(Registration rg)
        {
            InitializeComponent();
            registration = rg;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this club", "Remove club", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "Delete from CLUB where CLBID = '" + ID_Txt.Text.ToString() + "'";

                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Club Removed", "Remove club", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        registration.LoadClubs();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
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
                string query = "Update CLUB set CLBID = @id, CLBNAME = @name, DAYBUILT = @datetime, ADDRESS = @diaChi," +
                    "STADIUM = @stadium, NATION = @quocGia, CITY = @thanhPho,Pic = @img " +
                    "where CLBID = '" + ID_Txt.Text.ToString() + "'";

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
                    MessageBox.Show("Update Successfully");
                    registration.LoadClubs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                Club_Ptx.Image = Image.FromFile(opf.FileName);
        }
    }
}
