using System;
using System.Collections.Generic;
using System.Linq;

namespace interquartile_range
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
            var frequencies = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            var seq = new List<int>();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < frequencies[i]; j++)
                {
                    seq.Add(data[i]);
                }
            }

            seq.Sort();

            var result = getInterquartileRange(seq);
            Console.WriteLine(result.ToString("0.0"));
        }

        static double getInterquartileRange(List<int> seq)
        {
            var count = seq.Count;

            var q1 = calculateMedianOfSortedSeq(seq.Take(count / 2).ToList(), count / 2);
            var q3 = calculateMedianOfSortedSeq(seq.Skip((count + 1) / 2).Take(count / 2).ToList(), count / 2);

            return q3 - q1;
        }

        static double calculateMedianOfSortedSeq(List<int> seq, int count)
        {
            var middleIndex = count / 2;

            var result = count % 2 == 0 ?
                ((double)seq[middleIndex - 1] + seq[middleIndex]) / 2
                : seq[middleIndex];

            return result;
        }
    }
}
