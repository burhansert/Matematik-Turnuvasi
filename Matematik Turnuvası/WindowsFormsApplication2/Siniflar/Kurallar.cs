using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class Kurallar
    {
        // public static Form1 f1 = (Form1)Application.OpenForms["Form1"];
        // Form1 anaform = new Form1();

        int soruSayisi;
        public int levelYukseltmeSoruSayisiHesapla(int dogruSayisi, int yanlisSayisi, int sorulmaSayisi)
        {
            //doğru sayısı istenen soru sayısı ile yanlış sayısının toplamını geçince level yükseliyor
            soruSayisi = sorulmaSayisi - (dogruSayisi - yanlisSayisi);
            return soruSayisi;
        }
        public int levelDusurmeSoruSayisiHesapla(int dogruSayisi, int yanlisSayisi, int sorulmaSayisi)
        {
            //yanlış sayısının 2 katı doğru sayısını geçince level düşüyor
            soruSayisi =  dogruSayisi * 2- yanlisSayisi+1;
            return soruSayisi;
        }
        int levelHesap;
        //-1 ise azalt,0 ise değişmesin,+1 ise artır
       public int levelDegisikligi(int dogruSayisi, int yanlisSayisi, int sorulmaSayisi)
        {

            if (sorulmaSayisi - (dogruSayisi - yanlisSayisi)  == 0)
            {
                //ogrenciler1[tabControl1.SelectedIndex].konular1.level++;
                levelHesap = 1;
            }
            //doğru sayısının 2 katında fazla yanlış varsa level düşüyor
            //1 doğru 3 yanlış
            //2 doğru 5 yanlış
            //5 doğru 11 yanlış gibi
             else if(yanlisSayisi> dogruSayisi*2)
            {
                levelHesap = -1;
            }
            else{
                levelHesap = 0;
            }
            return levelHesap;
        }

    }
}
