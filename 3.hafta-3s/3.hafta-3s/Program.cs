using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_3s
{
    class Program
    {
        /*
         3) Kullanıcıdan bir dizi tamsayı alın ve bu dizideki ardışık sayı gruplarını tespit eden bir
         program yazın. Örneğin, 1, 2, 3, 5, 6, 7, 10 dizisi için program, 1-3 ve 5-7 gruplarını
          döndürmelidir. Kullanıcı 0 girene kadar sayıları almaya devam etsin.
         */
        static void Main(string[] args)
        {
            int[] dizi = new int[0];  // elemanı olmayan bir dizi oluşturuyoruz
            int girilenSayi;

            do
            {
                Console.Write(" bir tam sayı giriniz(0 sonlandırır)");
                girilenSayi = int.Parse(Console.ReadLine());

                if (girilenSayi != 0)
                {
                    Array.Resize(ref dizi, dizi.Length + 1);
                    // şimdi burda  resize ile diziye ekleme yaptık
                    dizi[dizi.GetUpperBound(0)] = girilenSayi;
                    // bu kısımda kullanıcvıdan alınan sayıyı diziye ekliyor
                    // dizi[dizi.GetUpperBound(0)]  dizinin en son elemanını ifade eder  ve yeni değeri atar
                }
                } while (girilenSayi != 0) ;

                if (dizi.Length == 0)
                {
                    Console.WriteLine("hiç sayı girilmedi");
                    return;
                }

                Array.Sort(dizi);
            Console.WriteLine("ardışık sayı grupları");
            int baslangic = dizi[0];
            int onceki = dizi[0];

            for(int i=1; i< dizi.Length; i++)
            {
                if (dizi[i] != onceki + 1)
                {
                    if (baslangic == onceki)
                    {
                        Console.WriteLine(baslangic);
                    }
                    else
                    {
                        Console.WriteLine($"{baslangic}-{onceki}");
                    }

                    baslangic = dizi[i];
                }
                onceki=dizi[i];
            }
            // başlangıç ve önceki değer arasındadır

            if(baslangic==onceki)
            {
                Console.WriteLine(baslangic);
            }
            else
            {
                Console.WriteLine($"{baslangic}-{onceki}");
                // parantez içine yazılanı string yapmamızı sağlar 
            }

            }



        }
    }
}
