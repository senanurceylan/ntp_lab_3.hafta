using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_2s
{
    class Program
    {
        static void Main(string[] args)
        {

            /*2) Kullanıcıdan pozitif tam sayılar alarak, bu sayıların ortalamasını ve medyanını
          hesaplayan bir program yazın. Kullanıcı 0 girene kadar sayıları almaya devam etsin. 0
         girildiğinde ortalamayı ve medyanı gösterin.
             
             -------------------------AÇIKLAMA-------------------------------------
             Bu soruyu ya dizi yada liste oluşturarak çözebilriz dizi oluşturursak 
             Array.Resize metodunu kullanmamız lazım çünki normalde dizilerin boyutu değiştirilemez
             ---------------------------------------------------------------------------

             */
            // Dizi oluşturma (başlangıçta boş bir dizi)
            int[] sayilar = new int[0];
            int girilenSayi;
            int toplam = 0;
            int elemanSayisi = 0;

            // Kullanıcıdan 0 girene kadar pozitif tam sayılar alıyoruz
            while (true)
            {
                Console.Write("Lütfen pozitif bir sayı giriniz (0 sonlandırır): ");
                girilenSayi = int.Parse(Console.ReadLine());

                if (girilenSayi == 0)
                {
                    break;
                }

                if (girilenSayi > 0)
                {
                    // Diziyi genişletiyoruz ve yeni sayıyı ekliyoruz
                    Array.Resize(ref sayilar, sayilar.Length + 1);
                    sayilar[sayilar.Length - 1] = girilenSayi;

                    // Toplamı ve eleman sayısını güncelle
                    toplam += girilenSayi;
                    elemanSayisi++;// eleman sayısını  her sayı girildiğinde 1 artar 
                }
                else
                {
                    Console.WriteLine("Lütfen pozitif bir sayı giriniz.");
                }
            }

            // Eğer dizi boşsa programı bitiriyoruz
            if (elemanSayisi == 0)
            {
                Console.WriteLine("Hiç sayı girilmedi.");
                return;
            }

            // Diziyi sıralıyoruz
            Array.Sort(sayilar);

            // Ortalama hesaplama
            double ortalama = (double)toplam / (double)elemanSayisi;
            // burda type Casting dedğimiz tür dönüşümünü uyguluyoruz
            Console.WriteLine("Ortalama: " + ortalama);

            // Medyanı hesaplama
            double medyan;

            if (elemanSayisi % 2 == 1) // Tek eleman sayısı varsa
            {
                medyan = sayilar[elemanSayisi / 2];
            }
            else // Çift eleman sayısı varsa
            {
                medyan = (sayilar[(elemanSayisi / 2) - 1] + sayilar[elemanSayisi / 2]) / 2.0;
            }
            Console.WriteLine("Medyan: " + medyan);
        }
    }
}
    }
}
