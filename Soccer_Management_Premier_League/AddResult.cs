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
    public partial class AddResult : Form
    {
        public AddResult()
        {
            InitializeComponent();
        }

        private void AddResult_Load(object sender, EventArgs e)
        {
            LoadResult();
        }

        public void LoadResult()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select IDMatch, T1.PIC,T1.CLBNAME,SCORED1,SCORED2,T2.PIC,T2.CLBNAME, DATE,TIME, T1.STAYDIUM from CLUB as T1, CLUB as T2, MATCH1 as M where M.CLB1 = T1.IDCLB and " +
                    "M.CLB2 = T2.IDCLB";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_match.DataSource = dt;

                DataGridView_match.Columns[0].HeaderText = "ID";
                DataGridView_match.Columns[1].HeaderText = "";
                DataGridView_match.Columns[2].HeaderText = "Host team";
                DataGridView_match.Columns[3].HeaderText = "Score";
                DataGridView_match.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DataGridView_match.Columns[4].HeaderText = "";
                DataGridView_match.Columns[5].HeaderText = "";
                DataGridView_match.Columns[6].HeaderText = "Visit team";
                DataGridView_match.Columns[7].HeaderText = "Date";
                DataGridView_match.Columns[8].HeaderText = "Time";
                DataGridView_match.Columns[9].HeaderText = "Stadium";

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_match.Columns[1];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridViewImageColumn imageColumn1 = new DataGridViewImageColumn();
                imageColumn1 = (DataGridViewImageColumn)DataGridView_match.Columns[5];
                imageColumn1.ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridView_match.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
                DataGridView_match.Columns[8].DefaultCellStyle.Format = @"hh\:mm";

                DataGridView_match.Columns[0].Width = 70;
                DataGridView_match.Columns[1].Width = 50;
                DataGridView_match.Columns[2].Width = 170;
                DataGridView_match.Columns[3].Width = 60;
                DataGridView_match.Columns[4].Width = 50;
                DataGridView_match.Columns[5].Width = 50;
                DataGridView_match.Columns[6].Width = 170;
                DataGridView_match.Columns[7].Width = 130;
                DataGridView_match.Columns[8].Width = 100;
                DataGridView_match.Columns[9].Width = 140;


                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                Result result = new Result(this);

                formBackground.FormBorderStyle = FormBorderStyle.None;
                formBackground.Opacity = .50d;
                formBackground.BackColor = Color.Black;
                formBackground.WindowState = FormWindowState.Maximized;
                //formBackground.TopMost = true;
                formBackground.Location = this.Location;
                formBackground.ShowInTaskbar = false;
                formBackground.Show();

                result.Owner = formBackground;

                result.ID_txt.Text = DataGridView_match.CurrentRow.Cells[0].Value.ToString();
                result.Club_cbx.Text = DataGridView_match.CurrentRow.Cells[2].Value.ToString();
                result.Club_cbx1.Text = DataGridView_match.CurrentRow.Cells[6].Value.ToString();

                result.dateTimePicker1.Value = (DateTime)DataGridView_match.CurrentRow.Cells[7].Value;
                var dt = result.dateTimePicker1.Value.Add((TimeSpan)DataGridView_match.CurrentRow.Cells[8].Value);
                result.dateTimePicker1.Value = dt;

                result.Stadium_cbx.Text = DataGridView_match.CurrentRow.Cells[9].Value.ToString();

                result.ShowDialog();
                
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
        private string GetNameRef(string idMatch)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select REF_NAME from REFEREE AS R, MATCH1 AS M where IDMATCH = '" + idMatch + "' and M.IDREF = R.IDREF";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                return dt.Rows[0]["REF_NAME"].ToString();
            }
        }
        private void DataGridView_match_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //try
            //{
            //    ResultDetail result = new ResultDetail(this);

            //    byte[] img1 = (byte[])DataGridView_match.CurrentRow.Cells[1].Value;
            //    MemoryStream ms1 = new MemoryStream(img1);
            //    result.HostImage.Image = Image.FromStream(ms1);

            //    img1 = (byte[])DataGridView_match.CurrentRow.Cells[5].Value;
            //    ms1 = new MemoryStream(img1);
            //    result.VisitImage.Image = Image.FromStream(ms1);

            //    result.HostName.Text = DataGridView_match.CurrentRow.Cells[2].Value.ToString();

            //    if (result.HostName.Text.Length >= 11)
            //    {
            //        result.HostName.Location = new Point(result.HostImage.Location.X - 30, 126);
            //    }

            //    result.VisitName.Text = DataGridView_match.CurrentRow.Cells[6].Value.ToString();

            //    if (result.VisitName.Text.Length >= 11)
            //    {
            //        result.VisitName.Location = new Point(result.VisitImage.Location.X - 30, 126);
            //    }


            //    result.Score1.Text = DataGridView_match.CurrentRow.Cells[3].Value.ToString();
            //    result.Score2.Text = DataGridView_match.CurrentRow.Cells[4].Value.ToString();
            //    result.StadiumName.Text = DataGridView_match.CurrentRow.Cells[9].Value.ToString();
            //    result.ID_txt.Text = DataGridView_match.CurrentRow.Cells[0].Value.ToString();
            //    result.RefereeName.Text = GetNameRef(result.ID_txt.Text);
            //    var date = (DateTime)DataGridView_match.CurrentRow.Cells[7].Value;
            //    result.DateMatch.Text = date.ToString("dd/MM/yyyy");

            //    using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            //    {
            //        connection.Open();
            //        string query = "Select CLBName from CLUB where CLBNAME = '" + DataGridView_match.CurrentRow.Cells[2].Value.ToString() + "' or CLBNAME = '" + DataGridView_match.CurrentRow.Cells[6].Value.ToString() + "'";
            //        SqlDataAdapter ada = new SqlDataAdapter(query, connection);
            //        DataSet ds = new DataSet();
            //        ada.Fill(ds);

            //        result.comboBox1.DisplayMember = "CLBName";
            //        result.comboBox1.ValueMember = "CLBNAME";
            //        result.comboBox1.DataSource = ds.Tables[0];
            //    }

            //    var idMatch = DataGridView_match.CurrentRow.Cells[0].Value.ToString();

            //    result.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            try
            {
                ResultDetail1 result = new ResultDetail1(this);

                byte[] img1 = (byte[])DataGridView_match.CurrentRow.Cells[1].Value;
                MemoryStream ms1 = new MemoryStream(img1);
                result.HostImage.Image = Image.FromStream(ms1);

                img1 = (byte[])DataGridView_match.CurrentRow.Cells[5].Value;
                ms1 = new MemoryStream(img1);
                result.VisitImage.Image = Image.FromStream(ms1);

                result.HostName.Text = DataGridView_match.CurrentRow.Cells[2].Value.ToString();

                if (result.HostName.Text.Length >= 11)
                {
                    result.HostName.Location = new Point(result.HostImage.Location.X - 30, 126);
                }

                result.VisitName.Text = DataGridView_match.CurrentRow.Cells[6].Value.ToString();

                if (result.VisitName.Text.Length >= 11)
                {
                    result.VisitName.Location = new Point(result.VisitImage.Location.X - 30, 126);
                }


                result.Score1.Text = DataGridView_match.CurrentRow.Cells[3].Value.ToString();
                result.Score2.Text = DataGridView_match.CurrentRow.Cells[4].Value.ToString();
                result.StadiumName.Text = DataGridView_match.CurrentRow.Cells[9].Value.ToString();
                result.ID_txt.Text = DataGridView_match.CurrentRow.Cells[0].Value.ToString();
                result.RefereeName.Text = GetNameRef(result.ID_txt.Text);
                var date = (DateTime)DataGridView_match.CurrentRow.Cells[7].Value;
                result.DateMatch.Text = date.ToString("dd/MM/yyyy");

                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "Select CLBName from CLUB where CLBNAME = '" + DataGridView_match.CurrentRow.Cells[2].Value.ToString() + "' or CLBNAME = '" + DataGridView_match.CurrentRow.Cells[6].Value.ToString() + "'";
                    SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);

                    result.comboBox1.DisplayMember = "CLBName";
                    result.comboBox1.ValueMember = "CLBNAME";
                    result.comboBox1.DataSource = ds.Tables[0];
                }

                var idMatch = DataGridView_match.CurrentRow.Cells[0].Value.ToString();

                result.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadPl(string id, ResultDetail result,string idclub)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "select F1.PLNAME as F1,G.TIME_GOAL,F2.PLNAME as F2,G.TIME_ASSIST from GOAL as G, FOOTBALL_PLAYER as F1, FOOTBALL_PLAYER as F2 where F1.IDPL = G.IDPL and G.IDMATCH = '" + id + "' and G.IDCLB = '" + idclub+ "' and F2.IDPL = G.IDPLA";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                Label nameHost, timeHost, nameHostA, timeHostA;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nameHost = new Label();
                    timeHost = new Label();

                    nameHost.Text = dt.Rows[i]["F1"].ToString();
                    nameHost.AutoSize = true;

                    timeHost.Text = dt.Rows[i]["TIME_GOAL"].ToString() + "'";
                    timeHost.AutoSize = true;

                    result.flowLayoutPanel2.Controls.Add(nameHost);
                    result.flowLayoutPanel2.Controls.Add(timeHost);

                    nameHostA = new Label();
                    timeHostA = new Label();

                    nameHostA.Text = dt.Rows[i]["F2"].ToString();
                    nameHostA.AutoSize = true;

                    timeHostA.Text = dt.Rows[i]["TIME_ASSIST"].ToString() + "'";
                    timeHostA.AutoSize = true;

                    result.flowLayoutPanel4.Controls.Add(nameHostA);
                    result.flowLayoutPanel4.Controls.Add(timeHostA);
                }

                connection.Close();
            }
        }

        private void LoadPlA(string id, ResultDetail result,string idclub)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "select F1.PLNAME as F1,G.TIME_GOAL,F2.PLNAME as F2,G.TIME_ASSIST from GOAL as G, FOOTBALL_PLAYER as F1, FOOTBALL_PLAYER as F2 where F1.IDPL = G.IDPL and G.IDMATCH = '" + id + "' and G.IDCLB = '" + idclub + "' and F2.IDPL = G.IDPLA";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                Label nameHost, timeHost, nameHostA, timeHostA;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nameHost = new Label();
                    timeHost = new Label();

                    nameHost.Text = dt.Rows[i]["F1"].ToString();
                    nameHost.AutoSize = true;

                    timeHost.Text = dt.Rows[i]["TIME_GOAL"].ToString() + "'";
                    timeHost.AutoSize = true;

                    result.flowLayoutPanel1.Controls.Add(nameHost);
                    result.flowLayoutPanel1.Controls.Add(timeHost);

                    nameHostA = new Label();
                    timeHostA = new Label();

                    nameHostA.Text = dt.Rows[i]["F2"].ToString();
                    nameHostA.AutoSize = true;

                    timeHostA.Text = dt.Rows[i]["TIME_ASSIST"].ToString() + "'";
                    timeHostA.AutoSize = true;

                    result.flowLayoutPanel3.Controls.Add(nameHostA);
                    result.flowLayoutPanel3.Controls.Add(timeHostA);
                }

                connection.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select IDMatch, T1.PIC,T1.CLBNAME,SCORED1,SCORED2,T2.PIC,T2.CLBNAME, DATE,TIME, STAYDIUM from CLUB as T1, CLUB as T2, MATCH1 as M where M.CLB1 = T1.IDCLB and " +
                    "M.CLB2 = T2.IDCLB and DATE = '" + dateTimePicker1.Value + "'";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_match.DataSource = dt;

                DataGridView_match.Columns[0].HeaderText = "ID";
                DataGridView_match.Columns[1].HeaderText = "";
                DataGridView_match.Columns[2].HeaderText = "Host team";
                DataGridView_match.Columns[3].HeaderText = "Score";
                DataGridView_match.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DataGridView_match.Columns[4].HeaderText = "";
                DataGridView_match.Columns[5].HeaderText = "";
                DataGridView_match.Columns[6].HeaderText = "Visit team";
                DataGridView_match.Columns[7].HeaderText = "Date";
                DataGridView_match.Columns[8].HeaderText = "Time";
                DataGridView_match.Columns[9].HeaderText = "Stadium";

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_match.Columns[1];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridViewImageColumn imageColumn1 = new DataGridViewImageColumn();
                imageColumn1 = (DataGridViewImageColumn)DataGridView_match.Columns[5];
                imageColumn1.ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridView_match.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
                DataGridView_match.Columns[8].DefaultCellStyle.Format = @"hh\:mm";

                DataGridView_match.Columns[0].Width = 70;
                DataGridView_match.Columns[1].Width = 50;
                DataGridView_match.Columns[2].Width = 170;
                DataGridView_match.Columns[3].Width = 60;
                DataGridView_match.Columns[4].Width = 50;
                DataGridView_match.Columns[5].Width = 50;
                DataGridView_match.Columns[6].Width = 170;
                DataGridView_match.Columns[7].Width = 130;
                DataGridView_match.Columns[8].Width = 100;
                DataGridView_match.Columns[9].Width = 140;


                connection.Close();
            }
        }
    }
}
