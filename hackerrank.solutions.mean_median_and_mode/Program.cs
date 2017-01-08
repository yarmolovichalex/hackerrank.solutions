using System;
using System.Collections.Generic;
using System.Linq;

namespace mean_median_and_mode
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var list = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            Console.WriteLine(calculateMean(list));
            Console.WriteLine(calculateMedian(list, count));
            Console.WriteLine(calculateMode(list));
        }

        static double calculateMean(ICollection<int> seq)
        {
            var result = (double) seq.Sum()/seq.Count;
            return Math.Round(result, 1);
        }

        static double calculateMedian(List<int> seq, int count)
        {
            seq.Sort();

            var middleIndex = count / 2;

            var result = count%2 == 0 ? 
                ((double) seq[middleIndex - 1] + seq[middleIndex])/2 
                : seq[middleIndex];
          
            return result;
        }

        static double calculateMode(ICollection<int> seq)
        {
            var groups =
                (from item in seq group item by item into g select new {g.Key, Count = g.Count()})
                .ToDictionary(g => g.Key, g => g.Count);

            var maxCount = groups.Max(x => x.Value);
            var result = groups.Where(x => x.Value == maxCount).Min(x => x.Key);

            return result;
        }
    }
}
