using System;
using System.Collections.Generic;
using System.Linq;

namespace weighted_mean
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
            var weights = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            double result = calculateWeightedMean(count, data, weights);
            Console.WriteLine(result.ToString("0.0"));
        }

        static double calculateWeightedMean(int count, List<int> data, List<int> weights)
        {
            double weightedSum = 0.0;
            for (int i = 0; i < count; i++)
            {
                weightedSum += data[i]*weights[i];
            }

            double result = weightedSum/weights.Sum();

            return Math.Round(result, 1);
        }
    }
}
