using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels;
using EvoComTest.Views;

namespace EvoComTest;

public partial class App : Application
{
    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public new static App Current => (App)Application.Current;



    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var locator = new ViewLocator();
        DataTemplates.Add(locator);
        
        var serviceProvider = DependencyContainer.BuildServiceProvider();
        Ioc.Default.ConfigureServices(serviceProvider);
        
        var vm = Ioc.Default.GetRequiredService<MainViewModel>();
        
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindowView(vm);
                break;
            case ISingleViewApplicationLifetime singleViewPlatform:
                singleViewPlatform.MainView = new MainView(){DataContext = vm};
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
    
}