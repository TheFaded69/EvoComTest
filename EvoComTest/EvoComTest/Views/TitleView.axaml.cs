using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels;

namespace EvoComTest.Views;

public partial class TitleView : UserControl
{
    public TitleView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetService<TitleViewModel>();
    }
}