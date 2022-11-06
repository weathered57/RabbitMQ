using System.Linq.Expressions;

namespace RabbitMQ.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
