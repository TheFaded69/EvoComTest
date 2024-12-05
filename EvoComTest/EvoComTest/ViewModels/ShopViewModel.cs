using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EvoComTest.Models.AppService;
using EvoComTest.Models.HttpService;
using EvoComTest.Models.HttpService.DTO;
using EvoComTest.Models.ImageLoader;
using EvoComTest.ViewModels.Items;

namespace EvoComTest.ViewModels;

public partial class ShopViewModel : ViewModelBase

{
    private readonly IShopService _shopService;
    private readonly ICartService _cartService;

    public ShopViewModel(IShopService shopService, ICartService cartService)
    {
        _shopService = shopService;
        _cartService = cartService;
        
        Task.Run(async () =>
        {
            var dto =  await shopService.GetShopItemsAsync();
            foreach (var shopItemDto in dto)
            {
                //todo добавить маппинг
                
                ShopItems.Add(new ShopItemViewModel
                {
                    Image = ImageLoader.LoadFromWeb(shopItemDto.UriImage),
                    Count = shopItemDto.Count,
                    Label = shopItemDto.Label,
                    Price = shopItemDto.Price,
                    IsAddedToCart = false
                });
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
    private void AddItemToCart(ShopItemViewModel shopItemViewModel)
    {
        _cartService.AddCartItemFromShop(new ShopItemDTO
        {
            Count = shopItemViewModel.Count,
            Label = shopItemViewModel.Label,
            Price = shopItemViewModel.Price
        });

        shopItemViewModel.IsAddedToCart = true;
    }

    [RelayCommand]
    private void RemoveItemFromCart(ShopItemViewModel shopItemViewModel)
    {
        _cartService.RemoveCartItemFromShop(new ShopItemDTO()
        {
            Count = shopItemViewModel.Count,
            Label = shopItemViewModel.Label,
            Price = shopItemViewModel.Price
        });
        
        shopItemViewModel.IsAddedToCart = false;

    }
}