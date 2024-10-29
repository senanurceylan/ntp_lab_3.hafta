using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_9s
{

    /*
     açıklamalar
     Sabiti Tanımlama: const int N = 5; ifadesi, matrisin boyutunu tanımlar.
     Enerji Matrisi: int[,] energy ifadesi, her hücredeki enerji maliyetini temsil eden bir matris tanımlar. Matrisin değerleri, hücrelerde harcanacak enerji miktarını gösterir.
     Dinamik Programlama: FindMinEnergy fonksiyonu, verilen enerji matrisini kullanarak hedef noktaya ulaşmanın en az enerji maliyetini hesaplar. 
     Ana Program: Main metodu, enerji matrisini tanımlar ve FindMinEnergy fonksiyonu aracılığıyla en az enerji maliyetini hesaplar. Sonuç, ekrana yazdırılır.
     */
    class Program
    {
        // Enerji matrisinin boyutunu belirleyen sabit
        const int N = 5; // Örnek olarak 5x5 boyutunda bir matris kullanıyoruz.

        // En az enerji harcayarak hedef noktaya ulaşmak için dinamik programlama yöntemini kullanan fonksiyon
        static int FindMinEnergy(int[,] energy)
        {
            // Enerji matrisinin boyutunu alıyoruz.
            int[,] dp = new int[N, N];

            // Başlangıç noktasının enerji maliyetini alıyoruz.
            dp[0, 0] = energy[0, 0];

            // İlk satırı dolduruyoruz (sağa hareket).
            for (int j = 1; j < N; j++)
            {
                dp[0, j] = dp[0, j - 1] + energy[0, j];
            }

            // İlk sütunu dolduruyoruz (aşağı hareket).
            for (int i = 1; i < N; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + energy[i, 0];
            }

            // Diğer hücreleri dolduruyoruz (sağa, aşağı ve çapraz hareket).
            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    // Hücreye ulaşmanın en düşük maliyetini hesaplıyoruz.
                    dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1])) + energy[i, j];
                }
            }

            // Hedef noktaya ulaşmanın en az enerji maliyetini döndürüyoruz.
            return dp[N - 1, N - 1];
        }

        // Ana program
        static void Main(string[] args)
        {
            // Enerji maliyetlerini tutan bir matris tanımlıyoruz.
            // Bu örnekteki değerler, her hücredeki enerji tüketimini temsil ediyor.
            int[,] energy = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 1, 2, 1, 1 },
                { 3, 2, 1, 3, 4 },
                { 4, 5, 2, 1, 2 },
                { 1, 1, 1, 2, 1 }
            };

            // En az enerji harcayarak hedef noktaya ulaşmayı buluyoruz.
            int minEnergy = FindMinEnergy(energy);

            // Sonucu ekrana yazdırıyoruz.
            Console.WriteLine($"(0, 0) noktasından (N-1, N-1) noktasına ulaşmak için en az enerji: {minEnergy}");

            // Programın sonlanmasını beklemek için kullanıcıdan bir tuşa basmasını istiyoruz.
            Console.ReadKey();
        }
    }
}