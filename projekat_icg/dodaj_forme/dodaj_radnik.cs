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
namespace projekat_icg.dodaj_forme
{
    public partial class dodaj_radnik : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public dodaj_radnik(string s)
        {
            this.connString = s;
            InitializeComponent();
        }

        private void dodaj_radnik_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                using (SqlCommand com = new SqlCommand("SELECT id_proj FROM projekti", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add((Int16)reader["id_proj"]);
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
                string insert_query = "insert into radnik (ime,prezime,plata,id_proj,dat_zap)";
                insert_query += "values (@ime ,@prezime,@plata,@id_proj,@dat_zap);";
                insert_query += "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(insert_query, conn);
                if ((textBox1.Text.ToString()).Length == 0 || (textBox2.Text.ToString()).Length == 0 || comboBox1.SelectedIndex < 0 ||
                    (textBox3.Text.ToString()).Length == 0)
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
                cmd.Parameters.AddWithValue("@id_proj", (Int16)comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@plata", float.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@dat_zap", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspesno dodavanje podataka");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERORR:" + ex.ToString());

            }
        }
    }
}