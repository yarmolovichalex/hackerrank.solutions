using System;

namespace palindrome_index
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string word = Console.ReadLine();

                int length = word.Length;
                bool found = false;
                for (int j = 0; j < length; j++)
                {
                    if (word[j] != word[length - j - 1])
                    {
                        if (word[j + 1] == word[length - j - 1] 
                            && word[j + 2] == word[length - j - 2])
                        {
                            Console.WriteLine(j);
                        }
                        else
                        {
                            Console.WriteLine(length - j - 1);
                        }

                        found = true;
                        break;
                    }
                }

                if (!found)
                    Console.WriteLine(-1);
            }
        }
    }
}
