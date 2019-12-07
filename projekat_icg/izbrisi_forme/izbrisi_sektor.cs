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
    public partial class izbrisi_sektor : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public izbrisi_sektor(string con)
        {
            this.connString = con;
            InitializeComponent();
        }

        private void izbrisi_sektor_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                using (SqlCommand com = new SqlCommand("SELECT id_sekt FROM sektor", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            Int16 id = (Int16)reader["id_sekt"];
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
                label3.Text = "Ime sektora:";
                label4.Text = "Vodja Sektora:";
                label5.Text = "Id firme:";
                using (SqlCommand com = new SqlCommand("SELECT id_sekt,ime_sekt,vodja_sektora,id_firme FROM sektor", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((Int16)comboBox1.SelectedItem == (Int16)reader["id_sekt"])
                            {
                                label3.Text += (string)reader["ime_sekt"];
                                label4.Text += (string)reader["vodja_sektora"];
                                label5.Text += (Int16)reader["id_firme"];
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
            string insert_query = "Delete from sektor where id_sekt=@zad_id";
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