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
namespace projekat_icg.izmeni_forme
{
    public partial class izmeni_projekte : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public izmeni_projekte(string s)
        {
            this.connString = s;
            InitializeComponent();
        }

        private void izmeni_projekte_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                using (SqlCommand com = new SqlCommand("SELECT ime_proj FROM projekti", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add((string)reader["ime_proj"]);
                        }
                    }
                }
                using (SqlCommand com = new SqlCommand("SELECT id_sekt FROM sektor", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox2.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox2.Items.Add((Int16)reader["id_sekt"]);
                        }
                    }
                }

                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ime = comboBox1.SelectedItem.ToString();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                if (dateTimePicker1.Value > dateTimePicker2.Value)
                {
                    MessageBox.Show("Molimo vas unesite ispravan datum!");
                    return;
                }

                if ((textBox1.Text.ToString()).Length == 0 || comboBox1.SelectedIndex <0|| comboBox2.SelectedIndex < 0)
                {
                    MessageBox.Show("Polja ne smeju biti prazna!");
                    return;
                }
                string insert_query = "Update projekti set ime_proj=@ime_proj,id_sekt=@id_sekt,pocetak_proj=@pocetak_proj,kraj_proj=@kraj_proj where ime_proj=@zad_ime";
                SqlCommand cmd = new SqlCommand(insert_query, con);
                cmd.Parameters.AddWithValue("@ime_proj", textBox1.Text);
                cmd.Parameters.AddWithValue("@id_sekt", (Int16)comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@pocetak_proj",dateTimePicker1.Value );
                cmd.Parameters.AddWithValue("@kraj_proj", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@zad_ime", ime);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspesna izmena podataka");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.ToString());
                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}