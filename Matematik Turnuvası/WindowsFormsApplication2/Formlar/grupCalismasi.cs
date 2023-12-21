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

namespace WindowsFormsApplication2
{
    public partial class grupCalismasi : Form
    {
        public string sinif;
        public grupCalismasi()
        {
            InitializeComponent();
        }
        
        public void baslangic() //sınıf secildikten sonra calisacak
        {
            SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = ("Data Source=Veritabani/veri_tabani.sqlite");


            int test = -1; //sinifta ogrenci yoksa uyari veriyor

            //veritabanındaki grup sayısı kadar form'da grup oluşturuldu
            for (int i = 0; i < 8; i++)
            {
                baglan.Open();
                SQLiteCommand cmd = baglan.CreateCommand();
                cmd.CommandText = "SELECT * FROM kullanicilar WHERE grup=" + (i + 1) +" AND sinif="+"'"+sinif+"'";
                SQLiteDataReader dr = cmd.ExecuteReader();

            
                if (dr.Read())
                {
                Form1 yeni = new Form1();
     
                    yeni.MdiParent = this;
                yeni.grup = i+1; //grup isimleri 1 den basliyor
                yeni.Show();
                test++;
                }
                dr.Close();
                baglan.Close();

      
            }
            if (test == -1)
            {
                MessageBox.Show("Lütfen Bu Sınıfa \nÖğrenci Ekleyin.");
                this.Close();
                sinifSec k = new sinifSec();
                k.Show();
               
            }

            LayoutMdi(MdiLayout.TileVertical); //forumlar hizalaniyor
           // this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }

        private void Sorular_Load(object sender, EventArgs e)
        {
            baslangic();
            //sinifSec k = new sinifSec();
            // k.Show();
         //   this.Visible = false;
        }

        private void yeniGrupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yenniGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinifSec k = new sinifSec();
            k.Show();

           /* 
            Form1 yeni = new Form1();
            yeni.MdiParent = this;
            yeni.Show();
           */
        }

        private void dikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void yatayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hizalaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
