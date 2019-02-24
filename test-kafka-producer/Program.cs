using testkafkaproducer;

namespace test_kafka_producer
{
    class Program
    {
        static void Main(string[] args)
        {
            KafkaProducer producer = new KafkaProducer();
            producer.Run();
        }

    }
}
