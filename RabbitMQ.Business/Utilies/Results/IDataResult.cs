namespace RabbitMQ.Business.Utilies.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
