using RawRabbit.Configuration;

namespace MedPark.Common.RabbitMq
{
    public class RabbitMqOptions : RawRabbitConfiguration
    {
        public string Namespace { get; set; }
        public int Retries { get; set; }
        public int RetryInterval { get; set; }
    }
}