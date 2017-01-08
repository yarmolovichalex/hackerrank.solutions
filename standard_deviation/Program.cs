using System;
using System.Collections.Generic;
using System.Linq;

namespace standard_deviation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            var standardDeviation = calculateStandardDeviation(data, n);
            Console.WriteLine(standardDeviation.ToString("0.0"));
        }

        static double calculateStandardDeviation(List<int> data, int n)
        {
            var mean = calculateMean(data);
            var sumOfSquaredDistances = data.Aggregate(0.0, (seed, item) => seed += Math.Pow(item - mean, 2));
            var standardDeviation = Math.Sqrt(sumOfSquaredDistances/n);

            return standardDeviation;
        }

        static double calculateMean(ICollection<int> seq)
        {
            var result = (double)seq.Sum() / seq.Count;
            return result;
        }
    }
}
