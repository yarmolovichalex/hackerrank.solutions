using System;
using System.Collections.Generic;
using System.Linq;

namespace string_reduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int res;
            int _t_cases = Convert.ToInt32(Console.ReadLine());
            for (int _t_i = 0; _t_i < _t_cases; _t_i++)
            {
                String _a = Console.ReadLine();
                res = stringReduction(_a);
                Console.WriteLine(res);
            }
        }

        static int stringReduction(string a)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>
            {
                {'a', 0},
                {'b', 0},
                {'c', 0}
            };

            foreach (char c in a)
            {
                dict[c]++;
            }

            var anyNotNull = dict.First(p => p.Value > 0).Key;

            if (dict.Where(p => p.Key != anyNotNull).All(p => p.Value == 0))
                return dict[anyNotNull];

            return dict.All(p => p.Value % 2 == 0) 
                || dict.All(p => p.Value % 2 == 1) 
                ? 2 : 1;
        }
    }
}
