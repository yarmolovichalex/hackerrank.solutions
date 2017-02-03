using System;

namespace left_rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int n = parameters[0];
            int k = parameters[1];
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = arr[(i + k) % n];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
