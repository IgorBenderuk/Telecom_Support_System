using Microsoft.AspNetCore.Mvc;
using TelecomSupportSystem.Domain.Common;

namespace TelecomSupportSystem.API.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult(this Result result)
        {
            if ( result.IsSuccess )
                return new OkResult();

            return result.ErrorType switch
            {
                ErrorType.NotFound => new NotFoundObjectResult(result.Error),
                ErrorType.Forbidden => new ObjectResult(result.Error) { StatusCode = StatusCodes.Status403Forbidden },
                ErrorType.Validation => new BadRequestObjectResult(result.Error),
                ErrorType.Failure => new ObjectResult(result.Error) { StatusCode = StatusCodes.Status500InternalServerError },
                _ => new ObjectResult(result.Error) { StatusCode = StatusCodes.Status500InternalServerError }
            };
        }

        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            if ( result.IsSuccess )
                return new OkObjectResult(result.Value);

            return result.ErrorType switch
            {
                ErrorType.NotFound => new NotFoundObjectResult(result.Error),
                ErrorType.Forbidden => new ObjectResult(result.Error) { StatusCode = StatusCodes.Status403Forbidden },
                ErrorType.Validation => new BadRequestObjectResult(result.Error),
                ErrorType.Failure => new ObjectResult(result.Error) { StatusCode = StatusCodes.Status500InternalServerError },
                _ => new ObjectResult(result.Error) { StatusCode = StatusCodes.Status500InternalServerError }
            };
        }
    }
}

