using RabbitMQ.Business.Utilies.Results;
using RabbitMQ.Entities;

namespace RabbitMQ.Business.Abstract
{
    public interface IOrderDetailsService
    {
        IDataResult<List<OrderDetails>> GetList();
        IDataResult<OrderDetails> GetById(int orderDetailId);
        IDataResult<OrderDetails> Add(OrderDetails orderDetail);
        IDataResult<OrderDetails> Update(OrderDetails orderDetail);
        IDataResult<OrderDetails> Delete(OrderDetails orderDetail);
    }
}
