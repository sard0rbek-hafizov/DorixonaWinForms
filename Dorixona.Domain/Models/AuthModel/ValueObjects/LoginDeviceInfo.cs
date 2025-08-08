namespace Dorixona.Domain.Models.AuthModel.ValueObjects;

public class LoginDeviceInfo
{
    public string Device { get; private set; }
    public string Os { get; private set; }
    public string Browser { get; private set; }

    private LoginDeviceInfo(string device, string os, string browser)
    {
        Device = device;
        Os = os;
        Browser = browser;
    }

    public static LoginDeviceInfo Create(string device, string os, string browser)
    {
        if (string.IsNullOrWhiteSpace(device) || string.IsNullOrWhiteSpace(os) || string.IsNullOrWhiteSpace(browser))
            throw new ArgumentException("Device, OS, and Browser info must be provided.");

        return new LoginDeviceInfo(device.Trim(), os.Trim(), browser.Trim());
    }

    public override string ToString() => $"{Device} - {Os} - {Browser}";
    public override bool Equals(object? obj) =>
        obj is LoginDeviceInfo other &&
        Device == other.Device && Os == other.Os && Browser == other.Browser;

    public override int GetHashCode() => HashCode.Combine(Device, Os, Browser);
}
