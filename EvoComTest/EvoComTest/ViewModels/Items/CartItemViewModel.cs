using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EvoComTest.ViewModels.Items;

public partial class CartItemViewModel : ViewModelBase
{
    public int Number { get; set; }
    public string Name { get; set; }

    [ObservableProperty]
    private int _maxCount;
    
    [ObservableProperty]
    private int _count;

    [ObservableProperty]
    private bool _canSellItem;

    partial void OnCountChanged(int value)
    {
        CanSellItem = Count <= MaxCount;
    }
}