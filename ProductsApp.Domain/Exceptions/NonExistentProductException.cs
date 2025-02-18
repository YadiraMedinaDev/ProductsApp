namespace ProductsApp.Domain.Exceptions;
public class NonExistentProductException : BusinessException
{
    public NonExistentProductException(string message) : base(404, message)
    {
    }
}
