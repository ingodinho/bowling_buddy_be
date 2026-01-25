namespace Bowling.Buddy.Application.Models;

public class OperationResult<T>
{
    public OperationResultType ResultType { get; }
    public T Model { get; }
    public Exception? Exception { get; }
    public bool IsSuccess => Exception is null;


    private OperationResult(T model, OperationResultType resultType)
    {
        Model = model;
        ResultType = resultType;
        Exception = null;
    }

    private OperationResult(Exception exception, OperationResultType resultType = OperationResultType.BadRequest)
    {
        Exception = exception;
        ResultType = resultType ;
        Model = default!;
    }

    private OperationResult(OperationResultType resultType = OperationResultType.BadRequest)
    {
        ResultType = resultType;
        Exception = null;
        Model = default!;
    }
    
    public static OperationResult<T> Success(T model) => new(model, OperationResultType.Ok);
    
    public static OperationResult<T> Success(T model, OperationResultType resultType) => new(model, resultType);
    
    public static OperationResult<T> BadRequest(string reason) => new(new Exception(reason), OperationResultType.BadRequest);
    
    public static OperationResult<T> NotFound() => new(OperationResultType.NotFound);

    public static OperationResult<T> Failure(Exception exception, OperationResultType resultType) => new(exception, resultType);
}