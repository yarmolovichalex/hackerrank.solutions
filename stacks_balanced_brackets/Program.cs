using System;
using System.Collections.Generic;
using System.Linq;

namespace stacks_balanced_brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var brackets = new Dictionary<char, char>
            {
                {'(', ')'},
                {'[', ']'},
                {'{', '}'}
            };

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var stack = new Stack<char>();

                string input = Console.ReadLine();

                if (input.Length % 2 == 1)
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    bool isBalanced = true;

                    foreach (char c in input)
                    {
                        if (brackets.ContainsKey(c))
                        {
                            stack.Push(c);
                        }
                        else
                        {
                            if (!stack.Any()
                                || brackets[stack.Pop()] != c)
                            {
                                isBalanced = false;
                                break;
                            }
                        }
                    }

                    if (stack.Any())
                        isBalanced = false;

                    Console.WriteLine(isBalanced ? "YES" : "NO");
                }
            }
        }
    }
}
