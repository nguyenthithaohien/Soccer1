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
using System.IO;

namespace Soccer_Management_Premier_League
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        public void LoadClubs()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                
                string query = "Select CLBID, CLBNAME, DAYBUILT, ADDRESS,STADIUM, NATION, CITY,Pic from CLUB where CLBNAME like '%" + textSearch.Text + "%'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_club.DataSource = dt;

                DataGridView_club.Columns[0].HeaderText = "ID";
                DataGridView_club.Columns[1].HeaderText = "Name";
                DataGridView_club.Columns[2].HeaderText = "Founded";
                DataGridView_club.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                DataGridView_club.Columns[3].HeaderText = "Address";
                DataGridView_club.Columns[4].HeaderText = "Stadium";
                DataGridView_club.Columns[5].HeaderText = "Nation";
                DataGridView_club.Columns[6].HeaderText = "City";
                DataGridView_club.Columns[7].HeaderText = "Logo";

                DataGridView_club.Columns[0].Width = 40;
                DataGridView_club.Columns[1].Width = 100;
                DataGridView_club.Columns[2].Width = 75;
                DataGridView_club.Columns[3].Width = 125;
                DataGridView_club.Columns[4].Width = 110;
                DataGridView_club.Columns[5].Width = 80;
                DataGridView_club.Columns[6].Width = 80;
                DataGridView_club.Columns[7].Width = 50;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_club.Columns[7];

                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                
            }
        }

        private void Registration_Load_1(object sender, EventArgs e)
        {
            LoadClubs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                Club form1 = new Club(this);

                formBackground.FormBorderStyle = FormBorderStyle.None;
                formBackground.Opacity = .50d;
                formBackground.BackColor = Color.Black;
                formBackground.WindowState = FormWindowState.Maximized;
                //formBackground.TopMost = true;
                formBackground.Location = this.Location;
                formBackground.ShowInTaskbar = false;
                formBackground.Show();

                form1.Owner = formBackground;
                form1.ShowDialog();

                formBackground.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                if (DataGridView_club.Rows.Count != 0)
                {
                    Club1 form1 = new Club1(this);

                    form1.ID_Txt.Text = DataGridView_club.CurrentRow.Cells[0].Value.ToString();
                    form1.Name_Txt.Text = DataGridView_club.CurrentRow.Cells[1].Value.ToString();
                    form1.Founded_Date.Value = (DateTime)DataGridView_club.CurrentRow.Cells[2].Value;
                    form1.Address_Txt.Text = DataGridView_club.CurrentRow.Cells[3].Value.ToString();
                    form1.Nation_Txt.Text = DataGridView_club.CurrentRow.Cells[5].Value.ToString();
                    form1.City_Txt.Text = DataGridView_club.CurrentRow.Cells[6].Value.ToString();
                    form1.Stadium_Txt.Text = DataGridView_club.CurrentRow.Cells[4].Value.ToString();

                    byte[] img1 = (byte[])DataGridView_club.CurrentRow.Cells[7].Value;
                    MemoryStream ms1 = new MemoryStream(img1);
                    form1.Club_Ptx.Image = Image.FromStream(ms1);

                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .50d;
                    formBackground.BackColor = Color.Black;
                    formBackground.WindowState = FormWindowState.Maximized;
                    formBackground.TopMost = true;
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    form1.Owner = formBackground;
                    form1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No club. Please add club");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            LoadClubs();
        }

        private void DataGridView_club_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to remove this club", "Remove club", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                    {
                        connection.Open();
                        string query = "Delete from CLUB where CLBID = '" + DataGridView_club.CurrentRow.Cells[0].Value.ToString() + "'";

                        SqlCommand command = new SqlCommand(query, connection);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Club Removed", "Remove club", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadClubs();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
