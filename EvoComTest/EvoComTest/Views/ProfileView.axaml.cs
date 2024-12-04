using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels;

namespace EvoComTest.Views;

public partial class ProfileView : UserControl
{
    public ProfileView()
    {
        InitializeComponent();
        
        DataContext = Ioc.Default.GetService<ProfileViewModel>();
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        
    }
}