using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;

namespace EvoComTest.Models.ImageLoader;

public class ImageLoader
{
    public static async Task<Bitmap?> LoadFromWeb(string resourcePath)
    {
        var uri = new Uri(resourcePath);
        using var httpClient = new HttpClient();
        try
        {
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Test", "1.0"));
            var data = await httpClient.GetByteArrayAsync(uri);
            return new Bitmap(new MemoryStream(data));
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred while downloading image '{uri}' : {ex.Message}");
            return null;
        }
    }
}