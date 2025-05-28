using System;
using System.Threading;

namespace ProducerConsumerMulti
{
    public class Producer
    {
        private readonly int id;
        private readonly int itemCount;
        private readonly Storage storage;

        public Producer(int id, int itemCount, Storage storage)
        {
            this.id = id;
            this.itemCount = itemCount;
            this.storage = storage;
        }

        public void Run()
        {
            for (int i = 0; i < itemCount; i++)
            {
                string item = $"Item_P{id}_{i}";
                storage.Add(item, id);
                Thread.Sleep(200); 
            }
        }
    }
}
