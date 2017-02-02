using System;

namespace flipping_the_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            for (int query = 0; query < count; query++)
            {
                int n = Convert.ToInt32(Console.ReadLine()) * 2;
                int[][] arr = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    string[] M_temp = Console.ReadLine().Split(' ');
                    arr[i] = Array.ConvertAll(M_temp, int.Parse);
                }

                int sum = 0;
                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        int max = getMax(
                            arr[i][j],
                            arr[n - i - 1][j],
                            arr[i][n - j - 1],
                            arr[n - i - 1][n - j - 1]
                        );

                        sum += max;
                    }
                }

                Console.WriteLine(sum);
            }
        }

        private static int getMax(int a, int b, int c, int d)
        {
            return Math.Max(a, Math.Max(b, Math.Max(c, d)));
        }
    }
}
