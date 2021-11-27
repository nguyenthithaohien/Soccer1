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
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
            LoadRanking();
        }

        private void Ranking_Load_1(object sender, EventArgs e)
        {
            ///LoadRanking();
        }

        public void LoadRanking()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select ROW_NUMBER() OVER(ORDER BY PTS desc) Position, C.PIC, C.CLBNAME, PL, W, D,L,GF,GA,GD,PTS from BXH as B, CLUB as C where C.IDCLB = B.IDCLB";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_ranking.DataSource = dt;

                //DataGridView_ranking.Columns[0].HeaderText = "Po";
                DataGridView_ranking.Columns[1].HeaderText = "";
                DataGridView_ranking.Columns[2].HeaderText = "Name";
                DataGridView_ranking.Columns[3].HeaderText = "Played";
                DataGridView_ranking.Columns[4].HeaderText = "Won";
                DataGridView_ranking.Columns[5].HeaderText = "Drawn";
                DataGridView_ranking.Columns[6].HeaderText = "Lost";
                DataGridView_ranking.Columns[7].HeaderText = "GF";
                DataGridView_ranking.Columns[8].HeaderText = "GA";
                DataGridView_ranking.Columns[9].HeaderText = "GD";
                DataGridView_ranking.Columns[10].HeaderText = "Points";
                //DataGridView_ranking.Columns[3].HeaderText = "Position";

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_ranking.Columns[1];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridView_ranking.Columns[0].Width = 50;
                DataGridView_ranking.Columns[1].Width = 40;
                DataGridView_ranking.Columns[2].Width = 200;
                DataGridView_ranking.Columns[3].Width = 50;
                DataGridView_ranking.Columns[4].Width = 50;
                DataGridView_ranking.Columns[5].Width = 50;
                DataGridView_ranking.Columns[6].Width = 50;
                DataGridView_ranking.Columns[7].Width = 50;
                DataGridView_ranking.Columns[8].Width = 50;
                DataGridView_ranking.Columns[9].Width = 50;
                DataGridView_ranking.Columns[10].Width = 50;

                this.DataGridView_ranking.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                connection.Close();
            }
        }
    }
}
