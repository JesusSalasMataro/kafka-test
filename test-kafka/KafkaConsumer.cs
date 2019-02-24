using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace testkafka
{
    public class KafkaConsumer
    {
        private readonly int numberOfConsumers = 3;
        private readonly string topic = "test";

        public void Run()
        {
            Dictionary<string, object> configuration = CreateConsumersConfiguration();

            List<Task> runners = new List<Task>();
            List<Consumer> consumers = CreateConsumers(configuration);

            for (int i = 0; i < numberOfConsumers; i++)
            {
                int partition = i;
                runners.Add(Task.Run(() => RunConsumer(consumers[partition], partition)));
            }

            Task.WaitAll(runners.ToArray());
        }

        private Dictionary<string, object> CreateConsumersConfiguration()
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            config.Add("group.id", "test-consumer14");
            config.Add("bootstrap.servers", "localhost:9092");
            config.Add("auto.offset.reset", "earliest");
            config.Add("enable.auto.commit", false);
            return config;
        }

        private List<Consumer> CreateConsumers(Dictionary<string, object> configuration)
        {
            List<Consumer> consumers = new List<Consumer>();

            for (int i = 0; i < numberOfConsumers; i++)
            {
                consumers.Add(new Consumer(configuration));
                consumers[i].Subscribe(topic);
            }

            return consumers;
        }

        private void RunConsumer(Consumer consumer, int partition)
        {
            consumer.OnMessage += (_, message) =>
            {
                string key = "";
                string value = "";

                if (message.Key != null)
                {
                    key = Encoding.Default.GetString(message.Key);
                }

                if (message.Value != null)
                {
                    value = Encoding.Default.GetString(message.Value);
                }

                Console.WriteLine($@" 
                    Topic: {message.Topic}
                    Partition: {message.Partition}
                    Consumer: {partition}
                    Key: {key}
                    Value: {value}
                ");
            };

            while (true)
            {
                consumer.Poll(100);
            }
        }
    }
}
