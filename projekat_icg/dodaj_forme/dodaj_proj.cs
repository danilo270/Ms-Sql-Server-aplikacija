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
    public partial class dodaj_proj : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public dodaj_proj(string con)
        {
            this.connString = con;
            InitializeComponent();
        }

        private void dodaj_proj_Load(object sender, EventArgs e)
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
                            comboBox1.Items.Add((Int16)reader["id_sekt"]);
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
                string insert_query = "insert into projekti (ime_proj,id_sekt,pocetak_proj,kraj_proj)";
                insert_query += "values (@ime_proj,@id_sekt,@pocetak_proj,@kraj_proj);";
                insert_query += "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(insert_query, conn);
                if(dateTimePicker1.Value > dateTimePicker2.Value)
                {
                    MessageBox.Show("Molimo vas unesite ispravan datum!");
                    return;
                }
                
                if ((textBox1.Text.ToString()).Length == 0 || comboBox1.SelectedIndex<0)
                {
                    MessageBox.Show("Polja ne smeju biti prazna!");
                    return;
                }
                if ((textBox1.Text.ToString()).Length > 30)
                {
                    MessageBox.Show("Maksimum broj karaktera za svako polje je 30 molimo vas proverite unos");
                    conn.Close();
                    return;
                }
                cmd.Parameters.AddWithValue("@ime_proj", textBox1.Text);
                cmd.Parameters.AddWithValue("@pocetak_proj", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@kraj_proj", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@id_sekt", (Int16)comboBox1.SelectedItem);
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