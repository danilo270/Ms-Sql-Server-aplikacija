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
    public partial class izbrisi_forma : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public izbrisi_forma(string connString1)
        {
            this.connString = connString1;
            InitializeComponent();
        }

        private void izbrisi_forma_Load(object sender, EventArgs e)
        {
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
                con.Close();      
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Firma"))
            {
                Form izbrisi_firmu1 = new izbrisi_firmu(connString);
                izbrisi_firmu1.Show();
            }
            if (comboBox1.SelectedItem.Equals("sektor"))
            {
                Form izbrisi_sektor = new izbrisi_sektor(connString);
                izbrisi_sektor.Show();
            }
            if (comboBox1.SelectedItem.Equals("projekti"))
            {
                Form izbrisi_projekte = new izbrisi_projekat(connString);
                izbrisi_projekte.Show();
            }
            if (comboBox1.SelectedItem.Equals("radnik"))
            {
                Form izbrisi_radnike = new izbrisi_radnike(connString);
                izbrisi_radnike.Show();
            }

        }
    }
}