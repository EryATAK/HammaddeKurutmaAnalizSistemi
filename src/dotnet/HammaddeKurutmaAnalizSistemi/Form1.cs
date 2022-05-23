using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.OleDb;
namespace Arduino_veri_alma
{
    public partial class Form1 : Form
    {
        string[] portlar = SerialPort.GetPortNames();
        double a;
        string b;

        double c, nemoran;
        
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\\Database1.mdb");
        private void verilerigörüntüle()
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = ("Select * From Veriler");
            OleDbDataReader oku = komut.ExecuteReader();
        }   
                private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
            
            //comboBox1.Hide();
           
            foreach (string port in portlar)
            {
                comboBox1.Items.Add(port);
                comboBox1.SelectedIndex = 0;
            }
            comboBox2.Items.Add("4800");
            comboBox2.Items.Add("9600");
            comboBox2.SelectedIndex = 1;
            label2.Text = "Bağlantı kapalı";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            string sonuc = serialPort1.ReadLine();
            b = sonuc;
            label1.Text = sonuc + "";
            a = Convert.ToDouble(sonuc);
            //comboBox3.Items.Add(sonuc);
            c = (a * 100) / 1023;
            nemoran = 100 - c;


            if (Convert.ToInt16(sonuc) < 850)
            {

                button3.BackColor = Color.Blue;
                listBox1.Items.Insert(0, sonuc + "                " + label3.Text + "          ISLAK                  %" + nemoran.ToString("N2"));
                label9.ForeColor = Color.Blue;
                label9.Text = "Kurutma işlemi yapılıyor.";

            }
            else if (Convert.ToInt16(sonuc) >= 850)
            {
                button3.BackColor = Color.Yellow;
                listBox1.Items.Insert(0, sonuc + "              " + label3.Text + "          KURU                  %" + nemoran.ToString("N2"));
                label9.ForeColor = Color.Red;
                label9.Text = "Kurutma işlemi sona erdi.";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.ScrollAlwaysVisible = false;

            label9.Show();
            timer1.Start();
            if (serialPort1.IsOpen == false)
            {
                if (comboBox1.Text == "")
                    return;
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt16(comboBox2.Text);
                try
                {
                    serialPort1.Open();
                    label2.Text = "bağlantı açık";
                }
                catch (Exception hata)
                {
                    MessageBox.Show("hata:" + hata.Message);

                }
            }
            else
            {
                label2.Text = "bağlantı kuruldu";
            }

            
            }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                label2.Text = "Bağlantı kapalı";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {


            Form2 frm2 = new Form2();
            frm2.Show();
            //this.Hide();
            
            //if (Convert.ToInt16(a) < 850)
            //{
            //    comboBox3.Items.Add(a + "        " +  " ISLAK" );

                
                
            //}
            //else if (Convert.ToInt16(a) >= 850)
            //{
            //    comboBox3.Items.Add(a + "      " +  " KURU");
                
            //}
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label3.Text = dt.ToLongTimeString();
            label16.Text = dt.ToLongDateString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            bag.Open();
            //string sonuc = serialPort1.ReadExisting();
            //label1.Text = sonuc + "";
            //a = Convert.ToDouble(sonuc);
            //comboBox3.Items.Add(sonuc);
            c = (a * 100) / 1023;
            nemoran = 100 - c;

            if (Convert.ToInt16(b) < 850)
            {

                button3.BackColor = Color.Blue;
                listBox2.Items.Insert(0, b + "                " + label3.Text + "          ISLAK                  %" + nemoran.ToString("N2"));
                OleDbCommand komut = new OleDbCommand("insert into Veriler (AnalogDeger,Saat,NumuneDurumu,NemOranı,Tarih) values ('" + b + "','" + label3.Text.ToString() + "','" + "ISLAK" + "','" + "% " + nemoran + "','" + label16.Text.ToString()+"')", bag);
                komut.ExecuteNonQuery();
                bag.Close();

            }
            else if (Convert.ToInt16(b) >= 850)
            {
                button3.BackColor = Color.Yellow;
                listBox2.Items.Insert(0, b + "              " + label3.Text + "          KURU                  %" + nemoran.ToString("N2"));
                OleDbCommand komut = new OleDbCommand("insert into Veriler (AnalogDeger,Saat,NumuneDurumu,NemOranı,Tarih) values ('" + b + "','" + label3.Text.ToString() + "','" + "KURU" + "','" + "% "+nemoran + "','" + label16.Text.ToString() + "')", bag);
                komut.ExecuteNonQuery();
                bag.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.VerticalScroll.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
            
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
        }
    }
    }

