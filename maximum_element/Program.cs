using System;
using System.Collections.Generic;

namespace maximum_element
{
    class Program
    {
        static void Main(string[] args)
        {
            var main = new Stack<int>();
            var max = new Stack<int>();

            int count = Convert.ToInt32(Console.ReadLine());
            for (int q = 0; q < count; q++)
            {
                int[] query = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int type = query[0];
                if (type == 1)
                {
                    int val = query[1];
                    main.Push(val);

                    if (max.Count == 0 || (max.Count > 0 && max.Peek() <= val))
                        max.Push(val);
                }
                else if (type == 2)
                {
                    int removed = main.Pop();
                    if (max.Peek() == removed)
                    {
                        max.Pop();
                    }
                }
                else
                {
                    Console.WriteLine(max.Peek());
                }
            }
        }
    }
}
