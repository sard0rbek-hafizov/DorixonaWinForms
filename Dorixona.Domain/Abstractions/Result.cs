namespace Dorixona.Domain.Abstractions;
public sealed class Result<T>
{
    public T? Value { get; }
    public Error? Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    private Result(T? value, Error? error, bool isSuccess)
    {
        Value = value;
        Error = error;
        IsSuccess = isSuccess;
    }

    public static Result<T> Success(T value) =>
        new Result<T>(value, null, true);

    public static Result<T> Failure(Error error) =>
        new Result<T>(default, error, false);
}
public sealed class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; }

    private Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() =>
        new Result(true, null);

    public static Result Failure(Error error) =>
        new Result(false, error);
    public static Result<T> Failure<T>(Error error) =>
        Result<T>.Failure(error);
}