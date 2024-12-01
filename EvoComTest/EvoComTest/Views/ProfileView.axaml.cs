using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels.ContentPage;

namespace EvoComTest.Views;

public partial class ProfileView : UserControl
{
    public ProfileView()
    {
        InitializeComponent();
        
        DataContext = Ioc.Default.GetService<ProfileViewModel>();
    }
}