using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SQLite;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public int grup;
        public int sinif;
        Kurallar Kurallar1 = new Kurallar();
        public Form1()
        {
            InitializeComponent();
        }

        public void tabEkle(string ad) //tab ekleme fonksiyonu
        {
            string title = ad;
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
            myTabPage.SendToBack();
        }

        public Ogrenci[] ogrenciler1 = new Ogrenci[6];




        public void Form1_Load(object sender, EventArgs e)
        {


            if (anaEkran.Bireysel == 1) //bireysel ise
            {
                tabControl1.TabPages[0].Text = ogrenciler1[tabControl1.SelectedIndex].Ad.ToString();
                //level'a göre soru ve sonuç hazırlanıyor

                ogrenciler1[tabControl1.SelectedIndex].konular1.yeniSoru();
                soruYazdir(); //ilk soru hazırlanıyor

                //form başlığında hoşgeldin yazıyor
                this.Text = "Hoşgeldin " + ogrenciler1[tabControl1.SelectedIndex].Ad;
            }
            else //grup calismasi ise
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source=Veritabani/veri_tabani.sqlite");
                baglan.Open();
                SQLiteCommand cmd = baglan.CreateCommand();

                cmd.CommandText = "SELECT * FROM kullanicilar WHERE grup=" + grup; // AND soyadi "SERT"  
                SQLiteDataReader dr = cmd.ExecuteReader();

                int i = -1; //-1 den baslamasinin sebebi eger veri yoksa form kapaniyor
                while (dr.Read())//formdaki her gruba öğrenci sayısı kadar tab ekleniyor.
                {
                    i++;
                    if (i != 0) tabEkle(dr["adi"].ToString()); //0. öğrencini zaten tab'ı olduğu için tab eklenmiyor
                    ogrenciler1[i] = new Ogrenci(dr["adi"].ToString(), Int32.Parse(dr["sifre"].ToString()));
                    tabControl1.TabPages[i].Text = dr["adi"].ToString();

                    ogrenciler1[tabControl1.SelectedIndex].konular1.yeniSoru();
                    soruYazdir();
                    this.Text = "Grup" + grup.ToString();
                }
                dr.Close();
                baglan.Close();
            }

            kilit(false); //başlangıçta program kilitsiz açılsın
            this.tabControl1.Enabled = false;//soru ve sonuç ekranında öğrenci geçişi yasak

            panelleriGuncelle();

            label2.Text = "Parola:";
            textBox1.Text = "0";

            //tooltip ayarları
            ToolTip Aciklama = new ToolTip(); //ToolTip
            Aciklama.ToolTipTitle = "";
            Aciklama.ToolTipIcon = ToolTipIcon.Warning;
            Aciklama.IsBalloon = true;

            Aciklama.SetToolTip(label14, "1 yanlış yapıldığında ilerlemek için 3 doğru yapılmalı");
            Aciklama.SetToolTip(label15, "Üst üste 3 yanlış yapıldığında level azalıyor");

        }


        private void button1_Click(object sender, EventArgs e) //"Tekrar Sor" veya 
        {
            onayla();

        }



        private void label15_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e) //parola kontrolü yapıyor ve programı kilitliyor
        {


            if (ogrenciler1[tabControl1.SelectedIndex].Kilit == 0) //program kilitliyse parola kontrolü yapıyor
            {
                parolaKontrolu();
                this.tabControl1.Enabled = false;//soru ve sonuç ekranında öğrenci geçişi yasak
            }
            else //program kilitliyse
            {
                if (admin_modu_mu) //admin moduysa admin oturumu kapatılıp kullanıcı oturumu açıldı
                {
                    adminModuKapansin();

                }
                else //kullanıcı oturumuysa kullanıcı oturumu kapatılıp ekran kilitlendi
                {
                    kilit(true);
                    this.tabControl1.Enabled = true; //sadece kilit ekranında öğrenci geçişine izin var
                    adminModuKapansin();
                }

            }

        }

        //klavye ile ilgili fonksiyonlar
        #region
        public void textBoxTemizle()
        {
            if (textBox1.Text == "0") textBox1.Text = "";
        }
        public void yaz(object sender)
        {
            Button b = (Button)sender;

            if (ogrenciler1[tabControl1.SelectedIndex].Kilit == 0) //parola ekranına yazıyor
            {
                textBox2.Text = textBox2.Text + b.Text;
            }
            else //sonuç ekranına yazıyor
            {
                textBoxTemizle();
                textBox1.Text = textBox1.Text + b.Text;
            }
        }

        private void button13_Click(object sender, EventArgs e) //0 tuşu
        {
            yaz(sender);
        }
        private void button4_Click(object sender, EventArgs e) //1 tuşu
        {
            yaz(sender);
        }
        private void button8_Click(object sender, EventArgs e) //2 tuşu
        {
            yaz(sender);
        }

        private void button7_Click(object sender, EventArgs e) //3 tuşu
        {
            yaz(sender);
        }

        private void button9_Click(object sender, EventArgs e) //4 tuşu
        {
            yaz(sender);
        }

        private void button5_Click(object sender, EventArgs e) //5 tuşu
        {
            yaz(sender);
        }

        private void button6_Click(object sender, EventArgs e) //6 tuşu
        {
            yaz(sender);
        }

        private void button12_Click(object sender, EventArgs e) //7 tuşu
        {
            yaz(sender);
        }

        private void button10_Click(object sender, EventArgs e) //8 tuşu
        {
            yaz(sender);
        }

        private void button11_Click(object sender, EventArgs e) //9 tuşu
        {
            yaz(sender);
        }

        private void button14_Click(object sender, EventArgs e) //sil butonu
        {
            if (ogrenciler1[tabControl1.SelectedIndex].Kilit == 1) //kilitsizse
            {
                //textBoxTemizle();
                char[] text = textBox1.Text.ToCharArray();
                textBox1.Text = "";
                for (int i = 0; i < text.Length - 1; i++)
                {
                    textBox1.Text += text[i];
                }
            }
            else //kilitliyse
            {
                char[] text = textBox2.Text.ToCharArray();
                textBox2.Text = "";
                for (int i = 0; i < text.Length - 1; i++)
                {
                    textBox2.Text += text[i];
                }
            }
        }

        #endregion


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {//sonuç ekranında öğrenci geçişi yasak
            panelleriGuncelle();
            if (ogrenciler1[tabControl1.SelectedIndex].Kilit == 0) //kilitliyse kilitle
            {
                kilit(true);
                textBox2.Text = "";
                textBox2.Focus(); //!!!!bu komut çalışmıyor

            }
            else
            {
                kilit(false);
                textBox1.Text = "0"; //sonuç yerine 0 yazılıyor
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        void richTextBoxAyarlariniYap(string soru)
        {
            //   richTextBox1.Text = "2H2 + O2 = 2H2O\n32 + 42 = 52";
            // newRichTextBox1.Refresh();
            richTextBox1.Text = soru;

            // A smaller font.
            float font_size = richTextBox1.Font.Size;
            Font small_font = new Font(
                richTextBox1.Font.FontFamily,
                font_size * 0.75f);

            /*// Subscripts.
            int[] subs = { 2, 7, 13 };
            int offset = (int)(font_size * 0.5);
            foreach (int position in subs)
            {
                richTextBox1.Select(position, 1);
                richTextBox1.SelectionCharOffset = -offset;
                richTextBox1.SelectionFont = small_font;
            }

            // Superscripts.
            int[] supers = { 17, 22, 27 };
            foreach (int position in supers)
            {
                richTextBox1.Select(position, 1);
                richTextBox1.SelectionCharOffset = +offset;
                richTextBox1.SelectionFont = small_font;
            }
            */
            richTextBox1.Select(0, richTextBox1.Text.Length); //metnin tamamı sağa doğru hizalandı
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        bool sonucGoster = false; //true ise işlemin sonucunu gösterir
        public void soruYazdir()
        {

            //soru ekrana yazdırılıyor
            richTextBoxAyarlariniYap(ogrenciler1[tabControl1.SelectedIndex].konular1.soruyuYazdir());

            if (sonucGoster) //işlem yanlış yapıldığında sonuç gösterme ekranında sonucu gösteriyor
            {

                richTextBoxAyarlariniYap(ogrenciler1[tabControl1.SelectedIndex].konular1.soruyuYazdir() + "\n" + ogrenciler1[tabControl1.SelectedIndex].konular1.cevapEkrani);
            }


        }


        public void kilit(bool durum)
        {

            if (durum == true) //kilitle
            {
                ogrenciler1[tabControl1.SelectedIndex].Kilit = 0;

                //button21.Visible= !durum;
                label2.Visible = durum;
                textBox2.Visible = durum;
                panel2.Visible = !durum;
                panel3.Visible = !durum;
                panel4.Visible = !durum;
                button1.Visible = !durum;
                //butonda yeşil tik simgesi kullanılıyor
                this.button3.Image = global::WindowsFormsApplication2.Properties.Resources.onayla;
            }
            else //false durumu - kilit çözülüyor
            {
                ogrenciler1[tabControl1.SelectedIndex].Kilit = 1;

                //button21.Visible = !durum;
                label2.Visible = durum;
                textBox2.Visible = durum;
                panel2.Visible = !durum;
                panel3.Visible = !durum;
                panel4.Visible = !durum;
                button1.Visible = !durum;

                //butonda kilit simgesi kullanıldı
                this.button3.Image = global::WindowsFormsApplication2.Properties.Resources.kilit;

                button1.Text = "Cevabı Onayla";
                textBox1.Focus();
                textBox2.Text = "";
            }

        }


        Color varsayılan = System.Drawing.Color.Turquoise;
        Color dogruRenk = Color.Lime;
        Color yanlisRenk = Color.Crimson;

        public void panelleriGuncelle()
        {
            // label7.Text = ogrenciler1[tabControl1.SelectedIndex].DogruSayisi.ToString();
            //  label9.Text = ogrenciler1[tabControl1.SelectedIndex].YanlisSayisi.ToString();
            label7.Text = ogrenciler1[tabControl1.SelectedIndex].toplamDogruSayisi.ToString();
            label9.Text = ogrenciler1[tabControl1.SelectedIndex].toplamYanlisSayisi.ToString();

            label13.Text = ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel.ToString();
            label5.Text = ogrenciler1[tabControl1.SelectedIndex].konular1.islemTurleriUzunİsim[ogrenciler1[tabControl1.SelectedIndex].konular1.suankiSeviye - 1];

            if (ogrenciler1[tabControl1.SelectedIndex].konular1.sonLevelMi())
            {
                if (ogrenciler1[tabControl1.SelectedIndex].konular1.sonSeviyeMi())
                {
                    label14.Text = "Tebrikler Bütün Konuları Bitirdiniz.";
                }
                else
                {
                    label14.Text = Kurallar1.levelYukseltmeSoruSayisiHesapla(ogrenciler1[tabControl1.SelectedIndex].DogruSayisi, ogrenciler1[tabControl1.SelectedIndex].YanlisSayisi, ogrenciler1[tabControl1.SelectedIndex].konular1.sorulmaSayisi) +
                                " Doğru" + "\n" + "Seviye Yükseltir";
                }
            }
            else//son seviyenin son level'inde ise
            {
                label14.Text = Kurallar1.levelYukseltmeSoruSayisiHesapla(ogrenciler1[tabControl1.SelectedIndex].DogruSayisi, ogrenciler1[tabControl1.SelectedIndex].YanlisSayisi, ogrenciler1[tabControl1.SelectedIndex].konular1.sorulmaSayisi) +
                       " Doğru" + "\n" + "Level Yükseltir";
            }



            if (ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel != 1)
            {
                label15.Text = Kurallar1.levelDusurmeSoruSayisiHesapla(ogrenciler1[tabControl1.SelectedIndex].DogruSayisi, ogrenciler1[tabControl1.SelectedIndex].YanlisSayisi, ogrenciler1[tabControl1.SelectedIndex].konular1.sorulmaSayisi).ToString();
            }
            else
            {
                label15.Text = "0";
            }
            label15.Text = label15.Text + " Yanlış" + "\n" + "Level Düşürür";

            if (ogrenciler1[tabControl1.SelectedIndex].Kilit == 1) //soru ekranı
            {
                panel5.Visible = true;

                textBox1.BackColor = varsayılan;
                label6.BackColor = varsayılan;
                label7.BackColor = varsayılan;
                label8.BackColor = varsayılan;
                label9.BackColor = varsayılan;
                textBox1.ForeColor = SystemColors.ControlText;
                label8.ForeColor = SystemColors.ControlText;
                label9.ForeColor = SystemColors.ControlText;
            }

            if (ogrenciler1[tabControl1.SelectedIndex].Kilit == 2) //sonuç ekranı
            {
                if (ogrenciler1[tabControl1.SelectedIndex].konular1.oncekiSoruDogru == true)//doğruysa
                {
                    textBox1.BackColor = dogruRenk;
                    label6.BackColor = dogruRenk;
                    label7.BackColor = dogruRenk;
                }
                else //yanlışsa
                {
                    textBox1.BackColor = yanlisRenk;
                    label8.BackColor = yanlisRenk;
                    label8.ForeColor = Color.White;
                    label9.BackColor = yanlisRenk;
                    label9.ForeColor = Color.White;
                    textBox1.ForeColor = Color.White;
                }
            }
        }

        public void parolaKontrolu()
        {
            int girilenParola = 0;

            if (textBox2.Text != "")
            {
                girilenParola = int.Parse(textBox2.Text); //girilen sifreyi deneye ata
            }

            if (girilenParola == ogrenciler1[tabControl1.SelectedIndex].Sifre) //şifre dogruysa
            {
                kilit(false);
            }
            else if (girilenParola == 1453) //admin şifresi 1453
            {
                kilit(false);
                adminModuAcilsin();
            }
        }


        public void onayla()
        {
            if (ogrenciler1[tabControl1.SelectedIndex].Kilit == 1)//işlem kontrol ediliyor
            {
                cevapDogruMu();//bu fonksiyondan sonra sonuç ekranına geçiliyor
            }
            else if (ogrenciler1[tabControl1.SelectedIndex].Kilit == 2) //sonuc gosterme ekranindaysa yeni soru soruluyor
            {
                //level'a göre soru ve sonuç hazırlanıyor
                ogrenciler1[tabControl1.SelectedIndex].konular1.yeniSoru();

                sonucGoster = false; //doğru cevabı gizle

                {//bura koşula bağlanabilir level değiştiyse bu komutları uygula gibi
                 //     gizle = true;
                    skorlarGizlensinMi(true);
                }

                soruYazdir();

                textBox1.Text = "0";
                textBox1.Focus();

                ogrenciler1[tabControl1.SelectedIndex].Kilit = 1;


                button1.Text = "Cevabı Onayla";
            }
            panelleriGuncelle();
        }
        int levelDegeri;
        void levelHesapla()
        {
            levelDegeri = Kurallar1.levelDegisikligi(ogrenciler1[tabControl1.SelectedIndex].leveldakiDogruSayisi, ogrenciler1[tabControl1.SelectedIndex].leveldakiYanlisSayisi, ogrenciler1[tabControl1.SelectedIndex].konular1.sorulmaSayisi);
        }
        void cevapDogru()
        {
            button1.Text = "İlerle";
            ogrenciler1[tabControl1.SelectedIndex].DogruSayisi++;

            if (ogrenciler1[tabControl1.SelectedIndex].konular1.sonLevelMi())  //son level'deyse seviye artır
            {
                if (!ogrenciler1[tabControl1.SelectedIndex].konular1.sonSeviyeMi()) //son seviyede değilse seviye artır
                {
                    seviyeArtir();
                    skorlarGizlensinMi(false);
                    ogrenciler1[tabControl1.SelectedIndex].leveldakiDogruSayisi = 0;
                    ogrenciler1[tabControl1.SelectedIndex].leveldakiYanlisSayisi = 0;
                }
            }
            else //son level'de değilse level artır
            {
                levelHesapla();
                if (levelDegeri == 1) //level artırılmalıysa
                {
                    ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel++; //level artır
                    label3.Text = "▲▲ Level ▲▲ Yükseldi ▲▲";
                    skorlarGizlensinMi(false);
                    ogrenciler1[tabControl1.SelectedIndex].leveldakiDogruSayisi = 0;
                    ogrenciler1[tabControl1.SelectedIndex].leveldakiYanlisSayisi = 0;
                }
            }
        }
        void cevapYanlis()
        {
            button1.Text = "Tekrar Sor";
            ogrenciler1[tabControl1.SelectedIndex].YanlisSayisi++;

            sonucGoster = true; //işlemin doğru sonucunu göster
            soruYazdir();

            levelHesapla();
            //yanlış yapılırsa 1. level'a kadar düşürüyor fakat seviye düşmüyor (yani devamlı aynı seviyede soru soru soruyor)
            if (levelDegeri == -1 && ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel != 1) //level azaltılmalıysa
            {
                ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel--; //level azalt

                // gizle = false;
                skorlarGizlensinMi(false);
                label3.Text = "▼▼ Level ▼▼ Düştü ▼▼";

                ogrenciler1[tabControl1.SelectedIndex].leveldakiDogruSayisi = 0;
                ogrenciler1[tabControl1.SelectedIndex].leveldakiYanlisSayisi = 0;
            }
        }


        void skorlarGizlensinMi(bool gizle) //doğru,yanlış,level skorları gizleniyor
        {
            //panel4.Visible = !gizle;
            label3.Visible = !gizle;

            label4.Visible = gizle;
            label5.Visible = gizle;
            label6.Visible = gizle;
            label7.Visible = gizle;
            label8.Visible = gizle;
            label9.Visible = gizle;
            label10.Visible = gizle;
            label13.Visible = gizle;

            label14.Visible = gizle;
            label15.Visible = gizle;

        }

        public void cevapDogruMu()  //cevap dogru mu yanlis mi diye kontrol ediyor
        {
            if (textBox1.Text != "")
            {
                panel5.Visible = false;

                ogrenciler1[tabControl1.SelectedIndex].Kilit = 2; //sonuc ekraninin kodu

                if (ogrenciler1[tabControl1.SelectedIndex].konular1.islemKontrol(textBox1.Text))
                { //cevap dogru ise
                    cevapDogru();
                    ogrenciler1[tabControl1.SelectedIndex].toplamDogruSayisi++;
                }
                else //cevap yanlissa
                {
                    cevapYanlis();
                    ogrenciler1[tabControl1.SelectedIndex].toplamYanlisSayisi++;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bir daha parolanı unutma " + ogrenciler1[tabControl1.SelectedIndex].Ad + ":)" + "\n" + "Parola: " + ogrenciler1[tabControl1.SelectedIndex].Sifre.ToString(), "Parola Hatırlatma");

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            //   this.pictureBox1.Image =;
        }

        //panel1 e 5 kez tıklanınca admin modu açılıyor.

        private bool admin_modu_mu = false;

        Color siyah = Color.Black;
        Color pembe = Color.Pink;

        void adminModuAcilsin()
        {
            this.Text = "Hoşgeldin Admin";
            panel1.BackColor = siyah;
            admin_modu_mu = true;


        }
        void adminModuKapansin()
        {
            this.Text = "Hoşgeldiniz";
            panel1.BackColor = pembe;
            admin_modu_mu = false;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void panel3_Click(object sender, EventArgs e)
        {
            if (admin_modu_mu)
            {


                ogrenciler1[tabControl1.SelectedIndex].konular1.yeniSoru();
                soruYazdir();
                panelleriGuncelle();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }



        private void button15_Click(object sender, EventArgs e)
        {
            yaz(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yaz(sender);
        }

        void skorlariSifirla() //doğru,yanlış ve level sayıları sıfırlanıyor
        {
            ogrenciler1[tabControl1.SelectedIndex].leveldakiDogruSayisi = 0;
            ogrenciler1[tabControl1.SelectedIndex].leveldakiYanlisSayisi = 0;
            //ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel = 1;
        }
        void seviyeAzalt()
        {
            //ilk seviye değil ise seviye azalt
            if (!ogrenciler1[tabControl1.SelectedIndex].konular1.ilkSeviyeMi())
            {
                skorlariSifirla();
                ogrenciler1[tabControl1.SelectedIndex].konular1.suankiSeviye--;
                ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel = 1;
                ogrenciler1[tabControl1.SelectedIndex].konular1.yeniSoru();
                soruYazdir();
                panelleriGuncelle();
            }
        }
        void seviyeArtir()
        {
            //son seviye değil ise seviye artıyor
            if (!ogrenciler1[tabControl1.SelectedIndex].konular1.sonSeviyeMi())
            {
                label3.Text = "▲▲ Seviye ▲▲ Yükseldi ▲▲";
                skorlariSifirla();
                ogrenciler1[tabControl1.SelectedIndex].konular1.suankiSeviye++;//seviye yükselt
                ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel = 1;
                ogrenciler1[tabControl1.SelectedIndex].konular1.yeniSoru();
                soruYazdir();
                panelleriGuncelle();
            }
        }

        void levelArtir()
        {
            //son level değilse level artıyor
            if (!ogrenciler1[tabControl1.SelectedIndex].konular1.sonLevelMi())
            {
                skorlariSifirla();
                ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel++;
                ogrenciler1[tabControl1.SelectedIndex].konular1.yeniSoru();
                soruYazdir();
                panelleriGuncelle();
            }
        }
        private void button20_Click(object sender, EventArgs e) //level artır
        {

        }
        void levelAzalt()
        {
            //ilk level değilse level azalıyor
            if (!ogrenciler1[tabControl1.SelectedIndex].konular1.ilkLevelMi())
            {
                skorlariSifirla();
                ogrenciler1[tabControl1.SelectedIndex].konular1.suankiLevel--;
                ogrenciler1[tabControl1.SelectedIndex].konular1.yeniSoru();
                soruYazdir();
                panelleriGuncelle();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            yaz(sender);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (admin_modu_mu)
                seviyeAzalt();
        }


        private void label5_Click(object sender, EventArgs e)
        {
            if (admin_modu_mu)
                seviyeArtir();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (admin_modu_mu)
                levelAzalt();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (admin_modu_mu)
                levelArtir();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newRichTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            soruYazdir();
        }
    }
}
