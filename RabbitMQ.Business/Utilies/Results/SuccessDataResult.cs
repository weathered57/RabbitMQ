namespace RabbitMQ.Business.Utilies.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(string message) : base(default, false, message)
        {

        }
        public SuccessDataResult() : base(default, false)
        {

        }
    }
}
