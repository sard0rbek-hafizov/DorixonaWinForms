namespace Dorixona.Infrastructure.External.Sms;

public interface ISmsSender
{
    Task SendSmsAsync(string phoneNumber, string message);
}

public class SmsSender : ISmsSender
{
    private readonly SmsSettings _settings;
    private readonly HttpClient _httpClient;

    public SmsSender(SmsSettings settings, HttpClient httpClient)
    {
        _settings = settings;
        _httpClient = httpClient;
    }

    public async Task SendSmsAsync(string phoneNumber, string message)
    {
        var url = $"{_settings.ApiUrl}?apikey={_settings.ApiKey}&sender={_settings.SenderId}&to={phoneNumber}&message={message}";
        await _httpClient.GetAsync(url);
    }
}
