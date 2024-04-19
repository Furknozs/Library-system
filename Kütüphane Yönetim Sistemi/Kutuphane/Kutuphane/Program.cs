using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    class Program
    {
        static List<Kitap> kütüphane = new List<Kitap>();

        static void Main(string[] args)
        {
            bool devam = true;

            while (devam)
            {
                Console.WriteLine("Kütüphane Yönetim Sistemi");
                Console.WriteLine("1. Yeni Kitap Ekle");
                Console.WriteLine("2. Tüm Kitapları Listele");
                Console.WriteLine("3. Kitap Ara");
                Console.WriteLine("4. Kitap Ödünç Al");
                Console.WriteLine("5. Kitap İade Et");
                Console.WriteLine("6. Süresi Geçmiş Kitapları Görüntüle");
                Console.WriteLine("7. Çıkış");
                Console.Write("Bir seçenek girin (1-7): ");

                int secim;
                int.TryParse(Console.ReadLine(), out secim);

                switch (secim)
                {
                    case 1:
                        YeniKitapEkle();
                        break;
                    case 2:
                        TumKitaplariListele();
                        break;
                    case 3:
                        KitapAra();
                        break;
                    case 4:
                        KitapOduncAl();
                        break;
                    case 5:
                        KitapIadeEt();
                        break;
                    case 6:
                        SuresiGecmisKitaplariGoruntule();
                        break;
                    case 7:
                        devam = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz bir seçenek girdiniz.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void YeniKitapEkle()
        {
            Console.WriteLine("Yeni Kitap Ekle");
            Console.Write("Kitap Başlığı: ");
            string baslik = Console.ReadLine();
            Console.Write("Yazar: ");
            string yazar = Console.ReadLine();
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Kopya Sayısı: ");
            int kopyaSayisi;
            int.TryParse(Console.ReadLine(), out kopyaSayisi);

            Kitap yeniKitap = new Kitap
            {
                Baslik = baslik,
                Yazar = yazar,
                ISBN = isbn,
                KopyaSayisi = kopyaSayisi,
                OduncAlinanKopyalar = 0
            };

            kütüphane.Add(yeniKitap);

            Console.WriteLine("Yeni kitap başarıyla eklendi.");
        }

        static void TumKitaplariListele()
        {
            Console.WriteLine("Tüm Kitaplar");
            Console.WriteLine("------------------");

            foreach (Kitap kitap in kütüphane)
            {
                Console.WriteLine("Başlık: " + kitap.Baslik);
                Console.WriteLine("Yazar: " + kitap.Yazar);
                Console.WriteLine("ISBN: " + kitap.ISBN);
                Console.WriteLine("Kopya Sayısı: " + kitap.KopyaSayisi);
                Console.WriteLine("Ödünç Alınan Kopyalar: " + kitap.OduncAlinanKopyalar);
                Console.WriteLine("------------------");
            }
        }

        static void KitapAra()
        {
            //Console.WriteLine("Kitap Ara");
            //Console.Write("Aranacak kelimeyi girin: ");
            //string aramaKelimesi = Console.ReadLine();

            //List<Kitap> bulunanKitaplar = kütüphane.FindAll(kitap =>
            //    kitap.Baslik.Contains(aramaKelimesi, StringComparison.OrdinalIgnoreCase) ||
            //    kitap.Yazar.Contains(aramaKelimesi, StringComparison.OrdinalIgnoreCase));

            //if (bulunanKitaplar.Count == 0)
            //{
            //    Console.WriteLine("Aradığınız kriterlere uygun kitap bulunamadı.");
            //}
            //else
            //{
            //    Console.WriteLine("Arama Sonuçları");
            //    Console.WriteLine("------------------");

            //    foreach (Kitap kitap in bulunanKitaplar)
            //    {
            //        Console.WriteLine("Başlık: " + kitap.Baslik);
            //        Console.WriteLine("Yazar: " + kitap.Yazar);
            //        Console.WriteLine("ISBN: " + kitap.ISBN);
            //        Console.WriteLine("Kopya Sayısı: " + kitap.KopyaSayisi);
            //        Console.WriteLine("Ödünç Alınan Kopyalar: " + kitap.OduncAlinanKopyalar);
            //        Console.WriteLine("------------------");
            //    }
            //}
        }

        static void KitapOduncAl()
        {
            Console.WriteLine("Kitap Ödünç Al");
            Console.Write("Ödünç almak istediğiniz kitabın başlığını girin: ");
            string arananBaslik = Console.ReadLine();

            Kitap oduncAlinanKitap = kütüphane.Find(kitap =>
                kitap.Baslik.Equals(arananBaslik, StringComparison.OrdinalIgnoreCase));

            if (oduncAlinanKitap == null)
            {
                Console.WriteLine("Ödünç almak istediğiniz kitap bulunamadı.");
            }
            else if (oduncAlinanKitap.KopyaSayisi == oduncAlinanKitap.OduncAlinanKopyalar)
            {
                Console.WriteLine("Ödünç almak istediğiniz kitap için kopya bulunmamaktadır.");
            }
            else
            {
                oduncAlinanKitap.OduncAlinanKopyalar++;
                Console.WriteLine("Kitap ödünç alındı.");
            }
        }

        static void KitapIadeEt()
        {
            Console.WriteLine("Kitap İade Et");
            Console.Write("İade etmek istediğiniz kitabın başlığını girin: ");
            string arananBaslik = Console.ReadLine();

            Kitap iadeEdilenKitap = kütüphane.Find(kitap =>
                kitap.Baslik.Equals(arananBaslik, StringComparison.OrdinalIgnoreCase));

            if (iadeEdilenKitap == null)
            {
                Console.WriteLine("İade etmek istediğiniz kitap bulunamadı.");
            }
            else if (iadeEdilenKitap.OduncAlinanKopyalar == 0)
            {
                Console.WriteLine("İade etmek istediğiniz kitap için ödünç alınan kopya bulunmamaktadır.");
            }
            else
            {
                iadeEdilenKitap.OduncAlinanKopyalar--;
                Console.WriteLine("Kitap iade edildi.");
            }
        }

        static void SuresiGecmisKitaplariGoruntule()
        {
            Console.WriteLine("Süresi Geçmiş Kitaplar");
            Console.WriteLine("------------------");

            foreach (Kitap kitap in kütüphane)
            {
                if (kitap.OduncAlinanKopyalar > 0)
                {
                    Console.WriteLine("Başlık: " + kitap.Baslik);
                    Console.WriteLine("Yazar: " + kitap.Yazar);
                    Console.WriteLine("ISBN: " + kitap.ISBN);
                    Console.WriteLine("Kopya Sayısı: " + kitap.KopyaSayisi);
                    Console.WriteLine("Ödünç Alınan Kopyalar: " + kitap.OduncAlinanKopyalar);
                    Console.WriteLine("------------------");
                }
            }
        }
}  }
