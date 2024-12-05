using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using EvoComTest.Models.HttpService.DTO;
using Newtonsoft.Json;

namespace EvoComTest.Models.HttpService;

public class ShopService : IShopService
{
    public ShopService()
    {
        
    }
    public async Task<ObservableCollection<ShopItemDTO>> GetShopItemsAsync()
    {
        using var httpClient = new HttpClient();
        try
        {
            //todo получение данных из testResponse.json с сервера (сделать удаленный эндпоинт), а не локального. Работает если создать GET запрос в Mockoon
            var data = await httpClient.GetAsync("http://localhost:3000/shop/all");
            data.EnsureSuccessStatusCode();

            var str = await data.Content.ReadAsStringAsync();

            
            return JsonConvert.DeserializeObject<ObservableCollection<ShopItemDTO>>(str);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Ошибка при запросе: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при запросе: {ex.Message}");
            return null;
        }
    }
}