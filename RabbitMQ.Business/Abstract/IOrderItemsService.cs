using RabbitMQ.Business.Utilies.Results;
using RabbitMQ.Entities;

namespace RabbitMQ.Business.Abstract
{
    public interface IOrderItemsService
    {
        IDataResult<List<OrderItems>> GetList();
        IDataResult<OrderItems> GetById(int orderItemId);
        IResult Add(OrderItems orderItem);
        IResult Update(OrderItems orderItem);
        IResult Delete(OrderItems orderItem);
    }
}
