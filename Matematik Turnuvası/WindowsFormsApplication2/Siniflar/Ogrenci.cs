using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class Ogrenci
    {
        //int ilkSayi = 1; //birinci sayinin basamak sayisi
        // int ikinciSayi = 1; //ikinci sayinin basamak sayisi
       // int ustUsteYanlis = 0;
        string ad;
        int sifre;
        int kilit = 0; //kilit ekranı 0, soru ekranı 1, sonuc ekrani 2
        public int leveldakiDogruSayisi = 0;
        public int leveldakiYanlisSayisi = 0;
        public int toplamDogruSayisi = 0;
        public int toplamYanlisSayisi = 0;

        int klavye = 1; // 1 ise k

        public Konular konular1;
        public Ogrenci(string ad, int _sifre)
        {
            konular1 = new Konular();

            //LevelSeviyesi = konular1.level;

            this.ad = ad;


            if (_sifre == -1) //şifre yoksa
            {
                this.sifre = (RastgeleSayi.SayiUret(10, 100));
            }
            else
            {
                this.sifre = _sifre;
            }


        }

        //property ler
        #region



        public string Ad
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

        public int Sifre
        {
            get
            {
                return sifre;
            }

            set
            {
                sifre = value;
            }
        }


      

        public int Kilit
        {
            get
            {
                return kilit;
            }

            set
            {
                kilit = value;
            }
        }

        public int DogruSayisi
        {
            get
            {
                return leveldakiDogruSayisi;
            }

            set
            {
                leveldakiDogruSayisi = value;
            }
        }

        public int YanlisSayisi
        {
            get
            {
                return leveldakiYanlisSayisi;
            }

            set
            {
                leveldakiYanlisSayisi = value;
            }
        }


        public int Klavye
        {
            get
            {
                return klavye;
            }

            set
            {
                klavye = value;
            }
        }

     
        #endregion



    }
}
