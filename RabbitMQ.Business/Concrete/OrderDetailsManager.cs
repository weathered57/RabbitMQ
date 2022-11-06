using RabbitMQ.Business.Abstract;
using RabbitMQ.Business.Constants;
using RabbitMQ.Business.Utilies.Results;
using RabbitMQ.DataAccess.Abstract;
using RabbitMQ.Entities;

namespace RabbitMQ.Business.Concrete
{
    public class OrderDetailsManager : IOrderDetailsService
    {
        private IOrderDetailsDal _orderDetailsDal;

        public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
        {
            _orderDetailsDal = orderDetailsDal;
        }


        public IDataResult<OrderDetails> Add(OrderDetails orderDetail)
        {
            _orderDetailsDal.Add(orderDetail);
            return new SuccessDataResult<OrderDetails>(orderDetail,Messages.OrderDetailAdded);
        }

        public IDataResult<OrderDetails> Delete(OrderDetails orderDetail)
        {
            _orderDetailsDal.Delete(orderDetail);
            return new SuccessDataResult<OrderDetails>(orderDetail, Messages.OrderDetailDeleted);
        }

        public IDataResult<OrderDetails> GetById(int orderDetailId)
        {
            return new SuccessDataResult<OrderDetails>(_orderDetailsDal.Get(c => c.Id == orderDetailId));
        }

        public IDataResult<List<OrderDetails>> GetList()
        {
            return new SuccessDataResult<List<OrderDetails>>(_orderDetailsDal.GetList().ToList());
        }

        public IDataResult<OrderDetails> Update(OrderDetails orderDetail)
        {
            _orderDetailsDal.Update(orderDetail);
            return new SuccessDataResult<OrderDetails>(orderDetail, Messages.OrderDetailUpdated);
        }
    }
}
