namespace Dorixona.Domain.Abstractions;
public class Error
{
    public string Message { get; set; }
    public string Code { get; set; }
    public Error(string message, string code)
    {
        Message = message;
        Code = code;
    }
}
