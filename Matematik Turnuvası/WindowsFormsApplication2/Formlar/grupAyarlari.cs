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
    public partial class grupAyarlari : Form
    {


        public grupAyarlari()
        {
            InitializeComponent();
        }
        public void listele()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();

            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source=Veritabani/veri_tabani.sqlite");
                baglan.Open();
                SQLiteCommand cmd = baglan.CreateCommand();

                for (int i = 1; i < 9; i++)
                {
                    cmd.CommandText = "SELECT * FROM kullanicilar WHERE grup=" + i + " AND sinif=" + "'" + comboBox1.SelectedItem.ToString() + "'"; // AND soyadi “Kurşun”
                    //cmd.ExecuteNonQuery(); ????ne ise yaradigini bilmiyorum
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                       // MessageBox.Show(dr["adi"].ToString());
                        switch (i)
                        {
                            case 1:
                                listBox1.Items.Add(dr["adi"].ToString() + " <> " + dr["sifre"].ToString());
                                break;
                            case 2:
                                listBox2.Items.Add(dr["adi"].ToString() + " <> " + dr["sifre"].ToString());
                                break;
                            case 3:
                                listBox3.Items.Add(dr["adi"].ToString() + " <> " + dr["sifre"].ToString());
                                break;
                            case 4:
                                listBox4.Items.Add(dr["adi"].ToString() + " <> " + dr["sifre"].ToString());
                                break;
                            case 5:
                                listBox5.Items.Add(dr["adi"].ToString() + " <> " + dr["sifre"].ToString());
                                break;
                            case 6:
                                listBox6.Items.Add(dr["adi"].ToString() + " <> " + dr["sifre"].ToString());
                                break;
                            case 7:
                                listBox7.Items.Add(dr["adi"].ToString() + " <> " + dr["sifre"].ToString());
                                break;
                            case 8:
                                listBox8.Items.Add(dr["adi"].ToString() + " <> " + dr["sifre"].ToString());
                                break;
                        }
                    }
                    dr.Close();

                }
                baglan.Close();

                //listele();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void tasi()
        {



        }
        private void grupAyarlari_Load(object sender, EventArgs e)
        {
            try //sınıfları listele
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source=Veritabani/veri_tabani.sqlite");
                baglan.Open();
                SQLiteCommand cmd = baglan.CreateCommand();

                cmd.CommandText = "SELECT * FROM siniflar";
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["sinif"].ToString());
                }
                dr.Close();
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();
        }

        void elemanTasi(ListBox kaynakListe, int kaynakIndex, int hedefListe)
        {
            string value = kaynakListe.Items[kaynakIndex].ToString();

            string[] collection = value.Split('<');

            //gerekli ayrıştırma yapıldıktan sonra '<' karakterinden önceki boşluk siliniyor
            string isim = collection[0].Trim();

            try //sınıfları listele
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source=Veritabani/veri_tabani.sqlite");
                baglan.Open();

                SQLiteCommand cmd = baglan.CreateCommand();
                cmd.CommandText = "UPDATE kullanicilar SET grup = "+hedefListe+" WHERE adi = '"+ isim+"'";// + aaa;
              
                cmd.ExecuteNonQuery();

                baglan.Close();

                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        //listBox_MouseDown
        #region
        //taşınan elemanın bulunduğu listBox
        ListBox neredenListBox;

        //tasinan elemanın listbox'taki index ini saklar
        int hangiElemanIndex; 
        void listBox_MouseDown_Event_Ayari(object sender, MouseEventArgs e, ListBox list)
        {
            neredenListBox = list;

            Point sonnokta = new Point(e.X, e.Y);//tıklanılan noktayı aldık.

            int item_index = list.IndexFromPoint(sonnokta);//tıklanılannoktada yer alan değerin indisini aldık.
           
            if (e.Button == MouseButtons.Left && item_index != -1)//mouse'un soluna mı tıklanılmış diye kontrol ettik.
            {
                hangiElemanIndex = item_index;

                list.DoDragDrop(list.Items[item_index], DragDropEffects.All);

                //listbox1'den sürükle-bırak metodunu çağırdık.

            }
        //    MessageBox.Show(hangiElemanIndex.ToString());


        }
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox_MouseDown_Event_Ayari(sender, e, listBox1);
        }
        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            listBox_MouseDown_Event_Ayari(sender, e, listBox2);
        }
        private void listBox3_MouseDown(object sender, MouseEventArgs e)
        {
            listBox_MouseDown_Event_Ayari(sender, e, listBox3);
        }
        private void listBox4_MouseDown(object sender, MouseEventArgs e)
        {
            listBox_MouseDown_Event_Ayari(sender, e, listBox4);
        }
        private void listBox5_MouseDown(object sender, MouseEventArgs e)
        {
            listBox_MouseDown_Event_Ayari(sender, e, listBox5);
        }
        private void listBox6_MouseDown(object sender, MouseEventArgs e)
        {
            listBox_MouseDown_Event_Ayari(sender, e, listBox6);
        }
        private void listBox7_MouseDown(object sender, MouseEventArgs e)
        {
            listBox_MouseDown_Event_Ayari(sender, e, listBox7);
        }
        private void listBox8_MouseDown(object sender, MouseEventArgs e)
        {
            listBox_MouseDown_Event_Ayari(sender, e, listBox8);
        }
        #endregion

        //listBox_DragDrop
        #region
        void listBox_DragDrop_Event_Ayari(object sender, DragEventArgs e, ListBox yeniList)
        {
           //listbox adının son karakteri kaynak grup adıdır.
           int grupAdi = int.Parse(yeniList.Name.Substring(yeniList.Name.Length-1));

            //eleman veritabanında taşınıyor
            elemanTasi(neredenListBox, hangiElemanIndex, grupAdi);

            //eleman form üzerinde listboxlarda tasiniyor
            //yeniList.Items.Add(e.Data.GetData(DataFormats.Text));//sürükle-vırakile gelen değeri listbox2'ye yerleştirdik.
           // neredenListBox.Items.Remove(e.Data.GetData(DataFormats.Text));     
        }
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox_DragDrop_Event_Ayari(sender, e, listBox1);
        }
        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            listBox_DragDrop_Event_Ayari(sender, e, listBox2);
        }
        private void listBox3_DragDrop(object sender, DragEventArgs e)
        {
            listBox_DragDrop_Event_Ayari(sender, e, listBox3);
        }
        private void listBox4_DragDrop(object sender, DragEventArgs e)
        {
            listBox_DragDrop_Event_Ayari(sender, e, listBox4);
        }
        private void listBox5_DragDrop(object sender, DragEventArgs e)
        {
            listBox_DragDrop_Event_Ayari(sender, e, listBox5);
        }
        private void listBox6_DragDrop(object sender, DragEventArgs e)
        {
            listBox_DragDrop_Event_Ayari(sender, e, listBox6);
        }
        private void listBox7_DragDrop(object sender, DragEventArgs e)
        {
            listBox_DragDrop_Event_Ayari(sender, e, listBox7);
        }
        private void listBox8_DragDrop(object sender, DragEventArgs e)
        {
            listBox_DragDrop_Event_Ayari(sender, e, listBox8);
        }

        #endregion

        //çok önemli değil
        //listBox_DrogEnter
        #region 
        void listBox_DrogEnter_Event_Ayari(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            listBox_DrogEnter_Event_Ayari(sender, e);
        }
        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            listBox_DrogEnter_Event_Ayari(sender, e);
        }
        private void listBox3_DragEnter(object sender, DragEventArgs e)
        {
            listBox_DrogEnter_Event_Ayari(sender, e);
        }
        private void listBox4_DragEnter(object sender, DragEventArgs e)
        {
            listBox_DrogEnter_Event_Ayari(sender, e);
        }
        private void listBox5_DragEnter(object sender, DragEventArgs e)
        {
            listBox_DrogEnter_Event_Ayari(sender, e);
        }
        private void listBox6_DragEnter(object sender, DragEventArgs e)
        {
            listBox_DrogEnter_Event_Ayari(sender, e);
        }
        private void listBox7_DragEnter(object sender, DragEventArgs e)
        {
            listBox_DrogEnter_Event_Ayari(sender, e);
        }
        private void listBox8_DragEnter(object sender, DragEventArgs e)
        {
            listBox_DrogEnter_Event_Ayari(sender, e);
        }
        #endregion

        //çok önemli değil
        //listBox_DrogOver
        #region
        void listBox_DrogOver_Event_Ayari(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)

            {
                e.Effect = DragDropEffects.All;
            }
        }
        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            listBox_DrogOver_Event_Ayari(sender, e);
        }
        private void listBox2_DragOver(object sender, DragEventArgs e)
        {
            listBox_DrogOver_Event_Ayari(sender, e);
        }
        private void listBox3_DragOver(object sender, DragEventArgs e)
        {
            listBox_DrogOver_Event_Ayari(sender, e);
        }
        private void listBox4_DragOver(object sender, DragEventArgs e)
        {
            listBox_DrogOver_Event_Ayari(sender, e);
        }
        private void listBox5_DragOver(object sender, DragEventArgs e)
        {
            listBox_DrogOver_Event_Ayari(sender, e);
        }
        private void listBox6_DragOver(object sender, DragEventArgs e)
        {
            listBox_DrogOver_Event_Ayari(sender, e);
        }
        private void listBox7_DragOver(object sender, DragEventArgs e)
        {
            listBox_DrogOver_Event_Ayari(sender, e);
        }
        private void listBox8_DragOver(object sender, DragEventArgs e)
        {
            listBox_DrogOver_Event_Ayari(sender, e);
        }
        #endregion
       

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
