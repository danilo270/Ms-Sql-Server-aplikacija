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
    public partial class izmeni_sektor : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public izmeni_sektor(string con)
        {
            connString = con;
            InitializeComponent();
        }

        private void izmeni_sektor_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                using (SqlCommand com = new SqlCommand("SELECT ime_sekt FROM sektor", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add((string)reader["ime_sekt"]);
                        }
                    }
                }
                using (SqlCommand com = new SqlCommand("SELECT id_firme FROM Firma", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox2.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox2.Items.Add((Int16)reader["id_firme"]);
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
                if ((textBox1.Text.ToString()).Length == 0 || (textBox2.Text.ToString()).Length == 0 || comboBox1.SelectedIndex < 0||
                    comboBox2.SelectedIndex<0)
                {
                    MessageBox.Show("Polja ne smeju biti prazna!");
                    return;
                }
                if ((textBox1.Text.ToString()).Length > 30 || (textBox2.Text.ToString()).Length > 30)
                {
                    MessageBox.Show("Maksimum broj karaktera za svako polje je 30 molimo vas proverite unos");
                    con.Close();
                    return;
                }
                string insert_query = "Update sektor set ime_sekt=@ime,vodja_sektora=@vodja_sektora,id_firme=@id_firme where ime_sekt=@zad_ime";
                SqlCommand cmd = new SqlCommand(insert_query, con);
                cmd.Parameters.AddWithValue("@ime", textBox1.Text);
                cmd.Parameters.AddWithValue("@vodja_sektora", textBox2.Text);
                cmd.Parameters.AddWithValue("@id_firme", (Int16)comboBox2.SelectedItem);
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
    }
}