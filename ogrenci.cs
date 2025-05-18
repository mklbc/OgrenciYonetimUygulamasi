using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYonetimUygulamasi_Mehmet1
{
    internal class ogrenci
    {
        public string ad;
        public string soyad;
        public int no;
        public string sube;
        public int yas;
        public int dogumyili;
        public int matnotu;
        public int fennotu;
        public int sosnotu;
        public int trknotu;
        public int ortalama;


        public int ortalamahesapla()
        {
           return  ortalama = (matnotu + fennotu + sosnotu + trknotu) / 4;
        }

        public void yashesapla()
        {
            yas = 2024 - dogumyili;
        }
    }
}
