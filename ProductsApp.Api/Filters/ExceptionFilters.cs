using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductsApp.Domain.Exceptions;

namespace ProductsApp.Api.Filters;

public class ExceptionFilters: IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string mesagge = "Internal error";
        int status = StatusCodes.Status500InternalServerError;
        if (context.Exception is BusinessException exception)
        {
            mesagge = exception.Message;
            status = exception.State;
        }

        var validation = new
        {
            Mensaje = mesagge
        };

        context.Result = new BadRequestObjectResult(validation)
        {
            StatusCode = status
        };
        context.ExceptionHandled = true;
    }
}
