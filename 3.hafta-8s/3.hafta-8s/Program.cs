using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_8s
{
    class Program
    {
        // Fibonacci sayısını hesaplayan bir fonksiyon.
        // Bu fonksiyon, n'inci Fibonacci sayısını döndürür.
        static int Fibonacci(int n)
        {
            if (n <= 1) return n; // Fibonacci(0) = 0, Fibonacci(1) = 1.
            int a = 0, b = 1, temp;
            for (int i = 2; i <= n; i++)
            {
                temp = a + b; // Fibonacci serisinin bir sonraki sayısını hesaplıyoruz.
                a = b; // Önceki iki Fibonacci sayısını güncelliyoruz.
                b = temp; // Yeni Fibonacci sayısını güncelliyoruz.
            }
            return b; // Hesaplanan Fibonacci sayısını döndürüyoruz.
        }

        // Bir sayının asal olup olmadığını kontrol eden fonksiyon.
        // Asal sayılar sadece 1 ve kendisi ile tam bölünebilen sayılardır.
        static bool IsPrime(int number)
        {
            if (number <= 1) return false; // 1 ve daha küçük sayılar asal değildir.
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false; // Eğer tam bölünüyorsa asal değildir.
            }
            return true; // Eğer yukarıdaki koşulları sağlamıyorsa asal sayıdır.
        }

        // Şifrelenmiş mesajı çözmek için kullanılan fonksiyon.
        static string DecryptMessage(string encryptedMessage)
        {
            // Çözülmüş karakterleri tutmak için bir liste oluşturuyoruz.
            List<char> decryptedChars = new List<char>();

            // Şifreli mesajdaki her bir karakter için döngü başlatıyoruz.
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                char currentChar = encryptedMessage[i]; // Şifreli karakteri alıyoruz.
                int asciiValue = (int)currentChar; // Karakterin ASCII değerini alıyoruz.

                // Fibonacci değerini buluyoruz (Pozisyon 1'den başladığı için i + 1 kullanıyoruz).
                int fib = Fibonacci(i + 1);

                // Orijinal ASCII değerini bulmak için mod işlemini tersine çeviriyoruz.
                int originalValue = 0;

                // Pozisyonun asal olup olmadığını kontrol ediyoruz.
                if (IsPrime(i + 1)) // Eğer pozisyon asal ise
                {
                    // Mod 100 işlemini geri alıyoruz.
                    originalValue = asciiValue + 100 * (fib - (asciiValue % 100)) / 100;
                }
                else // Eğer pozisyon asal değilse
                {
                    // Mod 256 işlemini geri alıyoruz.
                    originalValue = asciiValue + 256 * (fib - (asciiValue % 256)) / 256;
                }

                // Orijinal ASCII değeri 0-255 aralığında kalmalı, bu yüzden mod 256 alıyoruz.
                originalValue = originalValue % 256;

                // Çözülmüş karakteri listeye ekliyoruz.
                decryptedChars.Add((char)originalValue);
            }

            // Karakter listesini bir string'e çevirip döndürüyoruz.
            return new string(decryptedChars.ToArray());
        }

        // Programın giriş noktası.
        static void Main(string[] args)
        {
            // Şifrelenmiş bir mesaj tanımlıyoruz.
            string encryptedMessage = "Şifreli mesaj"; // Burada örnek bir şifreli mesaj veriyoruz.

            // Şifreli mesajı çözmek için fonksiyonu çağırıyoruz.
            string decryptedMessage = DecryptMessage(encryptedMessage);

            // Şifreli mesaj ve çözülen mesajı ekrana yazdırıyoruz.
            Console.WriteLine($"Şifrelenmiş Mesaj: {encryptedMessage}");
            Console.WriteLine($"Orijinal Mesaj: {decryptedMessage}");

            // Programın sonlanmasını beklemek için kullanıcıdan bir tuşa basmasını istiyoruz.
            Console.ReadKey();
        }
    }
}
