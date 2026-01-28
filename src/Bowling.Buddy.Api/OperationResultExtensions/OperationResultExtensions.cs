using Bowling.Buddy.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bowling.Buddy.Api.OperationResultExtensions;

public static class OperationResultExtensions
{
    public static IActionResult ToActionResult<TModel>(this OperationResult<TModel> result, ControllerBase controller)
    {
        var statusCode = result.ResultType switch
        {
            OperationResultType.Ok => 200,
            OperationResultType.BadRequest => 400,
            OperationResultType.NotFound => 404,
            OperationResultType.ServerError => 500,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        if (!result.IsSuccess)
        {
            return controller.Problem(
                detail:result.Exception?.Message,
                statusCode: statusCode,
                title: result.Exception?.Message
            );
        }
        
        return controller.StatusCode(statusCode, result.Model);
    }
}