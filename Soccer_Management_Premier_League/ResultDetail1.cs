using Guna.UI2.WinForms;
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
    public partial class ResultDetail1 : Form
    {
        AddResult addResult;
        DataTable dt = new DataTable();
        DataTable data = new DataTable();
        public ResultDetail1(AddResult ar)
        {
            InitializeComponent();
            addResult = ar;
            dt.Columns.Add("IDPL", typeof(string));
            dt.Columns.Add("IDCLB", typeof(string));
            dt.Columns.Add("IDMATCH", typeof(string));
            dt.Columns.Add("TIME_GOAL", typeof(string));
            dt.Columns.Add("IDPLA", typeof(string));
            dt.Columns.Add("TIME_RED", typeof(string));
            dt.Columns.Add("TIME_YELLOW", typeof(string));
            dt.Columns.Add("TIME_ASSIST", typeof(string));
            dt.Columns.Add("IDPLR", typeof(string));
            dt.Columns.Add("IDPLY", typeof(string));
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

        private void LoadScore()
        {
            flowLayoutPanel1.Controls.Clear();
            data.DefaultView.Sort = "TIME_GOAL asc";
            data = data.DefaultView.ToTable();
            foreach (DataRow row in data.Rows)
            {
                if (row[1].ToString() == HostName.Text)
                {
                    Guna2Panel panel = new Guna2Panel();
                    panel.BackColor = Color.White;
                    panel.FillColor = Color.DarkGray;
                    panel.Size = new Size(150, 50);
                    panel.BorderRadius = 25;
                    Guna2Panel panel1 = new Guna2Panel();
                    panel1.BackColor = Color.Transparent;
                    panel1.FillColor = Color.Black;
                    panel1.Size = new Size(40, 40);
                    panel1.BorderRadius = 20;
                    panel.Controls.Add(panel1);
                    panel1.Location = new Point(105, 5);
                    Label label = new Label();
                    label.ForeColor = Color.White;
                    label.Font = new Font("CenturyGothic", 10F, FontStyle.Bold);
                    label.Text = row[2].ToString() + "'";
                    panel1.Controls.Add(label);
                    label.Location = new Point(10, 10);
                    Label label1 = new Label();
                    label1.ForeColor = Color.White;
                    label1.BackColor = Color.Transparent;
                    label1.Font = new Font("CenturyGothic", 10F/*, FontStyle.Bold*/);
                    label1.Text = row[0].ToString();
                    panel.Controls.Add(label1);
                    label1.Location = new Point(10, 10);
                    flowLayoutPanel1.Controls.Add(panel);
                    Guna2Panel pa = new Guna2Panel();
                    pa.Size = new Size(90, 50);
                    flowLayoutPanel1.Controls.Add(pa);
                }
                else
                {
                    Guna2Panel pa = new Guna2Panel();
                    pa.Size = new Size(95, 50);
                    flowLayoutPanel1.Controls.Add(pa);
                    Guna2Panel panel = new Guna2Panel();
                    panel.BackColor = Color.White;
                    panel.FillColor = Color.DarkGray;
                    panel.Size = new Size(150, 50);
                    panel.BorderRadius = 25;
                    Guna2Panel panel1 = new Guna2Panel();
                    panel1.BackColor = Color.Transparent;
                    panel1.FillColor = Color.Black;
                    panel1.Size = new Size(40, 40);
                    panel1.BorderRadius = 20;
                    panel.Controls.Add(panel1);
                    panel1.Location = new Point(5, 5);
                    Label label = new Label();
                    label.ForeColor = Color.White;
                    label.Font = new Font("CenturyGothic", 10F, FontStyle.Bold);
                    label.Text = row[2].ToString() + "'";
                    panel1.Controls.Add(label);
                    label.Location = new Point(10, 10);
                    Label label1 = new Label();
                    label1.ForeColor = Color.White;
                    label1.BackColor = Color.Transparent;
                    label1.Font = new Font("CenturyGothic", 10F/*, FontStyle.Bold*/);
                    label1.Text = row[0].ToString();
                    panel.Controls.Add(label1);
                    label1.Location = new Point(50, 10);
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }
        private void AddScore()
        {
            scoreHome = Convert.ToInt32(Score1.Text);
            scoreVisit = Convert.ToInt32(Score2.Text);
            data.Rows.Add(Player_cbx.Text, comboBox1.Text, Time_txt.Value.ToString());
            LoadScore();
            if (comboBox1.Text == HostName.Text)
                scoreHome++;
            else
                scoreVisit++;
            Score1.Text = scoreHome.ToString();
            Score2.Text = scoreVisit.ToString();
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
        private void button3_Click(object sender, EventArgs e)
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
                
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    foreach(DataRow row in dt.Rows)
                    {
                        string idpl = row[0].ToString();
                        string idclb = row[1].ToString();
                        string idmatch = row[2].ToString();
                        string timegoal = row[3].ToString();
                        string idpla = row[4].ToString();
                        string timered = row[5].ToString();
                        string timeyellow = row[6].ToString();
                        string timeassist = row[7].ToString();
                        string idplr = row[8].ToString();
                        string idply = row[9].ToString();
                        string query = "INSERT INTO GOAL(IDPL, IDCLB, IDMATCH, TIME_GOAL, IDPLA, IDPLR, IDPLY, TIME_RED, TIME_YELLOW, TIME_ASSIST)values(@idpl, @idclb,@idmatch,@timegoal,@idpla, @idplr,@idply,@timered,@timeyellow,@timeassist)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@idpl", idpl);
                        command.Parameters.AddWithValue("@idclb", idclb);
                        command.Parameters.AddWithValue("@idmatch", idmatch);
                        command.Parameters.AddWithValue("@timegoal", timegoal);
                        command.Parameters.AddWithValue("@idpla", idpla);
                        command.Parameters.AddWithValue("@timered", timered);
                        command.Parameters.AddWithValue("@timeyellow", timeyellow);
                        command.Parameters.AddWithValue("@timeassist", timeassist);
                        command.Parameters.AddWithValue("@idplr", idplr);
                        command.Parameters.AddWithValue("@idply", idply);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    connection.Close();
                    dt.Rows.Clear();
                }
            }
            else
            {
                scoreHome = 0;
                scoreVisit = 0;
                Score1.Text = "";
                Score2.Text = "";
                flowLayoutPanel1.Controls.Clear();
                

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

        private void button2_Click(object sender, EventArgs e)
        {
            AddScore();
            string idclb=GetID(comboBox1.Text);
            string idpl = GetIDPlayer(Player_cbx.Text);
            string idpla = GetIDPlayer(Assistant_cbx.Text);
            string idmatch = ID_txt.Text;
            string timegoal = Time_txt.Text;
            string timeassist = guna2NumericUpDown1.Value.ToString();
            string time_red = guna2NumericUpDown2.Value.ToString();
            string time_yellow = guna2NumericUpDown3.Value.ToString();
            string idplr = Red_Cbx.Text;
            string idply = Yellow_Cbx.Text;
            dt.Rows.Add(idpl, idclb, idmatch, timegoal, idpla, time_red, time_yellow, timeassist, idplr, idply);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            if (!string.IsNullOrEmpty(combo.Text))
            {
                GetPlayer();
                GetAssistant();
            }
        }

        private void ResultDetail1_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT PLNAME, CLBNAME , TIME_GOAL FROM GOAL AS G, CLUB AS C, FOOTBALL_PLAYER AS P WHERE C.IDCLB=G.IDCLB AND P.IDPL=G.IDPL AND IDMATCH = '" + ID_txt.Text.ToString() + "'";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                ada.Fill(data);
                connection.Close();
            }
            LoadScore();
        }
    }
}
