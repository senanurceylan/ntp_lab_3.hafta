using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_1s
{
    class Program
    {

        /*
         * 1) Kullanıcıdan bir dizi tam sayı alın ve bu sayıları sıralayın. Ardından, kullanıcıdan bir
        sayı alın ve bu sayının dizide olup olmadığını ikili arama algoritması ile kontrol edin.
        Sonucu ekrana yazdırın.
         */


        static void Main(string[] args)
        {
            // Kullanıcıdan dizi uzunluğunu al
            Console.Write("Kaç adet sayı girilecek ise okadar sayi gir ");
            int n = int.Parse(Console.ReadLine());

            // Kullanıcıdan dizi elemanlarını al
            int[] sayilar = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Sayı {0}: ", i + 1);
                sayilar[i] = int.Parse(Console.ReadLine());
            }

            // Diziyi sıralama
            Array.Sort(sayilar);   // sort sıralama
            Console.WriteLine("\nSıralanmış dizi:");
            foreach (int sayi in sayilar)
            {
                Console.Write(sayi + " ");
            }

            // Kullanıcıdan arama yapılacak sayıyı al
            Console.Write("\n\nAramak istediğiniz sayıyı girin: ");
            int aranacakSayi = int.Parse(Console.ReadLine());

            // İkili arama (Binary Search) ile sayıyı arama
            int indeks = Array.BinarySearch(sayilar, aranacakSayi); 

            // Sonucu ekrana yazdırma
            if (indeks >= 0)
            {
                Console.WriteLine("Aranan sayı dizinin {0}. indeksinde bulundu.", indeks);
            }
            else
            {
                Console.WriteLine("Aranan sayı dizide bulunamadı!");
            }
        }
    }

    }

