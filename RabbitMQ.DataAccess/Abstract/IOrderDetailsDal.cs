using RabbitMQ.DataAccess.Concrete.EntityFramework;
using RabbitMQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.DataAccess.Abstract
{
    public interface IOrderDetailsDal : IEntityRepository<OrderDetails>
    {
    }
}
