using System.Text.RegularExpressions;

namespace Dorixona.Infrastructure.Common.Services;

public interface ISlugGenerator
{
    string GenerateSlug(string phrase);
}

public class SlugGenerator : ISlugGenerator
{
    public string GenerateSlug(string phrase)
    {
        if (string.IsNullOrWhiteSpace(phrase))
            return string.Empty;

        string str = phrase.ToLowerInvariant();
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");   // faqat lotin harflar, raqamlar, bo'sh joy va tire
        str = Regex.Replace(str, @"\s+", " ").Trim();    // ortiqcha bo'sh joylarni bitta qilib
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // maksimal 45 ta belgi
        str = Regex.Replace(str, @"\s", "-");            // bo'sh joylarni tirega almashtirish

        return str;
    }
}