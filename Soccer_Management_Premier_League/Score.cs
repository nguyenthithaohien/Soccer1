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
    public partial class Score : Form
    {
        Result result;
        public Score(Result rs)
        {
            InitializeComponent();

            result = rs;

           
        }

        private void GetAssistant()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();

                string query = "Select PLNAME from FOOTBALL_PLAYER where IDCLB = '" + IDCLB.Text + "' order by PLNAME";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Assistant_cbx.DataSource = ds.Tables[0];
                Assistant_cbx.DisplayMember = "PLNAME";
                Assistant_cbx.SelectedIndex = -1;
            }
        }

        private void GetPlayer()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();

                string query = "Select PLNAME from FOOTBALL_PLAYER where IDCLB = '"+ IDCLB.Text + "' order by PLNAME";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Player_cbx.DataSource = ds.Tables[0];
                Player_cbx.DisplayMember = "PLNAME";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string insertQuery = "insert into GOAL(IDPL, IDCLB, IDMATCH,TIME_GOAL,IDPLA,TIME_ASSIST) values(@idpl, @idclb, @idmatch, @time_goal,@idpla,@time_assist)";
                SqlCommand sqlCommand = new SqlCommand(insertQuery, connection);

                if(Assistant_cbx.SelectedIndex == -1)
                {
                    Assistant_cbx.Text = "";
                }

                sqlCommand.Parameters.AddWithValue("@idpl", GetIDPlayer(Player_cbx.Text));
                sqlCommand.Parameters.AddWithValue("@idclb", IDCLB.Text);
                sqlCommand.Parameters.AddWithValue("@idmatch", result.ID_txt.Text);
                sqlCommand.Parameters.AddWithValue("@time_goal", int.Parse(Time_txt.Text));

                if (Assistant_cbx.SelectedIndex == -1)
                {
                    sqlCommand.Parameters.AddWithValue("@idpla", "");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@idpla", GetIDPlayer(Assistant_cbx.Text));
                }

                sqlCommand.Parameters.AddWithValue("@time_assist", int.Parse(Time_txt.Text));

                string query1 = "Update FOOTBALL_PLAYER set SCORE = SCORE + 1 where PLNAME = '"+ Player_cbx.Text + "'";

                string query2 = "Update FOOTBALL_PLAYER set ASSISS = ASSISS + 1 where PLNAME = '" + Assistant_cbx.Text + "'";

                SqlCommand sqlCommand1 = new SqlCommand(query1, connection);
                SqlCommand sqlCommand2 = new SqlCommand(query2, connection);

                try
                {
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand1.ExecuteNonQuery();
                    //sqlCommand2.ExecuteNonQuery();
                    MessageBox.Show("Add successfully");
                    connection.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
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

        private void Score_Load(object sender, EventArgs e)
        {
            GetPlayer();
            GetAssistant();
        }
    }
}
