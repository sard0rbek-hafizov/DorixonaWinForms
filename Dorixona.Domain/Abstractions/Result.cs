namespace Dorixona.Domain.Abstractions;
public class Result<T>
{
    public T? Value { get; }
    public Error Error { get; }
    public bool IsSucces { get; }
    public bool IsFailure => !IsSucces;
    public static Result<T> Succes(T value) => new Result<T>(value, null, true);
    public static Result<T> Failure(Error error) => new Result<T>(default, null, false);

    public Result(T? value, Error? error, bool isSuccess)
    {
        Value = value;
        Error = error;
        IsSucces = isSuccess;
    }

}
