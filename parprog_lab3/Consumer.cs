using System;
using System.Threading;

namespace ProducerConsumerMulti
{
    public class Consumer
    {
        private readonly int id;
        private readonly int itemCount;
        private readonly Storage storage;

        public Consumer(int id, int itemCount, Storage storage)
        {
            this.id = id;
            this.itemCount = itemCount;
            this.storage = storage;
        }

        public void Run()
        {
            for (int i = 0; i < itemCount; i++)
            {
                storage.Remove(id);
                Thread.Sleep(500); 
            }
        }
    }
}
