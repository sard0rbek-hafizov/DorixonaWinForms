﻿namespace Dorixona.Infrastructure.FileStorage;

public interface IFileStorageService
{
    Task<string> UploadAsync(Stream fileStream, string fileName, string contentType, CancellationToken cancellationToken = default);
    Task<Stream?> DownloadAsync(string filePath, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string filePath, CancellationToken cancellationToken = default);
}