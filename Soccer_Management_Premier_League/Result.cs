using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Soccer_Management_Premier_League
{
    public partial class Result : Form
    {
        AddResult addResult;
        public Result(AddResult ar)
        {
            InitializeComponent();
            addResult = ar;
            pictureBox1.Enabled = false;
            pictureBox3.Enabled = false;
        }


        public string GetID(string text)
        {
            string hostClub;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select IDCLB from CLUB where CLBNAME = '" + text + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                hostClub = dt.Rows[0]["IDCLB"].ToString();
            }

            return hostClub;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int score1 = int.Parse(Score1_txt.Text);
            int score2 = int.Parse(Score2_txt.Text);

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Update MATCH1 set SCORED1 = '" + score1 + "',SCORED2 = '" + score2 + "' where IDMatch = '" + ID_txt.Text.ToString() + "'";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Add result successfully");
                    //addResult.LoadResult();
                    UpdateRanking(score1, score2, GetID(Club_cbx.Text));
                    UpdateGD(GetID(Club_cbx.Text));
                    UpdateRanking(score2, score1, GetID(Club_cbx1.Text));
                    UpdateGD(GetID(Club_cbx1.Text));
                    addResult.LoadResult();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }
        }

        private void UpdateRanking(int score1, int score2, string id)
        {
            if (score1 == score2)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Update BXH set PTS = PTS + 1, GF = GF + @score1, GA = GA + @score2, D = D + 1, PL = PL + 1, GD = GF - GA where IDCLB = @id";

                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@score1", score1);
                        command.Parameters.AddWithValue("@score2", score2);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            else if (score1 > score2)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Update BXH set PTS = PTS + 3, GF = GF + @score1, GA = GA + @score2, W = W + 1, PL = PL + 1, GD = GF - GA where IDCLB = @id";

                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@score1", score1);
                        command.Parameters.AddWithValue("@score2", score2);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Update BXH set PTS = PTS + 0, GF = GF + @score1, GA = GA + @score2,L = L + 1, PL = PL + 1, GD = GF - GA where IDCLB = @id";

                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@score1", score1);
                        command.Parameters.AddWithValue("@score2", score2);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void UpdateGD(string id)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();

                string query = "Update BXH set GD = GF - GA where IDCLB = @id";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            //this.Dispose();
        }

        //public void Check()
        //{
        //    using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
        //    {
        //        connection.Open();
        //        string query = "Select SCORED1 from MATCH1 where IDMatch = '" + ID_txt.Text + "'";

        //        SqlDataAdapter ada = new SqlDataAdapter(query, connection);
        //        DataTable dt = new DataTable();
        //        ada.Fill(dt);

        //        try
        //        {
        //            if (dt.Rows.Count == 0)
        //            {
        //                pictureBox1.Enabled = false;
        //            }
        //            else
        //            {
        //                pictureBox1.Enabled = true;
        //            }

        //            connection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }

        //    //return true;
        //}
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                Score score = new Score(this);

                formBackground.FormBorderStyle = FormBorderStyle.None;
                formBackground.Opacity = .50d;
                formBackground.BackColor = Color.Black;
                formBackground.WindowState = FormWindowState.Maximized;
                formBackground.TopMost = true;
                formBackground.Location = this.Location;
                formBackground.ShowInTaskbar = false;
                formBackground.Show();

                score.Owner = formBackground;

                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "Select PIC from CLUB where CLBNAME = '" + Club_cbx.Text + "'";
                    SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);

                    byte[] img = (byte[])dt.Rows[0].ItemArray[0];
                    MemoryStream ms = new MemoryStream(img);
                    score.pictureBox2.Image = Image.FromStream(ms);

                    score.IDCLB.Text = GetID(Club_cbx.Text);
                }

                score.ShowDialog();

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                Score score = new Score(this);

                formBackground.FormBorderStyle = FormBorderStyle.None;
                formBackground.Opacity = .50d;
                formBackground.BackColor = Color.Black;
                formBackground.WindowState = FormWindowState.Maximized;
                formBackground.TopMost = true;
                formBackground.Location = this.Location;
                formBackground.ShowInTaskbar = false;
                formBackground.Show();

                score.Owner = formBackground;

                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "Select PIC from CLUB where CLBNAME = '" + Club_cbx1.Text + "'";
                    SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);

                    byte[] img = (byte[])dt.Rows[0].ItemArray[0];
                    MemoryStream ms = new MemoryStream(img);
                    score.pictureBox2.Image = Image.FromStream(ms);

                    score.IDCLB.Text = GetID(Club_cbx1.Text);
                }

                score.ShowDialog();

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

        private void Score1_txt_TextChanged(object sender, EventArgs e)
        {
            //Check();
            if (Score1_txt.Text == "")
            {
                pictureBox1.Enabled = false;
            }
            else
            {
                pictureBox1.Enabled = true;
            }
        }

        private void Score2_txt_TextChanged(object sender, EventArgs e)
        {
            if (Score2_txt.Text == "")
            {
                pictureBox3.Enabled = false;
            }
            else
            {
                pictureBox3.Enabled = true;
            }
        }
    }
}
