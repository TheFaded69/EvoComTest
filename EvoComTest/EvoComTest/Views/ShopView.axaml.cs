using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels.ContentPage;

namespace EvoComTest.Views;

public partial class ShopView : UserControl
{
    public ShopView()
    {
        InitializeComponent();
        
        DataContext = Ioc.Default.GetService<ShopViewModel>();

    }
}