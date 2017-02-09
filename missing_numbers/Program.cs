using System;
using System.Collections.Generic;
using System.Linq;

namespace missing_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthA = int.Parse(Console.ReadLine());
            int[] arrA = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int lengthB = int.Parse(Console.ReadLine());
            int[] arrB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var dictB = new Dictionary<int, int>();
            foreach (var item in arrB)
            {
                if (dictB.ContainsKey(item))
                    dictB[item]++;
                else
                    dictB.Add(item, 1);
            }

            foreach (var item in arrA)
            {
                dictB[item]--;
                if (dictB[item] == 0)
                    dictB.Remove(item);
            }

            Console.WriteLine(string.Join(" ", dictB.Keys.OrderBy(x => x)));
        }
    }
}
