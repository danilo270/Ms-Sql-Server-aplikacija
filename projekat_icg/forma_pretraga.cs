using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
namespace projekat_icg
{
    public partial class forma_pretraga : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public forma_pretraga(string s)
        {
            this.connString = s;
            InitializeComponent();
        }

        private void forma_pretraga_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add((string)reader["TABLE_NAME"]);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Firma"))
            {
                if (comboBox2.SelectedItem.Equals("id_firme"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from firma where id_firme like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("ime"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from firma where ime like '%' + @zad_ime + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_ime", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("mesto"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from firma where mesto like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("vlasnik"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from firma where vlasnik like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
            if (comboBox1.SelectedItem.Equals("sektor"))
            {
                if (comboBox2.SelectedItem.Equals("id_sekt"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from sektor where id_sekt like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("ime_sekt"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from sektor where ime_sekt like '%' + @zad_ime + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_ime", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("vodja_sektora"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from sektor where vodja_sektora like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("id_firme"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from sektor where id_firme like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
            if (comboBox1.SelectedItem.Equals("projekti"))
            {
                if (comboBox2.SelectedItem.Equals("id_proj"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from projekti where id_proj like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("id_sekt"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from projekti where id_sekt like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("pocetak_proj"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    if (dateTimePicker1.Value > dateTimePicker2.Value)
                    {
                        MessageBox.Show("Unesite ispravan datum!");
                        return;
                    }
                    string query = "select * from projekti where pocetak_proj between @dat_pocetak and @dat_kraj";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@dat_pocetak", dateTimePicker1.Value);
                    com.Parameters.AddWithValue("@dat_kraj", dateTimePicker2.Value);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("kraj_proj"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    if (dateTimePicker1.Value > dateTimePicker2.Value)
                    {
                        MessageBox.Show("Unesite ispravan datum!");
                        return;
                    }
                    string query = "select * from projekti where kraj_proj between @dat_pocetak and @dat_kraj";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@dat_pocetak", dateTimePicker1.Value);
                    com.Parameters.AddWithValue("@dat_kraj", dateTimePicker2.Value);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("ime_proj"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from projekti where ime_proj like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
            if (comboBox1.SelectedItem.Equals("radnik"))
            {
                if (comboBox2.SelectedItem.Equals("id_radnika"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from radnik where id_radnika like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("ime"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from radnik where ime like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("prezime"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from radnik where prezime like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("plata"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from radnik where plata between @od and @do";
                    SqlCommand com = new SqlCommand(query, conn);
                    if(Int32.Parse(textBox2.Text)> Int32.Parse(textBox1.Text))
                    {
                        MessageBox.Show("Unesite pravilan obseg!");
                        return;
                    }
                    com.Parameters.AddWithValue("@do", textBox1.Text);
                    com.Parameters.AddWithValue("@od", textBox2.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("id_proj"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string query = "select * from radnik where id_proj like '%' + @zad_mesto + '%'";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@zad_mesto", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                if (comboBox2.SelectedItem.Equals("dat_zap"))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    if (dateTimePicker1.Value > dateTimePicker2.Value)
                    {
                        MessageBox.Show("Unesite ispravan datum!");
                        return;
                    }
                    string query = "select * from radnik where dat_zap between @dat_pocetak and @dat_kraj";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@dat_pocetak", dateTimePicker1.Value);
                    com.Parameters.AddWithValue("@dat_kraj", dateTimePicker2.Value);
                    DataTable dt = new DataTable();
                    SqlDataAdapter addapter = new SqlDataAdapter(com);
                    addapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("select column_name  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=@ime_tabele", con))
                {
                    com.Parameters.AddWithValue("@ime_tabele", comboBox1.SelectedItem);
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox2.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox2.Items.Add((string)reader["column_name"]);
                        }
                    }
                }
                con.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem.Equals("dat_zap")|| comboBox2.SelectedItem.Equals("pocetak_proj")
                || comboBox2.SelectedItem.Equals("kraj_proj"))
            {
                label4.Visible = true;
                label5.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                return;
            }
            if (comboBox2.SelectedItem.Equals("plata"))
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                return;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                textBox1.Visible = true;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                return;
            }
        }
    }
}