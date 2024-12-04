using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EvoComTest.Models.HttpService.DTO;

namespace EvoComTest.Models.HttpService;

public interface IShopService
{
    Task<ObservableCollection<ShopItemDTO>> GetShopItemsAsync();
}