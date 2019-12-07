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
using projekat_icg.izmeni_forme;
namespace projekat_icg
{
    public partial class forma_izmeni : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public forma_izmeni(string connString)
        {
            this.connString = connString;
            InitializeComponent();
        }

        private void forma_izmeni_Load(object sender, EventArgs e)
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Firma"))
            {
                Form firma = new izmeni_firmu(connString);
                firma.Show();
            }
            if (comboBox1.SelectedItem.Equals("sektor"))
            {
                Form sektor = new izmeni_sektor(connString);
                sektor.Show();
            }
            if(comboBox1.SelectedItem.Equals("projekti"))
            {
                Form projekti = new izmeni_projekte(connString);
                projekti.Show();
            }
            if (comboBox1.SelectedItem.Equals("radnik"))
            {
                Form radnik = new izmeni_radnika(connString);
                radnik.Show();
            }
        }
    }
}