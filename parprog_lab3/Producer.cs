using System;
using System.Threading;

namespace ProducerConsumerArray
{
    public class Producer
    {
        private readonly int id;
        private readonly string[] items;
        private readonly Storage storage;

        public Producer(int id, string[] items, Storage storage)
        {
            this.id = id;
            this.items = items;
            this.storage = storage;
        }

        public void Run()
        {
            foreach (string item in items)
            {
                storage.Add(item, id);
                Thread.Sleep(200);
            }
        }
    }
}
