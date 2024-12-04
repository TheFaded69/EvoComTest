using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using ShopViewModel = EvoComTest.ViewModels.ShopViewModel;

namespace EvoComTest.Views;

public partial class ShopView : UserControl
{
    public ShopView()
    {
        InitializeComponent();
        
        DataContext = Ioc.Default.GetService<ShopViewModel>();

    }
}