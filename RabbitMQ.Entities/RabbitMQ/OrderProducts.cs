namespace RabbitMQ.Entities.RabbitMQ
{
    public class OrderProducts
    {
        public OrderProducts()
        {
            Product = new List<Products>();
        }
        public int Quantity { get; set; }
        public List<Products> Product { get; set; }
    }
}
