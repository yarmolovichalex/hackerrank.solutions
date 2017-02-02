using System;
using System.Numerics;

namespace bonetrousle
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            for (int query = 0; query < count; query++)
            {
                BigInteger[] trip = Array.ConvertAll(Console.ReadLine().Split(' '), BigInteger.Parse);
                BigInteger n = trip[0];
                BigInteger k = trip[1];
                BigInteger b = trip[2];

                BigInteger[] result = new BigInteger[(ulong)b];
                for (ulong i = 0; i < b; i++)
                {
                    result[i] = i + 1;
                }

                BigInteger leastSum = 0;
                foreach (var r in result)
                {
                    leastSum += r;
                }

                if (leastSum > n)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    BigInteger diff = (n - leastSum) / b;
                    BigInteger rest = (n - leastSum) % b;
                    if (rest > 0)
                        diff++;

                    for (ulong i = 0; i < b; i++)
                    {
                        result[i] = result[i] + diff;
                    }

                    if (result[(ulong)b - 1] > k)
                    {
                        Console.WriteLine(-1);
                    }
                    else
                    {
                        BigInteger decreaseBy = diff * b - (n - leastSum);
                        for (int i = 0; i < decreaseBy; i++)
                        {
                            result[i]--;
                        }
                        
                        Console.WriteLine(string.Join(" ", result));
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
