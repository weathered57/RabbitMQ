

namespace RabbitMQ.Entities.RabbitMQ
{
    public class OrderDetail
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDatetime { get; set; }
        public OrderProducts Products { get; set; }
    }
}
