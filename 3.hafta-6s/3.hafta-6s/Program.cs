using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_6s
{
    class Program
        
    {
        static void Main(string[] args)
        {
            // Şu anki tarihi al
            DateTime now = DateTime.Now;
            // 2000 ile 3000 yılları arasında geçerli tarihleri bulmak için tarih aralığını belirle
            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = new DateTime(3000, 12, 31);

            // Şu andan sonraki tarihler için geçerli tarihleri bul
            List<string> validDates = FindValidDates(now > startDate ? now : startDate, endDate);

            // Geçerli tarihleri yazdır
            foreach (string date in validDates)
            {
                Console.WriteLine(date);
            }
        }
        // Asal sayı kontrolü
        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // Bir sayının rakamları toplamını hesaplar
        static int DigitSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

        // Verilen tarihin geçerli olup olmadığını kontrol eder
        static bool IsValidDate(int day, int month, int year)
        {
            // Günün asal sayı olup olmadığını kontrol et
            if (!IsPrime(day))
                return false;

            // Ay sayısının basamaklarının toplamının çift olup olmadığını kontrol et
            if (DigitSum(month) % 2 != 0)
                return false;

            // Yıl sayısının rakamlarının toplamının, yılın dörtte birinden küçük olup olmadığını kontrol et
            if (DigitSum(year) >= year / 4)
                return false;

            return true;
        }

        // Başlangıç ve bitiş tarihleri arasında geçerli tarihleri bulur
        static List<string> FindValidDates(DateTime startDate, DateTime endDate)
        {
            List<string> validDates = new List<string>();

            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                int day = currentDate.Day;
                int month = currentDate.Month;
                int year = currentDate.Year;

                if (IsValidDate(day, month, year))
                {
                    // Geçerli tarihi listeye ekle
                    validDates.Add(currentDate.ToString("dd-MM-yyyy"));
                }
            }

            return validDates;
        }
    }
