using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using EvoComTest.ViewModels.Items;

namespace EvoComTest.ViewModels;

public partial class CartViewModel : ViewModelBase
{
    public CartViewModel()
    {
        
    }

    [ObservableProperty] private int _cartItemsCount;
    
    public ObservableCollection<CartItemViewModel> CartItemViewModels { get; } = [];
}