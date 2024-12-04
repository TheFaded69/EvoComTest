using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels;

namespace EvoComTest.Views;

public partial class CartView : UserControl
{
    public CartView()
    {
        InitializeComponent();
        
        DataContext = Ioc.Default.GetService<CartViewModel>();

    }
}