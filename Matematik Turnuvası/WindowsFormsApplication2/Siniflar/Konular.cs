using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Konular
    {

        public Konular()
        {

        }
        public enum islemTurleri { toplama, cikarma, carpma, uslu, denklem };
        public string[] islemTurleriUzunİsim = { "Toplama", "Çıkarma", "Çarpma", "Üslü Sayılar", "Denklem" };
        public int[] islemLevelSayisi = { 6, 6, 6, 2, 5 };

        public int suankiSeviye = (int)islemTurleri.toplama + 1; //başlangıç işlem türü
        public int suankiLevel = 1; //başlama level sayisi

        bool ilkLevel;
        public bool ilkLevelMi()
        {
            if (suankiLevel == 1)
            {
                ilkLevel = true;
            }
            else
            {
                ilkLevel = false;
            }
            return ilkLevel;
        }

        bool sonLevel;
        public bool sonLevelMi()
        {
            if (suankiLevel == islemLevelSayisi[suankiSeviye - 1])
            {
                sonLevel = true;
            }
            else
            {
                sonLevel = false;
            }
            return sonLevel;
        }

        bool ilkSeviye;
        public bool ilkSeviyeMi()
        {
            if (suankiSeviye == 1)
            {
                ilkSeviye = true;
            }
            else
            {
                ilkSeviye = false;
            }
            return ilkSeviye;
        }

        bool sonSeviye;
        public bool sonSeviyeMi()
        {
            if (suankiSeviye == islemTurleriUzunİsim.Count())
            {
                sonSeviye = true;
            }
            else
            {
                sonSeviye = false;
            }
            return sonSeviye;
        }

        int sayi1_basamakSayisi, sayi2_basamakSayisi;  //sayi1 ve sayi2 nin basamak sayısı
        int sayi1_degeri, sayi2_degeri; //sayi1 ve sayi2 nin degeri

        public int sorulmaSayisi; //bir sonraki level'e geçmek için herbir soru tipinin sorulma sayısı 

        void ikiSayiUret()
        {
            sayi1_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi1_basamakSayisi - 1), (int)Math.Pow(10, sayi1_basamakSayisi)));
            sayi2_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi2_basamakSayisi - 1), (int)Math.Pow(10, sayi2_basamakSayisi)));
        }
        void ikiSayiUret_EsitOlmasın() //sayilar esit olmasın
        {
            sayi1_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi1_basamakSayisi - 1), (int)Math.Pow(10, sayi1_basamakSayisi)));
            sayi2_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi2_basamakSayisi - 1), (int)Math.Pow(10, sayi2_basamakSayisi)));
            while (sayi1_degeri == sayi2_degeri) //1. sayi daima büyük olsun
            {
                sayi1_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi1_basamakSayisi - 1), (int)Math.Pow(10, sayi1_basamakSayisi)));
                sayi2_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi2_basamakSayisi - 1), (int)Math.Pow(10, sayi2_basamakSayisi)));
            }
        }
        void ikiSayiUret_BirinciSayiBuyuk() //cikarma islemi için birinci sayı büyük oluyor
        {

            sayi1_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi1_basamakSayisi - 1), (int)Math.Pow(10, sayi1_basamakSayisi)));
            sayi2_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi2_basamakSayisi - 1), (int)Math.Pow(10, sayi2_basamakSayisi)));
            while (sayi1_degeri <= sayi2_degeri) //1. sayi daima büyük olsun
            {
                sayi1_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi1_basamakSayisi - 1), (int)Math.Pow(10, sayi1_basamakSayisi)));
                sayi2_degeri = (RastgeleSayi.SayiUret((int)Math.Pow(10, sayi2_basamakSayisi - 1), (int)Math.Pow(10, sayi2_basamakSayisi)));
            }
        }
        //  public bool sonSoru = false; //sonraki seviyeye geçmek için son soru
        public void toplamaOyunuHazırla()
        {
            switch (suankiLevel)
            {
                case 1:
                    sayi1_basamakSayisi = 1;
                    sayi2_basamakSayisi = 1;
                    sorulmaSayisi = 1;

                    break;
                case 2:
                    sayi1_basamakSayisi = 2;
                    sayi2_basamakSayisi = 1;
                    sorulmaSayisi = 1;
                    //   sonSoru = true; //seviyenin son sorusu
                    break;
                case 3:
                    sayi1_basamakSayisi = 2;
                    sayi2_basamakSayisi = 2;
                    sorulmaSayisi = 1;
                    break;
                case 4:
                    sayi1_basamakSayisi = 3;
                    sayi2_basamakSayisi = 2;
                    sorulmaSayisi = 1;
                    break;
                case 5:
                    sayi1_basamakSayisi = 3;
                    sayi2_basamakSayisi = 3;
                    sorulmaSayisi = 1;
                    break;
                case 6:
                    sayi1_basamakSayisi = 4;
                    sayi2_basamakSayisi = 4;
                    sorulmaSayisi = 1;
                    break;
                default:
                    //seviyeArtir();
                    break;
            }
        }
        public void cikarmaOyunuHazırla()
        {
            switch (suankiLevel)
            {
                case 1:
                    sayi1_basamakSayisi = 1;
                    sayi2_basamakSayisi = 1;
                    sorulmaSayisi = 1;

                    break;
                case 2:
                    sayi1_basamakSayisi = 2;
                    sayi2_basamakSayisi = 1;
                    sorulmaSayisi = 1;
                    // sonSoru = true; //seviyenin son sorusu
                    break;
                case 3:
                    sayi1_basamakSayisi = 2;
                    sayi2_basamakSayisi = 2;
                    sorulmaSayisi = 1;
                    break;
                case 4:
                    sayi1_basamakSayisi = 3;
                    sayi2_basamakSayisi = 2;
                    sorulmaSayisi = 1;
                    break;
                case 5:
                    sayi1_basamakSayisi = 3;
                    sayi2_basamakSayisi = 3;
                    sorulmaSayisi = 1;
                    break;
                case 6:
                    sayi1_basamakSayisi = 4;
                    sayi2_basamakSayisi = 4;
                    sorulmaSayisi = 1;
                    break;
                default:
                    break;
            }
        }
        public void carpmaOyunuHazırla()
        {
            switch (suankiLevel)
            {
                case 1:
                    sayi1_basamakSayisi = 1;
                    sayi2_basamakSayisi = 1;
                    sorulmaSayisi = 1;
                    break;
                case 2:
                    sayi1_basamakSayisi = 2;
                    sayi2_basamakSayisi = 1;
                    sorulmaSayisi = 1;
                    //bu ifadeyi görünce sonraki seviyeye geçiyor
                    //   sonSoru = true; //seviyenin son sorusu
                    break;
                case 3:
                    sayi1_basamakSayisi = 2;
                    sayi2_basamakSayisi = 2;
                    sorulmaSayisi = 1;
                    break;
                case 4:
                    sayi1_basamakSayisi = 3;
                    sayi2_basamakSayisi = 1;
                    sorulmaSayisi = 1;
                    break;
                case 5:
                    sayi1_basamakSayisi = 3;
                    sayi2_basamakSayisi = 2;
                    sorulmaSayisi = 1;
                    break;
                case 6:
                    sayi1_basamakSayisi = 3;
                    sayi2_basamakSayisi = 3;
                    sorulmaSayisi = 1;
                    break;
                default:
                    break;
            }
        }

        int usluIfadeninDegeri; //üslü ifadelerin değeri
        public void usluİfadeOyunuHazırla()
        {
            switch (suankiLevel)
            {        
                case 1://5 üzeri 2 nedir 
                    sorununCevabi = "1";
                    for (int i = 0; i < sayi2_degeri%4; i++) //üs en fazla 3 olabilir
                    {
                        sorununCevabi = ( Int32.Parse(sorununCevabi)* sayi1_degeri).ToString();
                    }
                    soruEkrani =  sayi1_degeri.ToString() + " üzeri " + (sayi2_degeri%4).ToString() + " nedir?";
                    sorulmaSayisi = 12;

                    break;
                case 2://25 sayısı hangi üslü ifadeye eşittir
                    sorununCevabi = "1";
                    usluIfadeninDegeri = 1;
                    sayi2_degeri = sayi2_degeri % 2; //üs 0 veya 1 olabilir
                    sayi2_degeri = sayi2_degeri + 2; //üs 2 veya 3 olabilir

                   // if (sayi2_degeri == 0) sayi2_degeri++; //üs 0 olduğunda 1 yap.

                    for (int i = 0; i < sayi2_degeri ; i++) //üs en fazla 3 olabilir
                    {
                        usluIfadeninDegeri = (usluIfadeninDegeri) * sayi1_degeri;
                    }
                    sorununCevabi = sayi1_degeri.ToString();

                    soruEkrani = usluIfadeninDegeri.ToString() + " sayısı hangi sayının " + (sayi2_degeri ).ToString() + ". üssüdür?";
                    sorulmaSayisi = 12;
                    break;
                default:
                    break;
            }

        }
        public string sorununCevabi; //sayı ile ifade edilemeyen 2/3 şeklindeki sonuçlar

        string xnedir = " ise x=?";
        public void denklemOyunuHazırla()
        {
            switch (suankiLevel)
            {
                case 1://x+8=4 şeklindeki denklemler
                    sorununCevabi = (sayi2_degeri - sayi1_degeri).ToString();
                    soruEkrani = "x + " + sayi1_degeri.ToString() + " = " + sayi2_degeri.ToString() + xnedir;
                    sorulmaSayisi = 4;

                    break;
                case 2://x-8=20 şeklindeki denklemler
                    sorununCevabi = (sayi2_degeri + sayi1_degeri).ToString();
                    soruEkrani = "x - " + sayi1_degeri.ToString() + " = " + sayi2_degeri.ToString() + xnedir;
                    sorulmaSayisi = 4;
                    // sonSoru = true; //seviyenin son sorusu
                    break;
                case 3://x+11=-3 şeklindeki denklemler
                    sorununCevabi = (-(sayi2_degeri + sayi1_degeri)).ToString();
                    soruEkrani = "x + " + sayi1_degeri.ToString() + " = - " + sayi2_degeri.ToString() + xnedir;
                    sorulmaSayisi = 4;
                    break;
                case 4://x-7=-10 şeklindeki denklemler
                    sorununCevabi = (-(sayi2_degeri - sayi1_degeri)).ToString();
                    soruEkrani = "x - " + sayi1_degeri.ToString() + " = - " + sayi2_degeri.ToString() + xnedir;
                    sorulmaSayisi = 4;
                    break;
                case 5://4x=21;
                    sorununCevabi = sayi2_degeri.ToString() + "/" + sayi1_degeri.ToString();
                    //  sonucIntegerMi = false;
                    soruEkrani = sayi1_degeri.ToString() + "x = " + sayi2_degeri.ToString() + xnedir;
                    sorulmaSayisi = 1;
                    break;
                case 6:
                    sorulmaSayisi = 1;
                    break;
                default:
                    break;
            }
        }

        public bool oncekiSoruDogru; //önceki soru doğru yapılmış true

        public bool islemKontrol(string _sonuc)
        {
            if (string.Compare(sorununCevabi, _sonuc) == 0)//karşılaşan değerler aynı ise
            { //cevap dogru ise
                oncekiSoruDogru = true;
            }
            else //cevap yanlissa
            {
                oncekiSoruDogru = false;
            }

            return oncekiSoruDogru;
        }

        public void yeniSoru()
        {
        
            if (suankiSeviye == (int)islemTurleri.toplama + 1)
            {
                toplamaOyunuHazırla();
                ikiSayiUret();
                sorununCevabi = (sayi1_degeri + sayi2_degeri).ToString();
            }
            else if (suankiSeviye == (int)islemTurleri.cikarma + 1)
            {
                cikarmaOyunuHazırla();
                ikiSayiUret_BirinciSayiBuyuk();
                sorununCevabi = (sayi1_degeri - sayi2_degeri).ToString();
            }
            else if (suankiSeviye == (int)islemTurleri.carpma + 1)
            {
                carpmaOyunuHazırla();
                ikiSayiUret();
                sorununCevabi = (sayi1_degeri * sayi2_degeri).ToString();
            }
            else if (suankiSeviye == (int)islemTurleri.uslu + 1)
            {
                sayi1_basamakSayisi = 1; //sabit terim
                sayi2_basamakSayisi = 1;  //sonuç                  
                ikiSayiUret_EsitOlmasın();
                usluİfadeOyunuHazırla();
            }
            else if (suankiSeviye == (int)islemTurleri.denklem + 1)
            {
                sayi1_basamakSayisi = 1; //sabit terim
                sayi2_basamakSayisi = 1;  //sonuç                  
                ikiSayiUret_EsitOlmasın();
                denklemOyunuHazırla();
            }


        }
        string cevap = "Doğru Cevap: ";
        string soruEkrani;
        public string cevapEkrani;
        public string soruyuYazdir()
        {

            if (suankiSeviye == (int)islemTurleri.toplama + 1) //çarpma
            {
                soruEkrani = sayi1_degeri.ToString() + " + " + sayi2_degeri.ToString() + " = ?";
                cevapEkrani = cevap + sorununCevabi;
            }
            else if (suankiSeviye == (int)islemTurleri.cikarma + 1) //toplama
            {
                soruEkrani = sayi1_degeri.ToString() + " - " + sayi2_degeri.ToString() + " = ?";
                cevapEkrani = cevap + sorununCevabi;
            }
            else if (suankiSeviye == (int)islemTurleri.carpma + 1) //toplama
            {
                soruEkrani = sayi1_degeri.ToString() + " x " + sayi2_degeri.ToString() + " = ?";
                cevapEkrani = cevap + sorununCevabi;
            }
            else if (suankiSeviye == (int)islemTurleri.uslu + 1)
            {
                cevapEkrani = cevap + sorununCevabi;
            }
            else if (suankiSeviye == (int)islemTurleri.denklem + 1) //toplama
            {
                cevapEkrani = cevap + sorununCevabi;
            }
            return soruEkrani;
        }

    }
}