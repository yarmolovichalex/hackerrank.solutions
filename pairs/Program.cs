using System;
using System.Collections.Generic;

namespace pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int res;

            String line = Console.ReadLine();
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }

            res = pairs(_a, _k);
            Console.WriteLine(res);

            Console.Read();
        }

        static int pairs(int[] a, int k)
        {
            HashSet<int> set = new HashSet<int>();
            int pairsCount = 0;
            foreach (var item in a)
            {
                if (set.Contains(item + k))
                    pairsCount++;

                if (set.Contains(item - k))
                    pairsCount++;

                set.Add(item);
            }

            return pairsCount;
        }
    }
}
