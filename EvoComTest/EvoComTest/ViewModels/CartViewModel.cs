using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using EvoComTest.Models.AppService;
using EvoComTest.Models.HttpService.DTO;
using EvoComTest.ViewModels.Items;
using EvoComTest.Views;

namespace EvoComTest.ViewModels;

public partial class CartViewModel : ViewModelBase, ICartObserver
{
    public CartViewModel(ICartService cartService)
    {
        _cartService = cartService;

        cartService.AddObserver(this);
        cartService.Update();
    }

    /// <summary>
    /// For design only
    /// </summary>
    public CartViewModel(): this(DesignData.CartService)
    {
        
    }

    private readonly ICartService _cartService;

    [ObservableProperty] private int _cartItemsCount;

    public ObservableCollection<CartItemViewModel> CartItemViewModels { get; } = [];

    public void Update(List<CartItemDTO> cartItemDto)
    {
        CartItemViewModels.Clear();
        
        cartItemDto.ForEach(dto => CartItemViewModels.Add(new CartItemViewModel
        {
            Count = dto.Count,
            MaxCount = dto.Count,
            CanSellItem = true,
            Number = CartItemViewModels.Count + 1,
            Name = dto.Label
        }));

        CartItemsCount = cartItemDto.Count;
    }
}