using System;
using System.Linq;

namespace arrays_left_rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
            int count = parameters[0];
            int d = parameters[1];

            var data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
            
            for (int i = 0; i < count; i++)
            {
                Console.Write(data[(i + d) % count] + " ");
            }
        }
    }
}