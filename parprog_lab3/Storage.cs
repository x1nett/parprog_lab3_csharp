using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumerMulti
{
    public class Storage
    {
        private readonly int capacity;
        private readonly List<string> storage = new List<string>();

        private readonly Semaphore access = new Semaphore(1, 1);
        private readonly Semaphore full;
        private readonly Semaphore empty;

        public Storage(int capacity)
        {
            this.capacity = capacity;
            full = new Semaphore(capacity, capacity); 
            empty = new Semaphore(0, capacity);       
        }

        public void Add(string item, int producerId)
        {
            full.WaitOne();
            access.WaitOne();

            storage.Add(item);
            Console.WriteLine($"[Producer {producerId}] Produced: {item}");

            access.Release();
            empty.Release();
        }

        public string Remove(int consumerId)
        {
            empty.WaitOne();
            access.WaitOne();

            string item = null;
            if (storage.Count > 0)
            {
                item = storage[0];
                storage.RemoveAt(0);
                Console.WriteLine($"\t[Consumer {consumerId}] Consumed: {item}");
            }

            access.Release();
            full.Release();

            return item;
        }
    }
}
