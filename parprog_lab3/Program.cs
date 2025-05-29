using System;
using System.Threading;

namespace ProducerConsumerArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int storageSize = 5;

            string[][] producerData = {
                new string[] { "A1", "A2", "A3" },
                new string[] { "B1", "B2" },
                new string[] { "C1", "C2", "C3", "C4" }
            };

            int[] consumerNeeds = { 4, 5 }; 

            Storage storage = new Storage(storageSize);

    
            for (int i = 0; i < producerData.Length; i++)
            {
                Producer producer = new Producer(i, producerData[i], storage);
                Thread thread = new Thread(producer.Run);
                thread.Start();
            }

            // Стартуємо потоки споживачів
            for (int i = 0; i < consumerNeeds.Length; i++)
            {
                Consumer consumer = new Consumer(i, consumerNeeds[i], storage);
                Thread thread = new Thread(consumer.Run);
                thread.Start();
            }

            Console.ReadKey();
        }
    }
}
