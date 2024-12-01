using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels;

namespace EvoComTest.Views;

public partial class MenuView : UserControl
{
    public MenuView()
    {
        InitializeComponent();
        
        DataContext =  Ioc.Default.GetRequiredService<MenuViewModel>();
    }
}