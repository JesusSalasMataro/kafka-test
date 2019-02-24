using testkafka;

namespace test_kafka
{
    class Program
    {
        static void Main(string[] args)
        {
            KafkaConsumer consumer = new KafkaConsumer();
            consumer.Run();
        }
    }
}
