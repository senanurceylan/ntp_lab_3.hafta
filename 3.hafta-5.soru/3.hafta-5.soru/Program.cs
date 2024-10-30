using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_5.soru
{
    class PolynomResult
    {
        // Polinomun katsayılarını ve derecelerini tutmak için kullanılacak sınıf.
        public int[] Coefficients { get; set; } // Katsayılar
        public int[] Degrees { get; set; } // Dereceler
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Program sonsuz döngüde çalışacak, kullanıcı 'exit' yazana kadar devam edecek.
        while (true)
            {
                // Kullanıcıdan polinomları alıyoruz.
                Console.WriteLine("İki polinom girin (örnek: 3x^2 + 5x + 8). Çıkmak için 'exit' yazın.");

                // İlk polinomu kullanıcıdan alıyoruz.
                Console.Write("Polinom 1: ");
                string polinom1 = Console.ReadLine();
                // Eğer kullanıcı 'exit' yazarsa program sonlanır.
                if (polinom1.ToLower() == "exit") break;

                // İkinci polinomu kullanıcıdan alıyoruz.
                Console.Write("Polinom 2: ");
                string polinom2 = Console.ReadLine();
                // Eğer kullanıcı 'exit' yazarsa program sonlanır.
                if (polinom2.ToLower() == "exit") break;

                // Kullanıcının girdiği polinomları ayrıştırıyoruz ve katsayılar ile dereceler dizilerini oluşturuyoruz.
                ParsePolynom(polinom1, out int[] coefficients1, out int[] degrees1);
                ParsePolynom(polinom2, out int[] coefficients2, out int[] degrees2);

                // Polinomları topluyoruz.
                PolynomResult addedPolynom = AddPolynoms(coefficients1, degrees1, coefficients2, degrees2);
                Console.WriteLine("Polinomların toplamı: ");
                // Toplama sonucunu ekrana yazdırıyoruz.
                PrintPolynom(addedPolynom.Coefficients, addedPolynom.Degrees);

                // Polinomları çıkarıyoruz.
                PolynomResult subtractedPolynom = SubtractPolynoms(coefficients1, degrees1, coefficients2, degrees2);
                Console.WriteLine("Polinomların farkı: ");
                // Çıkarma sonucunu ekrana yazdırıyoruz.
                PrintPolynom(subtractedPolynom.Coefficients, subtractedPolynom.Degrees);
            }
        }
        private static void PrintPolynom(int[] coefficients, int[] degrees)
        {
            bool firstTerm = true; // İlk terimi belirtmek için bir bayrak.
            for (int i = degrees.Length - 1; i >= 0; i--) // Dereceleri yüksekten küçüğe doğru yazdırıyoruz.
            {
                if (coefficients[i] == 0) continue; // Eğer katsayı sıfırsa o terimi atlıyoruz.

                string term = ""; // Terim, bir string olarak oluşturulacak.
                if (coefficients[i] > 0 && !firstTerm)
                {
                    term += "+"; // Pozitif bir katsayı varsa ve ilk terim değilse, başına "+" koyuyoruz.
                }

                if (degrees[i] == 0) // Derecesi 0 olan terimler sabit sayı olur (örneğin 5).
                {
                    term += coefficients[i];
                }
                else if (degrees[i] == 1) // Derecesi 1 olan terimler (örneğin 3x gibi).
                {
                    term += coefficients[i] + "x";
                }
                else // Derecesi 2 veya daha büyük olan terimler (örneğin 2x^2 gibi).
                {
                    term += coefficients[i] + "x^" + degrees[i];
                }

                Console.Write(term + " "); // Terimi ekrana yazdırıyoruz.
                firstTerm = false; // Artık ilk terim olmadığını belirtiyoruz.
            }
            Console.WriteLine(); // Bir sonraki satıra geçiyoruz.
        }

        // Kullanıcının girdiği polinomu ayrıştıran fonksiyon.
        // Bu fonksiyon polinomu katsayılar ve dereceler olarak iki diziye ayırır.
        private static void ParsePolynom(string polynomInput, out int[] coefficients, out int[] degrees)
        {
            // Polinomu terimlerine ayırıyoruz (örneğin "2x^2", "3x", "-5" gibi).
            string[] terms = polynomInput.Replace("-", "+-").Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

            // Her terim için bir katsayı ve derece dizisi oluşturuyoruz.
            coefficients = new int[terms.Length];
            degrees = new int[terms.Length];

            // Her terimi katsayı ve dereceye ayırıyoruz.
            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i].Trim(); // Terimi düzenliyoruz.
                if (term.Contains("x")) // Eğer terim x içeriyorsa.
                {
                    string[] parts = term.Split('x'); // x ile terimi ikiye bölüyoruz.
                    coefficients[i] = parts[0] == "" || parts[0] == "+" ? 1 : parts[0] == "-" ? -1 : int.Parse(parts[0]); // Katsayıyı belirliyoruz.
                    degrees[i] = parts.Length > 1 && parts[1].Contains("^") ? int.Parse(parts[1].Replace("^", "")) : 1; // Dereceyi belirliyoruz.
                }
                else
                {
                    // Eğer terim sabit sayıysa, katsayı sabit sayı olur ve derecesi 0 olur.
                    coefficients[i] = int.Parse(term);
                    degrees[i] = 0;
                }
            }
        }

        // İki polinomu toplama işlemi yapan fonksiyon.
        static PolynomResult AddPolynoms(int[] coefficients1, int[] degrees1, int[] coefficients2, int[] degrees2)
        {
            // En yüksek dereceli terimi buluyoruz.
            int maxDegree = GetMaxDegree(degrees1, degrees2);
            int[] resultCoefficients = new int[maxDegree + 1]; // Toplam katsayıları tutmak için bir dizi.

            // İlk polinomun terimlerini toplama sonucuna ekliyoruz.
            for (int i = 0; i < coefficients1.Length; i++)
            {
                resultCoefficients[degrees1[i]] += coefficients1[i];
            }

            // İkinci polinomun terimlerini toplama sonucuna ekliyoruz.
            for (int i = 0; i < coefficients2.Length; i++)
            {
                resultCoefficients[degrees2[i]] += coefficients2[i];
            }

            // Toplama sonucunu döndürüyoruz.
            return new PolynomResult { Coefficients = resultCoefficients, Degrees = GenerateDegrees(maxDegree) };
        }

        // İki polinomu çıkarma işlemi yapan fonksiyon.
        static PolynomResult SubtractPolynoms(int[] coefficients1, int[] degrees1, int[] coefficients2, int[] degrees2)
        {
            // En yüksek dereceli terimi buluyoruz.
            int maxDegree = GetMaxDegree(degrees1, degrees2);
            int[] resultCoefficients = new int[maxDegree + 1]; // Sonuç katsayılarını tutmak için bir dizi.

            // İlk polinomun terimlerini çıkarma sonucuna ekliyoruz.
            for (int i = 0; i < coefficients1.Length; i++)
            {
                resultCoefficients[degrees1[i]] += coefficients1[i];
            }

            // İkinci polinomun terimlerini çıkarma sonucundan çıkarıyoruz.
            for (int i = 0; i < coefficients2.Length; i++)
            {
                resultCoefficients[degrees2[i]] -= coefficients2[i];
            }

            // Çıkarma sonucunu döndürüyoruz.
            return new PolynomResult { Coefficients = resultCoefficients, Degrees = GenerateDegrees(maxDegree) };
        }

        // En yüksek dereceli terimi bulan fonksiyon.
        private static int GetMaxDegree(int[] degrees1, int[] degrees2)
        {
            // İlk ve ikinci polinomun en yüksek derecesini buluyoruz.
            int max1 = degrees1.Length > 0 ? degrees1[degrees1.Length - 1] : 0;
            int max2 = degrees2.Length > 0 ? degrees2[degrees2.Length - 1] : 0;
            return Math.Max(max1, max2); // İkisi arasından en yüksek olanı döndürüyoruz.
        }

        // Dereceleri oluşturan fonksiyon.
        private static int[] GenerateDegrees(int maxDegree)
        {
            int[] degrees = new int[maxDegree + 1]; // Dereceleri tutmak için bir dizi oluşturuyoruz.
            for (int i = 0; i <= maxDegree; i++)
            {
                degrees[i] = i; // Her derecenin sırasını dizinin index'i ile eşleştiriyoruz.
            }
            return degrees; // Dereceler dizisini döndürüyoruz.
        }
    }
}