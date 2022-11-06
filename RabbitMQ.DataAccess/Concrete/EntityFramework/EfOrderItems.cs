using RabbitMQ.DataAccess.Abstract;
using RabbitMQ.DataAccess.Concrete.EntityFramework.Context;
using RabbitMQ.Entities;

namespace RabbitMQ.DataAccess.Concrete.EntityFramework
{
    public class EfOrderItems : EfEntityRepositoryBase<OrderItems, RabbitMqShopContext>, IOrderItemsDal
    {
        public EfOrderItems()
        {
        }
    }
}
