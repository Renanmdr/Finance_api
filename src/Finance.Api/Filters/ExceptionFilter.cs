using Finance.Communication.Responses;
using Finance.Exception;
using Finance.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Finance.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FinanceException)
        {
            HandleProjectException(context);
        }
        else 
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context) {
        var financeException = (FinanceException)context.Exception;

        var response = new ResponseErrorJson(financeException.GetErrors());

        context.HttpContext.Response.StatusCode = financeException.StatusCode;
        context.Result = new ObjectResult(response);

        /*
        if (context.Exception is ErrorOnValidationException errorOnValidationException)
        {
            var response = new ResponseErrorJson(errorOnValidationException.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(response);

        }else if(context.Exception is NotFoundException notFoundException)
        {
            var response = new ResponseErrorJson(notFoundException.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Result = new NotFoundObjectResult(response);
        }
        else
        {
            var response = new ResponseErrorJson(context.Exception.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(response);
        }*/

    }
    private void ThrowUnknowError(ExceptionContext context) {

        var response = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(response);
        
    }
}
