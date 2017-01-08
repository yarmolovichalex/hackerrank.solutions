using System;
using System.Collections.Generic;
using System.Linq;

namespace strings_making_anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            var dictA = new Dictionary<char, int>();
            var dictB = new Dictionary<char, int>();

            countCharsOccurences(dictA, a);
            countCharsOccurences(dictB, b);

            int commonCharsCount =
                dictA.Keys
                    .Where(key => dictB.ContainsKey(key))
                    .Sum(key => Math.Min(dictA[key], dictB[key]));

            int result = a.Length + b.Length - commonCharsCount * 2;

            Console.WriteLine(result);
        }

        static void countCharsOccurences(Dictionary<char, int> storage, string s)
        {
            foreach (var c in s)
            {
                if (!storage.ContainsKey(c))
                {
                    storage[c] = 1;
                }
                else
                {
                    storage[c]++;
                }
            }
        }
    }
}
