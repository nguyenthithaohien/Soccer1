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
    public partial class ManagePlayer : Form
    {
        public ManagePlayer()
        {
            InitializeComponent();
            GetClub();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        public void LoadPlayers()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select C.CLBNAME, PLNAME,NATIONALITY, VITRI,NUMBER, DAY_BORN,P.PIC from FOOTBALL_PLAYER as P,CLUB as C where P.IDCLB = '" + guna2ComboBox1.SelectedValue.ToString() + "' and C.CLBNAME = '" + guna2ComboBox1.Text + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_player.DataSource = dt;

                DataGridView_player.Columns[0].HeaderText = "Club";
                DataGridView_player.Columns[1].HeaderText = "Name";
                DataGridView_player.Columns[2].HeaderText = "Nationality";
                DataGridView_player.Columns[3].HeaderText = "Position";
                DataGridView_player.Columns[4].HeaderText = "Number";
                DataGridView_player.Columns[5].HeaderText = "Birthday";
                DataGridView_player.Columns[6].HeaderText = "Image";

                DataGridView_player.Columns[0].Width = 130;
                DataGridView_player.Columns[1].Width = 130;
                DataGridView_player.Columns[2].Width = 120;
                DataGridView_player.Columns[3].Width = 125;
                DataGridView_player.Columns[4].Width = 60;
                DataGridView_player.Columns[5].Width = 100;
                DataGridView_player.Columns[6].Width = 100;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_player.Columns[6];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                connection.Close();
            }
        }

        private void GetClub()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select IDCLB,CLBName from CLUB";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                guna2ComboBox1.DataSource = ds.Tables[0];
                guna2ComboBox1.DisplayMember = "CLBName";
                guna2ComboBox1.ValueMember = "IDCLB";
            }
        }

        

        private void ManagePlayer_Load_1(object sender, EventArgs e)
        {
            LoadPlayers();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                Player form1 = new Player(this);

                form1.CLBID_txt.Text = guna2ComboBox1.SelectedValue.ToString();

                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "Select PIC from CLUB where IDCLB = '" + form1.CLBID_txt.Text + "'";
                    SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);

                    byte[] img = (byte[])dt.Rows[0].ItemArray[0];
                    MemoryStream ms = new MemoryStream(img);
                    form1.pictureBox2.Image = Image.FromStream(ms);
                }

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


        private void guna2ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPlayers();
        }

        private void DataGridView_player_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                if (DataGridView_player.Rows.Count != 0)
                {
                    Player1 form1 = new Player1(this);

                    form1.CLBID_txt.Text = guna2ComboBox1.SelectedValue.ToString();

                    using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                    {
                        connection.Open();
                        string query = "Select PIC from CLUB where IDCLB = '" + form1.CLBID_txt.Text + "'";
                        SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                        DataTable dt = new DataTable();
                        ada.Fill(dt);

                        byte[] img = (byte[])dt.Rows[0].ItemArray[0];
                        MemoryStream ms = new MemoryStream(img);
                        form1.pictureBox2.Image = Image.FromStream(ms);
                    }

                    form1.Number_txt.Text = DataGridView_player.CurrentRow.Cells[4].Value.ToString();
                    form1.dateTimePicker1.Value = (DateTime)DataGridView_player.CurrentRow.Cells[5].Value;
                    form1.Name_txt.Text = DataGridView_player.CurrentRow.Cells[1].Value.ToString();
                    form1.Nationality_txt.Text = DataGridView_player.CurrentRow.Cells[2].Value.ToString();
                    form1.comboBox1.Text = DataGridView_player.CurrentRow.Cells[3].Value.ToString();

                    byte[] img1 = (byte[])DataGridView_player.CurrentRow.Cells[6].Value;
                    MemoryStream ms1 = new MemoryStream(img1);
                    form1.Player_Ptx.Image = Image.FromStream(ms1);

                    
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
                    MessageBox.Show("No player. Please add player");
                }
            }catch(Exception ex)
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
                if (DataGridView_player.Rows.Count != 0)
                {
                    Player1 form1 = new Player1(this);

                    form1.CLBID_txt.Text = guna2ComboBox1.SelectedValue.ToString();

                    using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                    {
                        connection.Open();
                        string query = "Select PIC from CLUB where IDCLB = '" + form1.CLBID_txt.Text + "'";
                        SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                        DataTable dt = new DataTable();
                        ada.Fill(dt);

                        byte[] img = (byte[])dt.Rows[0].ItemArray[0];
                        MemoryStream ms = new MemoryStream(img);
                        form1.pictureBox2.Image = Image.FromStream(ms);
                    }

                    form1.Number_txt.Text = DataGridView_player.CurrentRow.Cells[4].Value.ToString();
                    form1.dateTimePicker1.Value = (DateTime)DataGridView_player.CurrentRow.Cells[5].Value;
                    form1.Name_txt.Text = DataGridView_player.CurrentRow.Cells[1].Value.ToString();
                    form1.Nationality_txt.Text = DataGridView_player.CurrentRow.Cells[2].Value.ToString();
                    form1.comboBox1.Text = DataGridView_player.CurrentRow.Cells[3].Value.ToString();

                    byte[] img1 = (byte[])DataGridView_player.CurrentRow.Cells[6].Value;
                    MemoryStream ms1 = new MemoryStream(img1);
                    form1.Player_Ptx.Image = Image.FromStream(ms1);

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
                    MessageBox.Show("No player. Please add player");
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

        private void DataGridView_player_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to remove this player", "Remove player", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                    {
                        connection.Open();
                        string query = "Delete from FOOTBALL_PLAYER where PLNAME = '" + DataGridView_player.CurrentRow.Cells[1].Value.ToString() + "'";

                        SqlCommand command = new SqlCommand(query, connection);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Player Removed", "Remove player", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadPlayers();

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
