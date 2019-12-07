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

namespace projekat_icg
{
    public partial class dodaj_firmu : DevExpress.XtraEditors.XtraForm
    {
        private string connString;
        public dodaj_firmu(string connString)
        {

            this.connString = connString;
            InitializeComponent();
        }

        private void dodaj_firmu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string insert_query = "insert into Firma (ime,mesto,vlasnik)";
                insert_query += "values (@ime ,@mesto ,@vlasnik);";
                insert_query += "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(insert_query, conn);
                if((textBox1.Text.ToString()).Length == 0 || (textBox2.Text.ToString()).Length == 0 || (textBox3.Text.ToString()).Length == 0)
                {
                    MessageBox.Show("Polja ne smeju biti prazna!");
                    return;
                }
                if ((textBox1.Text.ToString()).Length > 30 || (textBox2.Text.ToString()).Length > 30 || (textBox3.Text.ToString()).Length > 30)
                {
                    MessageBox.Show("Maksimum broj karaktera za svako polje je 30 molimo vas proverite unos");
                    conn.Close();
                    return;
                }
                cmd.Parameters.AddWithValue("@ime", textBox1.Text);
                cmd.Parameters.AddWithValue("@mesto", textBox2.Text);
                cmd.Parameters.AddWithValue("@vlasnik", textBox3.Text);
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