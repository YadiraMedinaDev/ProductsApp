namespace ProductsApp.Domain.Exceptions;
public class RequiredFieldException : BusinessException
{
    public RequiredFieldException(string mensaje) : base(400, mensaje)
    {
    }
}