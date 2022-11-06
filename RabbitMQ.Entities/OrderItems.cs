namespace RabbitMQ.Entities
{
    public class OrderItems
    {
       public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}