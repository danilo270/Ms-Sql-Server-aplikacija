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
    public partial class izmeni_radnika : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public izmeni_radnika(string s)
        {
            this.connString = s;
            InitializeComponent();
        }

        private void izmeni_radnika_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                using (SqlCommand com = new SqlCommand("SELECT ime FROM radnik", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add((string)reader["ime"]);
                        }
                    }
                }
                using (SqlCommand com = new SqlCommand("SELECT id_proj FROM projekti", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox2.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox2.Items.Add((Int16)reader["id_proj"]);
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
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string insert_query = "update radnik set ime=@ime,prezime=@prezime,plata=@plata,id_proj=@id_proj,dat_zap=@dat_zap where ime=@zad_ime";
                SqlCommand cmd = new SqlCommand(insert_query, conn);
                if ((textBox1.Text.ToString()).Length == 0 || (textBox2.Text.ToString()).Length == 0 || comboBox1.SelectedIndex<0 ||
                    (textBox3.Text.ToString()).Length == 0||comboBox2.SelectedIndex<0)
                {
                    MessageBox.Show("Polja ne smeju biti prazna!");
                    return;
                }
                if ((textBox1.Text.ToString()).Length > 30 || (textBox2.Text.ToString()).Length > 30)
                {
                    MessageBox.Show("Maksimum broj karaktera za svako polje je 30 molimo vas proverite unos");
                    conn.Close();
                    return;
                }
                cmd.Parameters.AddWithValue("@ime", textBox1.Text);
                cmd.Parameters.AddWithValue("@prezime", textBox2.Text);
                cmd.Parameters.AddWithValue("@id_proj", (Int16)comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@plata", float.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@dat_zap", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@zad_ime", comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspesno izmena podataka");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERORR:" + ex.ToString());

            }
        }
    }
}