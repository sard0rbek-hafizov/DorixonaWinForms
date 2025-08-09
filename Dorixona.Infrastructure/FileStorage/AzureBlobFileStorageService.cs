using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs.Models;


namespace Dorixona.Infrastructure.FileStorage;

public class AzureBlobFileStorageService : IFileStorageService
{
    private readonly BlobContainerClient _containerClient;

    public AzureBlobFileStorageService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AzureBlobStorage");
        var containerName = configuration["AzureBlob:ContainerName"];

        if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(containerName))
            throw new InvalidOperationException("Azure Blob Storage settings are missing.");

        _containerClient = new BlobContainerClient(connectionString, containerName);
        _containerClient.CreateIfNotExists(PublicAccessType.Blob);
    }

    public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType, CancellationToken cancellationToken = default)
    {
        var blobClient = _containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType }, cancellationToken: cancellationToken);
        return blobClient.Uri.ToString();
    }

    public async Task<Stream?> DownloadAsync(string filePath, CancellationToken cancellationToken = default)
    {
        var blobClient = _containerClient.GetBlobClient(filePath);
        if (await blobClient.ExistsAsync(cancellationToken))
        {
            var response = await blobClient.DownloadAsync(cancellationToken);
            return response.Value.Content;
        }
        return null;
    }

    public async Task<bool> DeleteAsync(string filePath, CancellationToken cancellationToken = default)
    {
        var blobClient = _containerClient.GetBlobClient(filePath);
        var response = await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
        return response.Value;
    }
}
