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
    public partial class izmeni_firmu : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public izmeni_firmu(string connString1)
        {
            this.connString = connString1;
            InitializeComponent();
        }

        private void izmeni_firmu_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                using (SqlCommand com = new SqlCommand("SELECT ime FROM Firma", con))
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
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string ime = comboBox1.SelectedItem.ToString();
                SqlConnection con = new SqlConnection(connString);
                if (comboBox1.SelectedIndex<0)
                {
                    MessageBox.Show("Polja ne smeju biti prazna!");
                    return;
                }
                if ((textBox1.Text.ToString()).Length == 0 || (textBox2.Text.ToString()).Length == 0 || (textBox3.Text.ToString()).Length == 0)
                {
                    MessageBox.Show("Polja ne smeju biti prazna!");
                    return;
                }
                if ((textBox1.Text.ToString()).Length > 30 || (textBox2.Text.ToString()).Length > 30 || (textBox3.Text.ToString()).Length > 30)
                {
                    MessageBox.Show("Maksimum broj karaktera za svako polje je 30 molimo vas proverite unos");
                    con.Close();
                    return;
                }
                con.Open();
                string insert_query = "Update Firma set ime=@ime,mesto=@mesto,vlasnik=@vlasnik where ime=@zad_ime";
                SqlCommand cmd = new SqlCommand(insert_query, con);
                cmd.Parameters.AddWithValue("@ime", textBox1.Text);
                cmd.Parameters.AddWithValue("@mesto", textBox2.Text);
                cmd.Parameters.AddWithValue("@vlasnik", textBox3.Text);
                cmd.Parameters.AddWithValue("@zad_ime", ime);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspesna izmena podataka");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" +ex.ToString());
                throw;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}