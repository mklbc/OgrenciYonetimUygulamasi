namespace OgrenciYonetimUygulamasi_Mehmet1
{
    internal class Program
    {
        static List<ogrenci> ogrenciler = new List<ogrenci>();

        static void Main(string[] args)
        {

            //uygulama();
            test();

        }

        static void test()
        {
            ogrenci o1 = new ogrenci();
            o1.ad = "mehmet";
            o1.soyad = "kulubecioglu";
            o1.sube = "A";
            o1.no = 365;
            o1.dogumyili = 1999;
            o1.yashesapla();
            o1.trknotu = 89;
            o1.fennotu = 68;
            o1.sosnotu = 70;
            o1.matnotu = 60;

            o1.ortalamahesapla();
            Console.WriteLine("Öğrencinin ortalaması: "+ o1.ortalama);

           // Console.WriteLine("Öğrencinin yaşı: " + o1.yas);
           

            ogrenci o2 = new ogrenci();
            o2.ad = "ali";
            o2.soyad = "okuyan";
            o2.sube = "B";
            o2.no = 360;
            o2.dogumyili = 1997;
            o2.yashesapla();


            ogrenci o3 = new ogrenci();
            o3.ad = "ayşe";
            o3.soyad = "ayşeoğlu";
            o3.sube = "C";
            o3.no = 12;
            o3.dogumyili = 1946;
            o3.yashesapla();

        }


        static void uygulama()
        {
            sahteveri();
            while (true)
            {

                menu();
                secimal();
            }


        }

        static void menu()
        {
            Console.WriteLine();
            Console.WriteLine("Öğrenci yönetim uygulaması");
            Console.WriteLine();
            Console.WriteLine("1- Öğrenci ekle: E ");
            Console.WriteLine("2- Öğrenci listele: L ");
            Console.WriteLine("3- Öğrenci sil: S ");
            Console.WriteLine("4- Çıkış: x ");
        }




        static void secimal()
        {
            Console.WriteLine();
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine().ToUpper();
            Console.WriteLine();
            int hatasayaci = 1;

            while (hatasayaci < 10)
            {
                switch (secim)
                {
                    case "1":
                    case "E":
                        ogrenciekleme();
                        break;
                    case "2":
                    case "L":
                        ogrencilistele();
                        break;
                    case "3":
                    case "S":
                        ogrencisilme();
                        break;
                    case "4":
                    case "X":
                        cikisYap();
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş");
                        Console.Write("Seçiminiz: ");
                        secim = Console.ReadLine().ToUpper();
                        hatasayaci++;
                        break;
                }

                if (hatasayaci == 10)
                {
                    Console.WriteLine("Sizi anlayamıyorum, çıkış yapılıyor...");
                    Environment.Exit(0);
                }
                else if (!string.IsNullOrEmpty(secim))
                {
                    break;
                }
            }
        }



        static void cikisYap()
        {
            Console.Write("Çıkış yapmak istediğinize emin misiniz? (E/H): ");
            string onay = Console.ReadLine().ToUpper();
            if (onay == "E")
            {
                Console.WriteLine("Programdan çıkılıyor...");
                Environment.Exit(0);
            }
            else if (onay == "H")
            {
                Console.WriteLine("Çıkış işlemi iptal edildi.");
            }
            else
            {
                Console.WriteLine("Hatalı giriş, çıkış işlemi iptal edildi.");
            }
        }







        static void ogrenciekleme()
        {
            Console.WriteLine("1- öğrenci ekle");
            Console.WriteLine(ogrenciler.Count + 1 + " .Öğrencinin");
            ogrenci o = new ogrenci();

            bool mevcutNo;
            do
            {
                mevcutNo = false;
                Console.Write("Numarası: ");
                o.no = int.Parse(Console.ReadLine());


                foreach (var ogr in ogrenciler)
                {
                    if (ogr.no == o.no)
                    {
                        mevcutNo = true;
                        Console.WriteLine("Bu numara zaten mevcut! Lütfen farklı bir numara giriniz.");
                        break;
                    }
                }
            } while (mevcutNo);

            Console.Write("Adı: ");
            o.ad = ilkharfibuyut(Console.ReadLine());

            Console.Write("Soyadı: ");
            o.soyad = ilkharfibuyut(Console.ReadLine());

            Console.Write("Subesi: ");
            o.sube = Console.ReadLine();

            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? E/H: ");
            string kaydet = Console.ReadLine().ToUpper();
            if (kaydet == "E")
            {
                ogrenciler.Add(o);
                Console.WriteLine("Öğrenci Eklendi");
            }
            else if (kaydet == "H")
            {
                Console.WriteLine("Öğrenci Eklenmedi");
            }
            else
            {
                Console.WriteLine("Hatalı işlem yapıldı!");
            }
        }



        static void ogrencilistele()
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Gösterilecek öğrenci yok.");
                return;
            }

            Console.WriteLine("2- Öğrenci Listele");
            Console.WriteLine("Ad         Soyad      Şube      No");
            Console.WriteLine("----------------------------------");

            foreach (ogrenci item in ogrenciler)
            {
                Console.WriteLine(item.ad.PadRight(10) + item.soyad.PadRight(10) + item.sube.PadRight(10) + item.no.ToString().PadLeft(4));
            }
        }
        static void ogrencisilme()
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek öğrenci yok.");
                return;
            }

            Console.WriteLine("3- Öğrenci Sil");
            Console.Write("Silmek istediğiniz öğrencinin numarasını girin: ");
            if (int.TryParse(Console.ReadLine(), out int silinecekNo))
            {

                ogrenci silinecekOgrenci = ogrenciler.FirstOrDefault(o => o.no == silinecekNo);
                if (silinecekOgrenci != null)
                {
                    ogrenciler.Remove(silinecekOgrenci);
                    Console.WriteLine($"Numarası {silinecekNo} olan öğrenci silindi.");
                }
                else
                {
                    Console.WriteLine($"Numarası {silinecekNo} olan bir öğrenci bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz bir numara girdiniz.");
            }
        }

        static void sahteveri()
        {
            ogrenci o1 = new ogrenci();
            o1.ad = "mehmet";
            o1.soyad = "kulubecioglu";
            o1.sube = "A";
            o1.no = 365;
            ogrenciler.Add(o1);

            ogrenci o2 = new ogrenci();
            o2.ad = "ali";
            o2.soyad = "okuyan";
            o2.sube = "B";
            o2.no = 360;
            ogrenciler.Add(o2);

            ogrenci o3 = new ogrenci();
            o3.ad = "ayşe";
            o3.soyad = "ayşeoğlu";
            o3.sube = "C";
            o3.no = 12;
            ogrenciler.Add(o3);
        }

        static string ilkharfibuyut(string metin)
        {
            return metin.Substring(0, 1).ToUpper() + metin.Substring(1).ToLower();
        }






    }
}
