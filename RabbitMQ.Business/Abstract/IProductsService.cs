using RabbitMQ.Business.Utilies.Results;
using RabbitMQ.Entities;

namespace RabbitMQ.Business.Abstract
{
    public interface IProductsService
    {
        IDataResult<List<Products>> GetList();
        IDataResult<Products> GetById(int productId);
        IResult Add(Products product);
        IResult Update(Products product);
        IResult Delete(Products product);
    }
}
