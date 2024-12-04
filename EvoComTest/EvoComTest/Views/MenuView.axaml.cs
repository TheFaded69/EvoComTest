using Avalonia.Controls;
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