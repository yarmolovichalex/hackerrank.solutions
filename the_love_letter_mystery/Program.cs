using System;

namespace the_love_letter_mystery
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string word = Console.ReadLine();
                int result = 0;

                int length = word.Length;
                for (int j = 0; j < length/2; j++)
                {
                    result += Math.Abs(word[j] - word[length - j - 1]);
                }

                Console.WriteLine(result);
            }
        }
    }
}
