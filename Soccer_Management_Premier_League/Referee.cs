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
    public partial class Referee : Form
    {
        public Referee()
        {
            InitializeComponent();
        }

        public void LoadReferee()
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select IDREF, REF_NAME, NATIONALITY, DAY_BORN, TYPE_REF from REFEREE";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                DataGridView_referee.DataSource = dt;
                DataGridView_referee.Columns[0].HeaderText = "ID";
                DataGridView_referee.Columns[1].HeaderText = "Name";
                DataGridView_referee.Columns[2].HeaderText = "Nationality";
                DataGridView_referee.Columns[3].HeaderText = "Birthday";
                DataGridView_referee.Columns[4].HeaderText = "Type";

                DataGridView_referee.Columns[0].Width = 60;
                DataGridView_referee.Columns[1].Width = 100;
                DataGridView_referee.Columns[2].Width = 100;
                DataGridView_referee.Columns[3].Width = 80;
                DataGridView_referee.Columns[4].Width = 130;

                connection.Close();
            }
        }
        private void Referee_Load(object sender, EventArgs e)
        {
            LoadReferee();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                AddReferee form1 = new AddReferee(this);

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                if (DataGridView_referee.Rows.Count != 0)
                {
                    EditReferee form1 = new EditReferee(this);

                    //form1.text_id.Text = DataGridView_referee.CurrentRow.Cells[0].Value.ToString();
                    form1.text_name.Text = DataGridView_referee.CurrentRow.Cells[1].Value.ToString();
                    form1.text_nation.Text = DataGridView_referee.CurrentRow.Cells[2].Value.ToString();
                    form1.date_birth.Value = (DateTime)DataGridView_referee.CurrentRow.Cells[3].Value;
                    form1.text_type.Text = DataGridView_referee.CurrentRow.Cells[4].Value.ToString();
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
                }
                else
                {
                    MessageBox.Show("No referee. Please add referee");
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

        private void DataGridView_referee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to remove this referee", "Remove referee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KBHC686\SQLEXPRESS;Initial Catalog=QLDB;Integrated Security=True"))
                    {
                        connection.Open();
                        string query = "Delete from REFEREE where IDREF = '" + DataGridView_referee.CurrentRow.Cells[0].Value.ToString() + "'";

                        SqlCommand command = new SqlCommand(query, connection);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Referee Removed", "Remove referee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadReferee();

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
