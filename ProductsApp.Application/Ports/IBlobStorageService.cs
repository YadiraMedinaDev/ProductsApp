namespace ProductsApp.Application.Ports;

public interface IBlobStorageService
{
    Task<string> UploadImageAsync(Stream imageStream, string fileName);
}
