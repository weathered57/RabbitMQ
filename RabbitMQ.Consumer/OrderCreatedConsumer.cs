using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Entities.RabbitMQ;

namespace RabbitMQ.Consumer
{
    public class OrderCreatedConsumer : IConsumer<OrderDetail>
    {
        public async Task Consume(ConsumeContext<OrderDetail> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"OrderCreated message: {jsonMessage}");
        }
    }
}
