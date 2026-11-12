using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Toli
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=Dictionary3Lang.db";
        int selectedId = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDatabaseAndTable();
            LoadData();
        }

        private void CreateDatabaseAndTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    CREATE TABLE IF NOT EXISTS Dictionary (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        English TEXT NOT NULL,
                        Russian TEXT NOT NULL,
                        Mongolian TEXT NOT NULL
                    );";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadData(string searchQuery = "")
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, English AS 'Англи', Russian AS 'Орос', Mongolian AS 'Монгол' FROM Dictionary";

                if (!string.IsNullOrEmpty(searchQuery))
                {
                    query += " WHERE English LIKE @search OR Russian LIKE @search OR Mongolian LIKE @search";
                }

                using (var command = new SqliteCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        command.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnglish.Text) ||
                string.IsNullOrWhiteSpace(txtRussian.Text) ||
                string.IsNullOrWhiteSpace(txtMongolian.Text))
            {
                MessageBox.Show("Гурван хэлний үгийг бүгдийг нь оруулна уу!");
                return;
            }

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Dictionary (English, Russian, Mongolian) VALUES (@en, @ru, @mn)";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@en", txtEnglish.Text.Trim());
                    cmd.Parameters.AddWithValue("@ru", txtRussian.Text.Trim());
                    cmd.Parameters.AddWithValue("@mn", txtMongolian.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }

            ClearInputs();
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id"].Value);
                txtEnglish.Text = row.Cells["Англи"].Value.ToString();
                txtRussian.Text = row.Cells["Орос"].Value.ToString();
                txtMongolian.Text = row.Cells["Монгол"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Засах мөрөө хүснэгтээс сонгоно уу!");
                return;
            }

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Dictionary SET English = @en, Russian = @ru, Mongolian = @mn WHERE Id = @id";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@en", txtEnglish.Text.Trim());
                    cmd.Parameters.AddWithValue("@ru", txtRussian.Text.Trim());
                    cmd.Parameters.AddWithValue("@mn", txtMongolian.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", selectedId);
                    cmd.ExecuteNonQuery();
                }
            }

            ClearInputs();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Устгах мөрөө хүснэгтээс сонгоно уу!");
                return;
            }

            if (MessageBox.Show("Устгах уу?", "Баталгаажуулах", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Dictionary WHERE Id = @id";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                }

                ClearInputs();
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void ClearInputs()
        {
            txtEnglish.Clear();
            txtRussian.Clear();
            txtMongolian.Clear();
            selectedId = 0;
        }
    }
}