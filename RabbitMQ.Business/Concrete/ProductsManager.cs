using RabbitMQ.Business.Abstract;
using RabbitMQ.Business.Constants;
using RabbitMQ.Business.Utilies.Results;
using RabbitMQ.DataAccess.Abstract;
using RabbitMQ.Entities;

namespace RabbitMQ.Business.Concrete
{
    public class ProductsManager : IProductsService
    {
        private IProductsDal _productsDal;

        public ProductsManager(IProductsDal productsDal)
        {
            _productsDal = productsDal;
        }
        public IResult Add(Products product)
        {
            _productsDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Products product)
        {
            _productsDal.Add(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Products> GetById(int productId)
        {
            return new SuccessDataResult<Products>(_productsDal.Get(c => c.Id == productId));
        }

        public IDataResult<List<Products>> GetList()
        {
            return new SuccessDataResult<List<Products>>(_productsDal.GetList().ToList());
        }

        public IResult Update(Products product)
        {
            _productsDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
