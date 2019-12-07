using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using projekat_icg.izbrisi_forme;
namespace projekat_icg
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private   SqlConnection myConn;
        private SqlCommand myCmd;
        private SqlDataReader myReader;
        private String results;
        private string connString;
        public Form1()
        {
            connString = @"Server=DESKTOP-4M52SRQ\MSSQLSERVER02;DataBase=Danilo;Integrated Security=SSPI";
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myConn = new SqlConnection(connString);
            myConn.Open();
            myConn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form dodaj = new forma_dodaj(connString);
            dodaj.Show();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form izmeni = new forma_izmeni(connString);
            izmeni.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form izbrisi = new izbrisi_forma(connString);
            izbrisi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form pretraga = new forma_pretraga(connString);
            pretraga.Show();
        }
    }
}
