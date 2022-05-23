using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Arduino_veri_alma
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\\Database1.mdb");
        private void verilerigörüntüle()
        {
            listView1.Items.Clear();
            bag.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = ("Select * From Veriler");
            OleDbDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["AnalogDeger"].ToString();
                ekle.SubItems.Add(oku["Saat"].ToString());
                ekle.SubItems.Add(oku["NumuneDurumu"].ToString());
                ekle.SubItems.Add(oku["NemOranı"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                listView1.Items.Add(ekle);
            }
            bag.Close();
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
            
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
