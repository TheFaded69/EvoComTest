using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EvoComTest.ViewModels.Items;

public partial class ShopItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private Task<Bitmap?> _image;
    
    [ObservableProperty]
    private int _count;
    
    [ObservableProperty]
    private string _label;
    
    [ObservableProperty]
    private decimal _price;
    
    [ObservableProperty]
    private bool _isAddedToCart;
    
}