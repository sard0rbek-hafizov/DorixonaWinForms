using Microsoft.Extensions.Configuration;

namespace Dorixona.Infrastructure.FileStorage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly string _rootPath;

    public LocalFileStorageService(IConfiguration configuration)
    {
        _rootPath = configuration["LocalFileStorage:RootPath"]
                    ?? throw new InvalidOperationException("Local file storage root path is not configured.");

        if (!Directory.Exists(_rootPath))
        {
            Directory.CreateDirectory(_rootPath);
        }
    }

    public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType, CancellationToken cancellationToken = default)
    {
        var filePath = Path.Combine(_rootPath, fileName);

        using (var fileStreamOutput = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await fileStream.CopyToAsync(fileStreamOutput, cancellationToken);
        }

        return filePath;
    }

    public async Task<Stream?> DownloadAsync(string filePath, CancellationToken cancellationToken = default)
    {
        var fullPath = Path.Combine(_rootPath, filePath);

        if (File.Exists(fullPath))
        {
            var memoryStream = new MemoryStream(await File.ReadAllBytesAsync(fullPath, cancellationToken));
            memoryStream.Position = 0;
            return memoryStream;
        }

        return null;
    }

    public Task<bool> DeleteAsync(string filePath, CancellationToken cancellationToken = default)
    {
        var fullPath = Path.Combine(_rootPath, filePath);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}