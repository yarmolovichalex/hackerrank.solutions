using System;
using System.Collections.Generic;

namespace queues_a_tale_of_two_stacks
{
    class Queue
    {
        private readonly Stack<int> enqueue;
        private readonly Stack<int> dequeue;

        public Queue()
        {
            enqueue = new Stack<int>();
            dequeue = new Stack<int>();
        }

        public void Enqueue(int val)
        {
            enqueue.Push(val);
        }

        public void Dequeue()
        {
            populateDequeue();
            dequeue.Pop();
        }

        public int Head()
        {
            populateDequeue();
            return dequeue.Peek();
        }

        private void populateDequeue()
        {
            if (dequeue.Count == 0)
            {
                while (enqueue.Count != 0)
                {
                    dequeue.Push(enqueue.Pop());
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var query = Console.ReadLine();
                if (query.StartsWith("1"))
                {
                    int val = int.Parse(query.Split(' ')[1]);
                    queue.Enqueue(val);
                }
                else if (query.StartsWith("2"))
                {
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine(queue.Head());
                }
            }
        }
    }
}
