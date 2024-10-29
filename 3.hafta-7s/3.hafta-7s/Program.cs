using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.hafta_7s
{
    class Program
    {
        struct Cell
        {
            public int X;
            public int Y;

            public Cell(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static bool IsValidCell(int x, int y)
        {
            if (!IsPrime(x) || !IsPrime(y))
                return false;

            if ((x + y) % (x * y) != 0)
                return false;

            return true;
        }

        static bool FindPath(int[,] maze, int x, int y, List<Cell> path)
        {
            int M = maze.GetLength(0);
            int N = maze.GetLength(1);

            if (x == M - 1 && y == N - 1)
            {
                path.Add(new Cell(x, y));
                return true;
            }

            if (!IsValidCell(x, y) || maze[x, y] == 1)
                return false;

            maze[x, y] = 1; // Ziyaret edildi
            path.Add(new Cell(x, y));

            if (FindPath(maze, x + 1, y, path) ||
                FindPath(maze, x, y + 1, path) ||
                FindPath(maze, x - 1, y, path) ||
                FindPath(maze, x, y - 1, path))
            {
                return true;
            }

            path.RemoveAt(path.Count - 1);
            return false;
        }

        static void Main()
        {
            int M = 10;
            int N = 10;
            int[,] maze = new int[M, N];

            // Geçilemez hücreleri tanımlıyoruz
            maze[2, 2] = 1;
            maze[3, 4] = 1;
            maze[5, 6] = 1;

            List<Cell> path = new List<Cell>();

            if (FindPath(maze, 0, 0, path))
            {
                Console.WriteLine("Şehre giden yol:");
                foreach (var step in path)
                {
                    Console.WriteLine($"({step.X}, {step.Y})");
                }
            }
            else
            {
                Console.WriteLine("Şehir kayboldu!");
            }

            Console.ReadKey(); // Program bitiminde bir tuşa basılmasını bekle
        }
    }
}