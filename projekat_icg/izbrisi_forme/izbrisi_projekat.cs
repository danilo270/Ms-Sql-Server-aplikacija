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
namespace projekat_icg.izbrisi_forme
{
    public partial class izbrisi_projekat : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public izbrisi_projekat(string s)
        {
            this.connString = s;
            InitializeComponent();
        }

        private void izbrisi_projekat_Load(object sender, EventArgs e)
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
                            Int16 id = (Int16)reader["id_proj"];
                            comboBox1.Items.Add(id);
                        }
                    }
                }
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                label3.Text = "Ime projekta:";
                label4.Text = "Datum od:";
                label5.Text = "Datum do:";
                label6.Text = "id sektora:";
                using (SqlCommand com = new SqlCommand("SELECT ime_proj,id_sekt,pocetak_proj,kraj_proj FROM projekti", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((Int16)comboBox1.SelectedItem == (Int16)reader["id_sekt"])
                            {
                                label3.Text += (string)reader["ime_proj"];
                                label4.Text += ((DateTime)reader["pocetak_proj"]).ToShortDateString();
                                label5.Text += ((DateTime)reader["kraj_proj"]).ToShortDateString();
                                label6.Text += (Int16)reader["id_sekt"];
                            }
                        }
                    }
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string insert_query = "Delete from projekti where id_proj=@zad_id";
            SqlCommand cmd = new SqlCommand(insert_query, con);
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Morate izabrati nesto da izbrisete!");
                return;
            }
            cmd.Parameters.AddWithValue("@zad_id", (Int16)comboBox1.SelectedItem);
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni?", "Brisanje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspesno brisanje podataka");
            }
            else if (dialogResult == DialogResult.No)
            {
                con.Close();
                return;
            }

            con.Close();
        }
    }
}