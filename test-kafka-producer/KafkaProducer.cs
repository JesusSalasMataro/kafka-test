using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;

namespace testkafkaproducer
{
    public class KafkaProducer
    {
        public void Run()
        {
            Dictionary<string, object> configuration = CreateProducerConfiguration();
            Producer producer = new Producer(configuration);
            string message = string.Empty;

            while (message != "quit")
            {
                Console.WriteLine("Introduce un mensaje: ");
                message = Console.ReadLine();
                producer.ProduceAsync(
                    topic: "test",
                    key: Encoding.ASCII.GetBytes("key-test"),
                    val: Encoding.ASCII.GetBytes(message)
                );
            }

            producer.Flush(millisecondsTimeout: 5000);
        }

        private static Dictionary<string, object> CreateProducerConfiguration()
        {
            Dictionary<string, object> configuration = new Dictionary<string, object>();
            configuration.Add("bootstrap.servers", "localhost:9092");
            return configuration;
        }
    }
}
