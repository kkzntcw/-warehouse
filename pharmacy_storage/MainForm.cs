using Npgsql;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace pharmacy_storage
{
    public partial class MainForm : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            "localhost", 5432, "postgres", "1111", "pharma_storage"
            );
        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private int rowIndex = -1;
        private List<string[]> rows = null;
        private List<string[]> filteredList = null;

        public MainForm()
        {
            InitializeComponent();

        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            Select_client();
            Select_goods();
            Select_invoice();
            Select_worker();
            Select_seller();
            Select_goods_list();
            Select_test();
            NpgsqlDataReader dataReader = null;
            rows = new List<string[]>();
            string[] row = null;

            try
            {
                conn.Open();
                NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT goods_id,producer,price FROM goods", conn);

                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    row = new string[]
                    {   Convert.ToString(dataReader["goods_id"]),
                        Convert.ToString(dataReader["producer"]),
                        Convert.ToString(dataReader["price"])
                    };

                    rows.Add(row);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }

            RefreshList(rows);

            conn.Close();
        }


        private void RefreshList(List<string[]> list)
        {
            listView2.Items.Clear();

            foreach (string[] s in list)
            {
                listView2.Items.Add(new ListViewItem(s));
            }
        }
        private void Select_test()
        {
            try
            {
                conn.Open();
                sql = @"select * from seller";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
        private void Select_goods_list()
        {
            try
            {
                conn.Open();
                sql = @"select product_name_id, name, batch, instructions from goods_list";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dgvData6.DataSource = null;
                dgvData6.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
        private void Select_client()
        {
            try
            {
                conn.Open();
                sql = @"select * from client";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dgvData.DataSource = null;
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void Select_goods()
        {
            try
            {
                conn.Open();
                sql = @"select * from goods";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dgvData2.DataSource = null;
                dgvData2.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }


        private void Select_invoice()
        {
            try
            {
                conn.Open();
                sql = @"select * from invoice";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dgvData4.DataSource = null;
                dgvData4.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка" + ex.Message);
            }
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
                dgvData5.DataSource = null;
                dgvData5.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void Select_seller()
        {
            try
            {
                conn.Open();
                sql = @"select * from seller";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dgvData3.DataSource = null;
                dgvData3.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления");
                return;
            }

            try
            {
                conn.Open();

                // Получение значения client_id выбранной строки
                int clientId = Convert.ToInt32(dgvData.SelectedRows[0].Cells["client_id"].Value);
                // Формирование SQL-запроса для удаления записи
                sql = @"DELETE FROM client WHERE client_id = @client_id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("client_id", clientId);
                cmd.ExecuteNonQuery();

                conn.Close();

                // Обновление таблицы DataGridView
                Select_client();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e) // Кнопка обновить
        {
            Select_client();
        }




        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                textBoxcompany.Text = dgvData.Rows[e.RowIndex].Cells["company"].Value.ToString();
                textBoxHousenum.Text = dgvData.Rows[e.RowIndex].Cells["house_number"].Value.ToString();
                textBoxPhone.Text = dgvData.Rows[e.RowIndex].Cells["phone"].Value.ToString();
                textBoxInn.Text = dgvData.Rows[e.RowIndex].Cells["client_inn"].Value.ToString();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // Считывание значений из текстовых полей
            string company = textBoxcompany.Text;
            string houseNumber = textBoxHousenum.Text;
            string phone = textBoxPhone.Text;
            string clientInn = textBoxInn.Text;
            string clientId = textBoxId.Text;
            string streetId = textBoxStreetId.Text;
            string citytId = textBoxCityId.Text;

            // Формирование SQL-запроса на обновление
            string query = $"UPDATE client SET company = '{company}', house_number = '{houseNumber}', phone = '{phone}', client_inn = '{clientInn}', street_id = '{streetId}', city_id = '{citytId}' WHERE client_id = '{clientId}';";

            // Выполнение SQL-запроса
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            conn.Open();
            int rowsAffected = command.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Данные успешно сохранены в базе данных.");
            }
            else
            {
                MessageBox.Show("Не удалось сохранить данные в базе данных.");
            }
        }

        private void add_client_btn_Click(object sender, EventArgs e)
        {
            string company = textBoxcompany.Text;
            string houseNumber = textBoxHousenum.Text;
            string phone = textBoxPhone.Text;
            string clientInn = textBoxInn.Text;
            string clientId = textBoxId.Text;
            string streetId = textBoxStreetId.Text;
            string citytId = textBoxCityId.Text;

            // Формирование SQL-запроса
            string query = "INSERT INTO client (client_id,company, house_number, phone, client_inn,street_id,city_id) " +
                           $"VALUES ('{clientId}','{company}', '{houseNumber}', '{phone}', '{clientInn}','{streetId}','{citytId}');";

            // Выполнение SQL-запроса
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            conn.Open();
            int rowsAffected = command.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Данные успешно добавлены в базу данных.");
            }
            else
            {
                MessageBox.Show("Не удалось добавить данные в базу данных.");
            }
        }

        private void textBoxcompany_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvData2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                textBoxGoodsId.Text = dgvData2.Rows[e.RowIndex].Cells["goods_id"].Value.ToString();
                textBoxSellerId.Text = dgvData2.Rows[e.RowIndex].Cells["seller_id"].Value.ToString();
                textboxBegin.Text = dgvData2.Rows[e.RowIndex].Cells["begin"].Value.ToString();
                textBoxEnd.Text = dgvData2.Rows[e.RowIndex].Cells["end"].Value.ToString();
                textBoxProducer.Text = dgvData2.Rows[e.RowIndex].Cells["producer"].Value.ToString();
                textBoxDatecome.Text = dgvData2.Rows[e.RowIndex].Cells["date_come"].Value.ToString();
                textBoxGoods_invoice.Text = dgvData2.Rows[e.RowIndex].Cells["goods_invoice"].Value.ToString();
                textBoxPrice.Text = dgvData2.Rows[e.RowIndex].Cells["price"].Value.ToString();
                textBoxClient_id.Text = dgvData2.Rows[e.RowIndex].Cells["client_id"].Value.ToString();
                textBoxProduct_name_id.Text = dgvData2.Rows[e.RowIndex].Cells["product_name_id"].Value.ToString();
                textBoxInvoiceId.Text = dgvData2.Rows[e.RowIndex].Cells["invoice_id"].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string goods_id = textBoxGoodsId.Text;
            string seller_id = textBoxSellerId.Text;
            string begin = textboxBegin.Text;
            string end = textBoxEnd.Text;
            string producer = textBoxProducer.Text;
            string date_come = textBoxDatecome.Text;
            string goods_invoice = textBoxGoods_invoice.Text;
            string price = textBoxPrice.Text;
            string client_id = textBoxClient_id.Text;
            string product_name_id = textBoxProduct_name_id.Text;
            string invoice_id = textBoxInvoiceId.Text;

            // Формирование SQL-запроса
            string query = "INSERT INTO goods (goods_id,seller_id, begin, end, producer, date_come, goods_invoice, price, client_id, product_name_id, invoice_id) " +
                           $"VALUES ('{goods_id}','{seller_id}', '{begin}', '{end}', '{producer}','{date_come}','{goods_invoice}','{price}','{client_id}','{product_name_id}','{invoice_id}');";

            // Выполнение SQL-запроса
            NpgsqlCommand command = new(query, conn);
            conn.Open();
            int rowsAffected = command.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Данные успешно добавлены в базу данных.");
            }
            else
            {
                MessageBox.Show("Не удалось добавить данные в базу данных.");
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {
            Select_goods();
        }

        private void dgvData5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                textBox1.Text = dgvData5.Rows[e.RowIndex].Cells["worker_id"].Value.ToString();
                textBoxName.Text = dgvData5.Rows[e.RowIndex].Cells["worker_name"].Value.ToString();
                textBoxSurname.Text = dgvData5.Rows[e.RowIndex].Cells["worker_surname"].Value.ToString();
                textBoxLastname.Text = dgvData5.Rows[e.RowIndex].Cells["worker_lastname"].Value.ToString();
                textBoxJobposition.Text = dgvData5.Rows[e.RowIndex].Cells["jobposition"].Value.ToString();

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string worker_id = textBox1.Text;
            string worker_name = textBoxName.Text;
            string worker_surname = textBoxSurname.Text;
            string worker_lastname = textBoxLastname.Text;
            string worker_jobposition = textBoxJobposition.Text;


            // Формирование SQL-запроса
            string query = "INSERT INTO worker (worker_id,worker_name, worker_surname, worker_lastname, jobposition) " +
                           $"VALUES ('{worker_id}','{worker_name}', '{worker_surname}', '{worker_lastname}', '{worker_jobposition}');";

            // Выполнение SQL-запроса
            NpgsqlCommand command = new(query, conn);
            conn.Open();
            int rowsAffected = command.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Данные успешно добавлены в базу данных.");
            }
            else
            {
                MessageBox.Show("Не удалось добавить данные в базу данных.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dgvData2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления");
                return;
            }

            try
            {
                conn.Open();

                // Получение значения client_id выбранной строки
                int goodsId = Convert.ToInt32(dgvData2.SelectedRows[0].Cells["goods_id"].Value);
                // Формирование SQL-запроса для удаления записи
                sql = @"DELETE FROM goods WHERE goods_id = @goods_id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("goods_id", goodsId);
                cmd.ExecuteNonQuery();

                conn.Close();

                // Обновление таблицы DataGridView
                Select_goods();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (dgvData5.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления");
                return;
            }

            try
            {
                conn.Open();

                // Получение значения client_id выбранной строки
                int worker_id = Convert.ToInt32(dgvData5.SelectedRows[0].Cells["worker_id"].Value);
                // Формирование SQL-запроса для удаления записи
                sql = @"DELETE FROM worker WHERE worker_id = @worker_id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("worker_id", worker_id);
                cmd.ExecuteNonQuery();

                conn.Close();

                // Обновление таблицы DataGridView
                Select_worker();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void selectbtn_Click(object sender, EventArgs e)
        {
            string query = textBox2testsql.Text; // Получение SQL-запроса из текстового поля

            {
                conn.Open();

                DataTable dataTable = new DataTable();

                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }

                selectdgv.DataSource = dataTable;
            }
        }

        private void selectdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.GridLines = true;
            conn.Open();
            NpgsqlDataReader dataReader = null;

            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT client_id, company, street_id FROM client", conn);

                dataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (dataReader.Read())
                {
                    item = new ListViewItem(new string[]
                    {   Convert.ToString(dataReader["client_id"]),
                        Convert.ToString(dataReader["company"]),
                        Convert.ToString(dataReader["street_id"])
                    });

                    listView1.Items.Add(item);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
            conn.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.GridLines = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"seller LIKE '%{textBox2.Text}%'";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"house_number <= 50";

                    break;
                case 1:

                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"house_number >= 50 AND house_number <= 70";

                    break;
                case 2:

                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"house_number >= 110";

                    break;
                case 3:

                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";

                    break;

            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            filteredList = rows.Where((x) =>
            x[1].ToLower().Contains(textBox3.Text.ToLower())).ToList();

            RefreshList(filteredList);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:

                    filteredList = rows.Where((x) =>
                    Double.Parse(x[2]) <= 1000).ToList();

                    RefreshList(filteredList);

                    break;
                case 1:

                    filteredList = rows.Where((x) =>
                    Double.Parse(x[2]) > 1500 && Double.Parse(x[2]) <= 10000).ToList();

                    RefreshList(filteredList);

                    break;
                case 2:

                    filteredList = rows.Where((x) =>
                    Double.Parse(x[2]) > 10000).ToList();

                    RefreshList(filteredList);

                    break;
                case 3:

                    RefreshList(rows);

                    break;

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();

        }
    }
}