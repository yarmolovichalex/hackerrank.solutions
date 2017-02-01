using System;
using System.Collections.Generic;
using System.Linq;

namespace binary_search_ice_cream_parlor
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int money = Convert.ToInt32(Console.ReadLine());
                int numbersOfFlavors = Convert.ToInt32(Console.ReadLine());
                int[] flavors = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                var map = new Dictionary<int, int>();
                for (int j = 0; j < numbersOfFlavors; j++)
                {
                    int complement = money - flavors[j];
                    if (map.ContainsKey(complement))
                    {
                        var listOfKeys = new List<int> { j + 1, map[complement] }
                            .OrderBy(l => l)
                            .ToList();

                        Console.WriteLine($"{listOfKeys[0]} {listOfKeys[1]}");
                        break;
                    }

                    if (!map.ContainsKey(flavors[j]))
                        map.Add(flavors[j], j + 1);
                }
            }

            Console.Read();
        }
    }
}
