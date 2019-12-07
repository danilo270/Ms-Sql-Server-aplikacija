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
    public partial class izbrisi_radnike : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public izbrisi_radnike(string s)
        {
            this.connString = s;
            InitializeComponent();
        }

        private void izbrisi_radnike_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                using (SqlCommand com = new SqlCommand("SELECT id_radnika FROM radnik", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            Int16 id = (Int16)reader["id_radnika"];
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
                label3.Text = "Ime:";
                label4.Text = "Prezime:";
                label5.Text = "Plata:";
                label6.Text = "Id proj:";
                label7.Text = "Dat zap:";
                using (SqlCommand com = new SqlCommand("SELECT id_radnika,ime,prezime,plata,id_proj,dat_zap FROM radnik", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((Int16)comboBox1.SelectedItem == (Int16)reader["id_radnika"])
                            {
                                label3.Text += (string)reader["ime"];
                                label4.Text += (string)reader["prezime"];
                                label5.Text += (reader["plata"]).ToString();
                                label6.Text += (Int16)reader["id_proj"];
                                label7.Text += ((DateTime)reader["dat_zap"]).ToShortDateString();
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
            string insert_query = "Delete from radnik where id_radnika=@zad_id";
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