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
    public partial class EditMatch : Form
    {
        AddMatch add;
        public EditMatch(AddMatch edit)
        {
            InitializeComponent();
            GetHomeClub();
            GetVisitClub();
            GetStadium();
            GetReferee();
            add = edit;
        }

        private void GetReferee()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select REF_NAME,IDREF from REFEREE";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                IDREF_cbx.DataSource = ds.Tables[0];
                IDREF_cbx.DisplayMember = "REF_NAME";
                IDREF_cbx.ValueMember = "IDREF";
                IDREF_cbx.SelectedIndex = -1;
            }
        }

        private void GetStadium()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select STADIUM from CLUB";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Stadium_cbx.DataSource = ds.Tables[0];
                Stadium_cbx.DisplayMember = "STADIUM";
            }
        }

        private void GetHomeClub()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True")) { 
                connection.Open();
                string query = "Select CLBNAME from CLUB";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Club_cbx.DataSource = ds.Tables[0];
                Club_cbx.DisplayMember = "CLBNAME";

            }
        }
        private string GetID(string text)
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

        private void GetVisitClub()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select CLBNAME from CLUB";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Club_cbx1.DataSource = ds.Tables[0];
                Club_cbx1.DisplayMember = "CLBNAME";

            }
        }
        private void Club_cbx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                string idmatch = tbIDMatch.Text;
                string idref = IDREF_cbx.SelectedValue.ToString();
                string hostClub = GetID(Club_cbx.Text);
                string visitClub = GetID(Club_cbx1.Text);
                DateTime ngay = dateTimePicker1.Value;
                DateTime gio = dateTimePicker1.Value;
                string stadium = Stadium_cbx.Text;

                connection.Open();

                string query = "Update MATCH1 set IDMATCH = @idmatch, IDREF = @idref, CLB1 = @hostClub, CLB2 = @visitClub, DATE = @ngay, TIME = @gio, STAYDIUM = @stadium where IDMATCH = '" + idmatch + "'";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@idmatch", idmatch);
                command.Parameters.AddWithValue("@idref", idref);
                command.Parameters.AddWithValue("@hostClub", hostClub);
                command.Parameters.AddWithValue("@visitClub", visitClub);
                command.Parameters.AddWithValue("@ngay", ngay);
                command.Parameters.AddWithValue("@gio", gio);
                command.Parameters.AddWithValue("@stadium", stadium);
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully");
                    add.LoadMatchs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this match", "Remove match", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Delete from MATCH1 where IDMATCH = '" + tbIDMatch.Text + "'";


                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Match Removed", "Remove match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        add.LoadMatchs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    connection.Close();
                }
            }
        }

        private void EditMatch_Load(object sender, EventArgs e)
        {

        }
    }
}
