using System;

namespace heaps_finding_the_running_median
{
    class Heap
    {
        private readonly int[] arr;
        private int size;
        private readonly Func<int, int, bool> compare;

        public Heap(int n, bool maxFirst)
        {
            arr = new int[n];
            size = 0;

            if (maxFirst)
                compare = (a, b) => a > b;
            else
                compare = (a, b) => a < b;
        }

        public void Insert(int i)
        {
            arr[size] = i;
            size++;

            fixHeapOnInsert(size - 1);
        }

        private void fixHeapOnInsert(int inserted)
        {
            int parent = (inserted + 1) / 2 - 1;
            while (inserted > 0 && compare(arr[inserted], arr[parent]))
            {
                swap(inserted, parent);
                fixHeapOnInsert(parent);
            }
        }

        public int Extract()
        {
            int temp = Peek();
            arr[0] = arr[size - 1];
            size--;
            fixHeapOnExtract(0);
            return temp;
        }

        private void fixHeapOnExtract(int newParent)
        {
            if (hasLeft(newParent))
            {
                int small = left(newParent);
                if (hasRight(newParent) && compare(arr[right(newParent)], arr[small]))
                {
                    small = right(newParent);
                }

                if (compare(arr[newParent], arr[small]))
                    return;

                swap(newParent, small);
                fixHeapOnExtract(small);
            }
        }

        public int Peek()
        {
            return arr[0];
        }

        public int Count()
        {
            return size;
        }

        private int left(int parent)
        {
            return parent * 2 + 1;
        }

        private int right(int parent)
        {
            return parent * 2 + 2;
        }

        private bool hasLeft(int parent)
        {
            return left(parent) < size;
        }

        private bool hasRight(int parent)
        {
            return right(parent) < size;
        }

        private void swap(int indexA, int indexB)
        {
            int temp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = temp;
        }
    }

    
    class Program
    {
        private static Heap lower;
        private static Heap higher;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            lower = new Heap(n, true);
            higher = new Heap(n, false);

            for (int i = 0; i < n; i++)
            {
                int val = int.Parse(Console.ReadLine());
                insert(val);
                Console.WriteLine(median().ToString("0.0"));
            }
        }

        private static double median()
        {
            int lowerCount = lower.Count();
            int higherCount = higher.Count();
            if ((lowerCount + higherCount) % 2 == 0)
                return (double)(lower.Peek() + higher.Peek()) / 2;

            return lowerCount > higherCount ? lower.Peek() : higher.Peek();
        }

        private static void insert(int value)
        {
            if (lower.Count() == 0)
            {
                lower.Insert(value);
            }
            else
            {
                if (value < lower.Peek())
                {
                    lower.Insert(value);
                    if (lower.Count() > higher.Count() + 1)
                    {
                        higher.Insert(lower.Extract());
                    }
                }
                else
                {
                    higher.Insert(value);
                    if (higher.Count() > lower.Count() + 1)
                    {
                        lower.Insert(higher.Extract());
                    }
                }
            }
        }
    }
}
