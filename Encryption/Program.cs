using System;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string withoutSpaces = s.Replace(" ", "");
            int length = withoutSpaces.Length;

            int rows = (int) Math.Ceiling(Math.Sqrt(length));
            int cols = (int) Math.Ceiling((double) length/rows);
            if (rows > cols)
            {
                int temp = rows;
                rows = cols;
                cols = temp;
            }

            string[] strings = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                int toTake = (i + 1) * cols > length ? length - i*cols : cols;
                strings[i] = withoutSpaces.Substring(i*cols, toTake);
            }

            int lastRowLength = strings[rows - 1].Length;
            for (int i = 0; i < lastRowLength; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(strings[j][i]);
                }

                Console.Write(" ");
            }

            for (int i = lastRowLength; i < cols; i++)
            {
                for (int j = 0; j < rows - 1; j++)
                {
                    Console.Write(strings[j][i]);
                }

                Console.Write(" ");
            }

            Console.Read();
        }
    }
}
