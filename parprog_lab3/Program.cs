using System;
using System.Threading;

namespace ProducerConsumerMulti
{
    class Program
    {
        static void Main(string[] args)
        {
            int storageSize = 5;
            int[] producerItems = { 5, 3, 4 }; 
            int[] consumerItems = { 6, 6 };    

            Storage storage = new Storage(storageSize);

           
            for (int i = 0; i < producerItems.Length; i++)
            {
                int id = i;
                int items = producerItems[i];
                Producer producer = new Producer(id, items, storage);
                new Thread(producer.Run).Start();
            }

            for (int i = 0; i < consumerItems.Length; i++)
            {
                int id = i;
                int items = consumerItems[i];
                Consumer consumer = new Consumer(id, items, storage);
                new Thread(consumer.Run).Start();
            }

            Console.ReadKey();
        }
    }
}
