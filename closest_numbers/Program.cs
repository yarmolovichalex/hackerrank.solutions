using System;
using System.Collections.Generic;
using System.Linq;

namespace closest_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Array.Sort(numbers);

            int minDiff = int.MaxValue;
            List<int> pairs = new List<int>();

            for (int i = 1; i < numbers.Length; i++)
            {
                int diff = numbers[i] - numbers[i - 1];
                if (minDiff > diff)
                {
                    minDiff = diff;
                    pairs.Clear();
                    pairs.Add(numbers[i]);
                    pairs.Add(numbers[i - 1]);
                }
                else if (minDiff == diff)
                {
                    pairs.Add(numbers[i]);
                    pairs.Add(numbers[i - 1]);
                }
            }

            string result = string.Join(" ", pairs.OrderBy(p => p));
            Console.WriteLine(result);
        }
    }
}
