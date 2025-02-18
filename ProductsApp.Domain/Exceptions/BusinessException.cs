namespace ProductsApp.Domain.Exceptions;
public class BusinessException : Exception
{
    public int State { get; set; }
    public BusinessException(int state, string message) : base(message)
    {
        State = state;
    }
}
