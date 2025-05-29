using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumerArray
{
    public class Storage
    {
        private readonly int capacity;
        private readonly List<string> buffer;
        private readonly Semaphore access;
        private readonly Semaphore full;
        private readonly Semaphore empty;

        public Storage(int capacity)
        {
            this.capacity = capacity;
            buffer = new List<string>();
            access = new Semaphore(1, 1);
            full = new Semaphore(capacity, capacity);
            empty = new Semaphore(0, capacity);
        }

        public void Add(string item, int producerId)
        {
            full.WaitOne();
            access.WaitOne();

            buffer.Add(item);
            Console.WriteLine($"[Producer {producerId}] Produced: {item}");

            access.Release();
            empty.Release();
        }

        public string Take(int consumerId)
        {
            empty.WaitOne();
            access.WaitOne();

            string item = buffer[0];
            buffer.RemoveAt(0);
            Console.WriteLine($"\t[Consumer {consumerId}] Consumed: {item}");

            access.Release();
            full.Release();

            return item;
        }
    }
}
