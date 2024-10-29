using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_10s
{
    class Program
    {
        // Bu ana fonksiyon programın çalışmaya başladığı yerdir.
        // Kullanıcıdan bir sayı dizisi alacağız ve bu diziyi çözmek için operatörler ekleyerek doğru sonucu bulacağız.
        static void Main(string[] args)
        {
            // İlk olarak kullanıcıdan sayı dizisini alıyoruz.
            Console.WriteLine("Lütfen bir sayı dizisi girin (örnek: 1, 2, 3): ");
            string input = Console.ReadLine();

            // Sayı dizisini virgüllerle ayırarak diziye çeviriyoruz.
            string[] sayilarStr = input.Split(',');
            int[] sayilar = new int[sayilarStr.Length];

            // String olan sayı dizisini tam sayıya çeviriyoruz.
            for (int i = 0; i < sayilarStr.Length; i++)
            {
                sayilar[i] = int.Parse(sayilarStr[i].Trim());
            }

            // Bu aşamada tüm operatörlerin kombinasyonlarını deneyeceğiz.
            Console.WriteLine("Tüm olası kombinasyonları deniyoruz...");

            // Başlangıç durumu için bir çözüm bulmaya çalışıyoruz.
            // Bu fonksiyon tüm olasılıkları deneyerek sonucu bulacak.
            OperatorKombinasyonlariDeneme(sayilar, 0, sayilar[0].ToString());
            Console.ReadKey();
                
        }

        // Bu fonksiyon, belirli bir sayı dizisi üzerinde operatörlerin kombinasyonlarını dener.
        // Operatörler toplama (+), çıkarma (-), çarpma (*) ve bölme (/) olacaktır.
        static void OperatorKombinasyonlariDeneme(int[] sayilar, int index, string ifade)
        {
            // Eğer dizinin sonuna geldiysek artık sonucu değerlendirmemiz gerekiyor.
            if (index == sayilar.Length - 1)
            {
                // İfadeyi hesaplayıp sonucu buluyoruz.
                double sonuc = Hesapla(ifade);

                // Sonuç sıfırdan büyük mü kontrol ediyoruz.
                if (sonuc > 0)
                {
                    // Eğer sonuç sıfırdan büyükse bu, geçerli bir kombinasyon demektir.
                    Console.WriteLine("Geçerli kombinasyon: " + ifade + " = " + sonuc);
                }
                return;
            }

            // Operatörler arasında döngü yapıyoruz ve her bir operatörü deniyoruz.
            // Toplama
            OperatorKombinasyonlariDeneme(sayilar, index + 1, ifade + " + " + sayilar[index + 1]);
            // Çıkarma
            OperatorKombinasyonlariDeneme(sayilar, index + 1, ifade + " - " + sayilar[index + 1]);
            // Çarpma
            OperatorKombinasyonlariDeneme(sayilar, index + 1, ifade + " * " + sayilar[index + 1]);
            // Bölme (bölünen sıfır olmamalı)
            if (sayilar[index + 1] != 0)
            {
                OperatorKombinasyonlariDeneme(sayilar, index + 1, ifade + " / " + sayilar[index + 1]);
            }
        }

        // Bu fonksiyon bir ifadeyi alır ve sonucunu hesaplar.
        // Örneğin "1 + 2 * 3" gibi bir ifadeyi çözerek sonucunu bulur.
        static double Hesapla(string ifade)
        {
            // Bu basitlik açısından, C#'ın DataTable sınıfını kullanarak ifadeyi hesaplıyoruz.
            // Bu sınıf bir string matematiksel ifadeyi alıp sonucunu döndürebilir.
            System.Data.DataTable dt = new System.Data.DataTable();
            var sonuc = dt.Compute(ifade, "");
            return Convert.ToDouble(sonuc);
        }
    }
}