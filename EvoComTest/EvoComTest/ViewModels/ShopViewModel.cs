using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EvoComTest.Models.HttpService;
using EvoComTest.Models.HttpService.DTO;
using EvoComTest.Models.ImageLoader;
using EvoComTest.ViewModels.Items;
using Newtonsoft.Json;

namespace EvoComTest.ViewModels.ContentPage;

public partial class ShopViewModel : ViewModelBase

{
    public ShopViewModel(IShopService shopService)
    {
        Task.Run(async () =>
        {
            var dto =  await shopService.GetShopItemsAsync();
            foreach (var shopItemDto in dto)
            {
                ShopItems.Add(new ShopItemViewModel(ImageLoader.LoadFromWeb(shopItemDto.UriImage), shopItemDto.Count, shopItemDto.Label, shopItemDto.Price));
            }
        });
    }

    /// <summary>
    /// for design
    /// </summary>
    public ShopViewModel()
    {
    }

    [ObservableProperty] private ObservableCollection<ShopItemViewModel> _shopItems = []; /*= new()
    {
        new ShopItemViewModel(ImageLoader.LoadFromWeb("https://loremflickr.com/200/200?random=1"), 20, "Яблоко", 450),
        new ShopItemViewModel(ImageLoader.LoadFromWeb("https://loremflickr.com/200/200?random=2"), 10, "TEst 2", 450),
        new ShopItemViewModel(ImageLoader.LoadFromWeb("https://loremflickr.com/200/200?random=3"), 30, "12412412", 450),
        new ShopItemViewModel(ImageLoader.LoadFromWeb("https://loremflickr.com/200/200?random=4"), 40, "qwerty", 450),
        new ShopItemViewModel(ImageLoader.LoadFromWeb("https://loremflickr.com/200/200?random=5"), 40, "qwerty", 450),
        new ShopItemViewModel(ImageLoader.LoadFromWeb("https://loremflickr.com/200/200?random=6"), 20, "Яблоко", 450),
    };*/

    [RelayCommand]
    private void AddItemToCart()
    {
    }

    [RelayCommand]
    private void RemoveItemFromCart()
    {
    }
}