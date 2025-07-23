namespace Dorixona.Domain.Abstractions;
public class SingletonPattern
{
    private static SingletonPattern instance;
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Code { get; set; }
    public DateTime CreateTime { get; set; }
    private SingletonPattern() { }
    public static SingletonPattern Instance
    {
        get
        {
            if (instance == null)
                instance = new SingletonPattern();
            return instance;
        }
    }
}
