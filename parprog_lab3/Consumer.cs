using System;
using System.Threading;

namespace ProducerConsumerArray
{
    public class Consumer
    {
        private readonly int id;
        private readonly string[] buffer;
        private readonly Storage storage;

        public Consumer(int id, int itemCount, Storage storage)
        {
            this.id = id;
            buffer = new string[itemCount];
            this.storage = storage;
        }

        public void Run()
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = storage.Take(id);
                Thread.Sleep(500);
            }
        }
    }
}
