using System;

namespace algorithmic_crush
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] parameters = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long n = parameters[0];
            long m = parameters[1];

            long[] arr = new long[n];
            for (long i = 0; i < m; i++)
            {
                long[] data = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                long a = data[0];
                long b = data[1];
                long sum = data[2];

                arr[a - 1] += sum;
                if (b < n)
                    arr[b] -= sum;
            }

            long temp = 0;
            long max = 0;
            for (int i = 0; i < n; i++)
            {
                temp += arr[i];
                if (max < temp)
                    max = temp;
            }

            Console.WriteLine(max);
        }
    }
}
