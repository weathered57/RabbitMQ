namespace RabbitMQ.Business.Utilies.Results
{
    public interface IResult
    {
        bool Success { get; }

        string Message { get; }
    }
}

