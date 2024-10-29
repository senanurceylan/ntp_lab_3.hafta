using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.hafta_4s
{
    class Program
    {

        /*
       4) Kullanıcının girdiği matematiksel ifadeyi (örneğin, 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3) işlem
      nceliklerine göre çözümleyen bir program yazın. Program, sonucu yazdırmadan önce
      ifadenin çözüm sürecini açıklamalıdır (hangi işlemlerin hangi sırayla yapıldığını
     gösterin).
        */
        static int GetPrecedence(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            if (op == '^') return 3;
            return 0;
        }

        // Verilen operatörün işlem yapmasını sağlayan fonksiyon
        static double ApplyOperation(double a, double b, char op)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                case '^': return Math.Pow(a, b);
                default: return 0;
            }
        }

        // Postfix notasyonuna göre verilen matematiksel ifadeyi çözümleyen fonksiyon
        static double EvaluatePostfix(List<string> postfix, List<string> steps)
        {
            Stack<double> stack = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token, out double num)) // Eğer sayıysa
                {
                    stack.Push(num);
                }
                else // Operatörse
                {
                    double val2 = stack.Pop();
                    double val1 = stack.Pop();
                    double result = ApplyOperation(val1, val2, token[0]);

                    // Çözüm sürecini kaydediyoruz
                    steps.Add($"{val1} {token} {val2} = {result}");

                    stack.Push(result);
                }
            }

            return stack.Pop();
        }

        // Infix (normal) ifadeyi postfix (ters polonya notasyonu) haline çeviren fonksiyon
        static List<string> InfixToPostfix(string expression)
        {
            Stack<char> operators = new Stack<char>();
            List<string> postfix = new List<string>();
            Regex regex = new Regex(@"\d+(\.\d+)?|[+\-*/^()]");
            var tokens = regex.Matches(expression);

            foreach (Match token in tokens)
            {
                string t = token.Value;

                if (double.TryParse(t, out double _)) // Sayı ise
                {
                    postfix.Add(t);
                }
                else if (t == "(") // Parantez açılışı
                {
                    operators.Push('(');
                }
                else if (t == ")") // Parantez kapanışı
                {
                    while (operators.Peek() != '(')
                        postfix.Add(operators.Pop().ToString());
                    operators.Pop(); // '(' operatörünü yığınından çıkar
                }
                else // Operatör
                {
                    char op = t[0];

                    while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(op))
                        postfix.Add(operators.Pop().ToString());

                    operators.Push(op);
                }
            }

            while (operators.Count > 0)
                postfix.Add(operators.Pop().ToString());

            return postfix;
        }

        static void Main()
        {
            Console.WriteLine("Bir matematiksel ifade girin: ");
            string ifade = Console.ReadLine();

            // Infix ifadeyi postfix'e çeviriyoruz
            List<string> postfix = InfixToPostfix(ifade);

            // Çözüm adımlarını tutacak liste
            List<string> steps = new List<string>();

            // Postfix ifadeyi değerlendiriyoruz ve adımları kaydediyoruz
            double sonuc = EvaluatePostfix(postfix, steps);

            // Çözüm sürecini yazdırma
            Console.WriteLine("\nÇözüm süreci:");
            foreach (var step in steps)
            {
                Console.WriteLine(step);
            }

            // Sonucu yazdırma
            Console.WriteLine($"\nSonuç: {sonuc}");
        }
    }