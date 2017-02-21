using System;

namespace find_the_median
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int median = NthSmallestElement(numbers, count/2);
            Console.WriteLine(median);
            Console.ReadLine();
        }

        static int NthSmallestElement(int[] array, int n)
        {
            if (array.Length == 1)
                return array[0];

            return QuickSelectSmallest(array, n)[n];
        }

        static int[] QuickSelectSmallest(int[] input, int n)
        {
            var partiallySortedArray = (int[])input.Clone();

            var startIndex = 0;
            var endIndex = input.Length - 1;

            var pivotIndex = n;

            var r = new Random();
            while (endIndex > startIndex)
            {
                pivotIndex = QuickSelectPartition(partiallySortedArray, startIndex, endIndex, pivotIndex);
                if (pivotIndex == n)
                    // We found our n:th smallest value - it is stored to pivot index
                    break;
                if (pivotIndex > n)
                    // Array before our pivot index have more elements that we are looking for                    
                    endIndex = pivotIndex - 1;
                else
                    // Array before our pivot index has less elements that we are looking for                    
                    startIndex = pivotIndex + 1;

                // Omnipotent beings don't need to roll dices - but we do...
                // Randomly select a new pivot index between end and start indexes (there are other methods, this is just most brutal and simplest)
                pivotIndex = r.Next(startIndex, endIndex);
            }
            return partiallySortedArray;
        }

        private static int QuickSelectPartition(int[] array, int startIndex, int endIndex, int pivotIndex)
        {
            var pivotValue = array[pivotIndex];
            // Initially we just assume that value in pivot index is largest - so we move it to end (makes also for loop more straight forward)
            Swap(array, pivotIndex, endIndex);
            for (var i = startIndex; i < endIndex; i++)
            {
                if (array[i].CompareTo(pivotValue) > 0)
                    continue;

                // Value stored to i was smaller than or equal with pivot value - let's move it to start
                Swap(array, i, startIndex);
                // Move start one index forward 
                startIndex++;
            }
            // Start index is now pointing to index where we should store our pivot value from end of array
            Swap(array, endIndex, startIndex);
            return startIndex;
        }

        static void Swap(int[] array, int index1, int index2)
        {
            if (index1 == index2)
                return;

            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
