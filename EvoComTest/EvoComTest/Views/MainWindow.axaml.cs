using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels;

namespace EvoComTest.Views;

public partial class MainWindowView : Window
{
    public MainWindowView(MainViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
    public MainWindowView()
    {
        InitializeComponent();
        
        DataContext = Ioc.Default.GetService<MainViewModel>();
    }
    

}