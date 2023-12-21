using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Microsoft.VisualBasic; //inputbox icin

namespace WindowsFormsApplication2
{
    public partial class anaEkran : Form
    {
        private static int bireysel = 0; //bu deger 0 oldugunda grup calismasi, 1 oldugunda bireysel calisma yapiliyor
        private static string ad;

        public static int Bireysel
        {
            get
            {
                return bireysel;
            }

            set
            {
                bireysel = value;
            }
        }

        public static string Ad
        {
            get
            {
                return ad;
            }

            set
            {
                ad = value;
            }
        }

        public anaEkran()
        {
            InitializeComponent();
        }

        private void anaEkran_Load(object sender, EventArgs e)
        {
           

            button5.Text = "Hangi Sorular Sorulsun";
            button1.Text = "Bireysel Çalışma";
            button2.Text = "Kapat";
            button3.Text = "Grup Çalışması";
            button4.Text = "Grupları Düzenle";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (textBox1.Text != "")
            { 
                for(int i = 0; i < Convert.ToInt32(textBox1.Text);i++)
                {
                    Form1 k = new Form1();
                    k.Show();
                }
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bireysel = 0;

            grupCalismasi sorular1 = new grupCalismasi();
            // sorular1.Show();
            //sorular1.Visible = false;

            sinifSec k = new sinifSec();
            k.Show();


        }

        void bireyselCalisma(bool cevap)
        {
            Form1 k = new Form1();
            //rastgele bir isim (çocuk1) verildi
            //şifre rastgele verilecek
            k.ogrenciler1[0] = new Ogrenci("çocuk1", -1);
         
            bireysel = 1;

            if (cevap) //isim kullanıcıya sorusun
            {
                String parola = k.ogrenciler1[0].Sifre.ToString();
                //kullanıcı isim girince yeni isim nesneye atandı
                ad = Interaction.InputBox("Lütfen isminizi giriniz. \nParolanız: " + parola, "Hoş Geldiniz", "", 0, 0);

                if (ad == "") ad = "İsimsiz Kahraman"; //isim yazılmaz ise bu isim kullanılsın

                k.ogrenciler1[0].Ad = ad;
            }
            else
            {
                k.ogrenciler1[0].Ad = "İsimsiz Kahraman";
            }

            k.Show();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            bireyselCalisma(false); //kullanıcıya isim belirleme hakkı verilsin mi
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            grupAyarlari k = new grupAyarlari();
            k.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("* Parolaya 1453 yazılırsa admin modu açılıyor.");
        }
    }
}
