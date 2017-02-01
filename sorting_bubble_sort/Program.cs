using System;

namespace sorting_bubble_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(a_temp, int.Parse);

            int totalNumberOfSwaps = bubbleSort(arr, n);

            Console.WriteLine($"Array is sorted in {totalNumberOfSwaps} swaps.");
            Console.WriteLine($"First Element: {arr[0]}");
            Console.WriteLine($"Last Element: {arr[n - 1]}");

        }

        static int bubbleSort(int[] arr, int n)
        {
            int totalNumberOfSwaps = 0;

            for (int i = 0; i < n; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(arr, j, j + 1);
                        totalNumberOfSwaps++;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }

            return totalNumberOfSwaps;
        }

        static void swap(int[] arr, int indexA, int indexB)
        {
            int temp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = temp;
        }
    }
}
