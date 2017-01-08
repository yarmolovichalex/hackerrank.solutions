using System;
using System.Collections.Generic;
using System.Linq;

namespace quartiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            writeQuartiles(data, count);
        }

        static void writeQuartiles(List<int> data, int count)
        {
            data.Sort();

            var q2 = calculateMedianOfSortedSeq(data, count);
            var q1 = calculateMedianOfSortedSeq(data.Take(count/2).ToList(), count/2);
            var q3 = calculateMedianOfSortedSeq(data.Skip((count + 1)/2).Take(count/2).ToList(), count/2);

            Console.WriteLine(q1);
            Console.WriteLine(q2);
            Console.WriteLine(q3);
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
