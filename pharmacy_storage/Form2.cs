using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pharmacy_storage
{
    public partial class Form2 : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=pharma_storage;Username=postgres;Password=1111";
        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private int rowIndex = -1;


        public Form2()
        {
            InitializeComponent();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(ConnectionString);
            Select_worker();
        }
        private void Select_worker()
        {
            try
            {
                conn.Open();
                sql = @"select * from worker";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dgvWorkers.DataSource = null;
                dgvWorkers.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
        private void dgvWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                textBoxID.Text = dgvWorkers.Rows[e.RowIndex].Cells["worker_id"].Value.ToString();
                textBoxName.Text = dgvWorkers.Rows[e.RowIndex].Cells["worker_name"].Value.ToString();
                textBoxSurname.Text = dgvWorkers.Rows[e.RowIndex].Cells["worker_surname"].Value.ToString();
                textBoxLastName.Text = dgvWorkers.Rows[e.RowIndex].Cells["worker_lastname"].Value.ToString();
                textBoxJobPosition.Text = dgvWorkers.Rows[e.RowIndex].Cells["jobposition"].Value.ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int workerId;
            if (!int.TryParse(textBoxID.Text, out workerId))
            {
                MessageBox.Show("Некорректное значение для ID рабочего.");
                return;
            }



            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("workeraddoredit4", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_worker_id", workerId);
                        command.Parameters.AddWithValue("p_worker_name", textBoxName.Text);
                        command.Parameters.AddWithValue("p_worker_surname", textBoxSurname.Text);
                        command.Parameters.AddWithValue("p_worker_lastname", textBoxLastName.Text);
                        command.Parameters.AddWithValue("p_jobposition", textBoxJobPosition.Text);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Рабочий успешно добавлен в таблицу worker.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении рабочего: {ex.Message}");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Select_worker();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    int workerId;
                    if (!int.TryParse(textBoxID.Text, out workerId))
                    {
                        MessageBox.Show("Некорректное значение для ID сотрудника.");
                        return;
                    }

                    using (var command = new NpgsqlCommand("delete_worker", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("p_worker_id", workerId);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Сотрудник успешно удален из таблицы Worker.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}");
                }
            }



        }
    }
}
