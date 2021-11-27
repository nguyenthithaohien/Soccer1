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

namespace Soccer_Management_Premier_League
{
    public partial class ResultDetail : Form
    {
        AddResult addResult;
        public ResultDetail(AddResult ar)
        {
            InitializeComponent();
            addResult = ar;
        }

        private string GetID(string text)
        {
            string hostClub = "";

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
        private void GetAssistant()
        {
            
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();

                string query = "Select PLNAME from FOOTBALL_PLAYER where IDCLB = '" + GetID(comboBox1.SelectedValue.ToString()) + "' order by PLNAME";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Assistant_cbx.DataSource = ds.Tables[0];
                Assistant_cbx.DisplayMember = "PLNAME";
            }
        }

        private void GetPlayer()
        {
            
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();

                string query = "Select PLNAME from FOOTBALL_PLAYER where IDCLB = '" + GetID(comboBox1.SelectedValue.ToString()) + "' order by PLNAME";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Player_cbx.DataSource = ds.Tables[0];
                Player_cbx.DisplayMember = "PLNAME";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add this result", "Add result", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int score1 = int.Parse(Score1.Text);
                int score2 = int.Parse(Score2.Text);

                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "Update MATCH1 set SCORED1 = '" + score1 + "',SCORED2 = '" + score2 + "' where IDMatch = '" + ID_txt.Text.ToString() + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Add result successfully");
                        addResult.LoadResult();
                        UpdateRanking(score1, score2, GetID(HostName.Text));
                        UpdateGD(GetID(HostName.Text));
                        UpdateRanking(score2, score1, GetID(VisitName.Text));
                        UpdateGD(GetID(VisitName.Text));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    connection.Close();
                }
            }
            else
            {
                scoreHome = 0;
                scoreVisit = 0;
                Score1.Text = "";
                Score2.Text = "";
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();
                flowLayoutPanel4.Controls.Clear();

                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "DELETE FROM GOAL where IDMatch = '" + ID_txt.Text.ToString() + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    connection.Close();
                }
            }
        }

        private string GetIDPlayer(string text)
        {
            string id;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();

                string query = "Select IDPL from FOOTBALL_PLAYER where PLNAME = '" + text + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable ds = new DataTable();
                ada.Fill(ds);

                id = ds.Rows[0].ItemArray[0].ToString();
            }

            return id;
        }

        static int scoreHome = 0;
        static int scoreVisit = 0;

        //List<string> namePLGoal = new List<string>();
        //List<string> namePLAssist = new List<string>();
        //List<string> namePLYellow = new List<string>();
        //List<string> namePLRed = new List<string>();

        private void LoadScore(FlowLayoutPanel pnl1,FlowLayoutPanel pnl2)
        {
            Label nameHost, timeHost, nameHostA, timeHostA,nameHostY,timeHostY, nameHostR, timeHostR;
            PictureBox yellow, red;

            nameHost = new Label();
            timeHost = new Label();
            
            nameHostR = new Label();

            nameHost.Text = Player_cbx.Text;
            nameHost.AutoSize = true;

            timeHost.Text = Time_txt.Text + "'";
            timeHost.AutoSize = true;

            pnl1.Controls.Add(nameHost);
            pnl1.Controls.Add(timeHost);

            if (Yellow_Cbx.Text != "")
            {
                nameHostY = new Label();
                nameHostY.Text = Yellow_Cbx.Text;
                yellow = new PictureBox();
                yellow.Size = new System.Drawing.Size(15,15);
                yellow.BackColor = Color.Yellow;
                pnl1.Controls.Add(nameHostY);
                pnl1.Controls.Add(yellow);
            }

            nameHostA = new Label();
            timeHostA = new Label();

            nameHostA.Text = Assistant_cbx.Text;
            nameHostA.AutoSize = true;

            timeHostA.Text = Time_txt.Text + "'";
            timeHostA.AutoSize = true;

            pnl2.Controls.Add(nameHostA);
            pnl2.Controls.Add(timeHostA);

            Score1.Text = scoreHome.ToString();
            Score2.Text = scoreVisit.ToString();
        }
        private void AddScore()
        {
            if(comboBox1.Text == HostName.Text)
            {
                scoreHome++;
                LoadScore(flowLayoutPanel2,flowLayoutPanel4);
            }
            else
            {
                scoreVisit++;
                LoadScore(flowLayoutPanel1,flowLayoutPanel3);
            }
        }

        private void Goal(string plName, string plaName)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string insertQuery = "insert into GOAL(IDPL, IDCLB, IDMATCH,TIME_GOAL,IDPLA,TIME_ASSIST,) values(@idpl, @idclb, @idmatch, @time_goal,@idpla,@time_assist)";
                SqlCommand sqlCommand = new SqlCommand(insertQuery, connection);

                if (Assistant_cbx.SelectedIndex == -1)
                {
                    Assistant_cbx.Text = "";
                }

                sqlCommand.Parameters.AddWithValue("@idpl", GetIDPlayer(plName));
                sqlCommand.Parameters.AddWithValue("@idclb", GetID(comboBox1.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("@idmatch", ID_txt.Text);
                sqlCommand.Parameters.AddWithValue("@time_goal", int.Parse(Time_txt.Text));
                if (string.IsNullOrEmpty(Assistant_cbx.Text))
                {
                    sqlCommand.Parameters.AddWithValue("@idpla", null);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@idpla", GetIDPlayer(plaName));
                }
                sqlCommand.Parameters.AddWithValue("@time_assist", int.Parse(Time_txt.Text));

                try
                {
                    sqlCommand.ExecuteNonQuery();
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

        private void button2_Click(object sender, EventArgs e)
        {
            AddScore();
            //Goal(Player_cbx.Text,Assistant_cbx.Text);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            if(!string.IsNullOrEmpty(combo.Text)) {
                GetPlayer();
                GetAssistant();
            }
        }

        private void ResultDetail_Load(object sender, EventArgs e)
        {
            //GetClub();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
