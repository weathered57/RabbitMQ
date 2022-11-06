using RabbitMQ.Business.Abstract;
using RabbitMQ.Business.Constants;
using RabbitMQ.Business.Utilies.Results;
using RabbitMQ.DataAccess.Abstract;
using RabbitMQ.Entities;

namespace RabbitMQ.Business.Concrete
{
    public class OrderItemsManager : IOrderItemsService
    {
        private IOrderItemsDal _orderItemsDal;

        public OrderItemsManager(IOrderItemsDal orderItemsDal)
        {
            _orderItemsDal = orderItemsDal;
        }
        public IResult Add(OrderItems orderItem)
        {
            _orderItemsDal.Add(orderItem);
            return new SuccessResult(Messages.OrderItemAdded);
        }

        public IResult Delete(OrderItems orderItem)
        {
            _orderItemsDal.Delete(orderItem);
            return new SuccessResult(Messages.OrderItemDeleted);
        }

        public IDataResult<OrderItems> GetById(int orderItemId)
        {
            return new SuccessDataResult<OrderItems>(_orderItemsDal.Get(c => c.Id == orderItemId));
        }

        public IDataResult<List<OrderItems>> GetList()
        {
            return new SuccessDataResult<List<OrderItems>>(_orderItemsDal.GetList().ToList());
        }

        public IResult Update(OrderItems orderItem)
        {
            _orderItemsDal.Update(orderItem);
            return new SuccessResult(Messages.OrderItemUpdated);
        }
    }
}
