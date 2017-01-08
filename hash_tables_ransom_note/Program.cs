using System;
using System.Linq;

namespace hash_tables_ransom_note
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int m = parameters[0];
            int n = parameters[1]; 
            var magazineWords = Console.ReadLine().Split(' ');
            var ransomWords = Console.ReadLine().Split(' ');

            var magazineWordsDict = magazineWords.GroupBy(word => word)
                .ToDictionary(group => group.Key, group => group.Count());

            var ransomWordsDict = ransomWords.GroupBy(word => word)
                .ToDictionary(group => group.Key, group => group.Count());

            bool success = 
                ransomWordsDict.Keys
                .All(word => magazineWordsDict.ContainsKey(word) && magazineWordsDict[word] >= ransomWordsDict[word]);

            Console.WriteLine(success ? "Yes" : "No");
        }
    }
}