using System;
using EvoComTest.Models.AppService;
using EvoComTest.Models.HttpService;
using EvoComTest.ViewModels;
using EvoComTest.Views;
using Microsoft.Extensions.DependencyInjection;
using ShopViewModel = EvoComTest.ViewModels.ShopViewModel;

namespace EvoComTest;

internal static class DependencyContainer
{
    internal static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        
        //todo все синглтон т.к. удобно хранить состояние вм постоянными как и вью. Можно переделать т.к. данные о корзине хранятся в моделе
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindowView>();
        
        
        services.AddSingleton<TitleViewModel>();
        services.AddSingleton<TitleView>();

        services.AddSingleton<MenuViewModel>();
        services.AddSingleton<MenuView>();

        services.AddSingleton<ShopView>();
        services.AddSingleton<ShopViewModel>();
        
        services.AddSingleton<CartView>();
        services.AddSingleton<CartViewModel>();
        
        services.AddSingleton<ProfileView>();
        services.AddSingleton<ProfileViewModel>();

        services.AddSingleton<IPageMediator, PageMediator>();
        services.AddSingleton<IShopService, ShopService>();
        services.AddSingleton<ICartService, CartService>();
        
        return services.BuildServiceProvider();
    }
}