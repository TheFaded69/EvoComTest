﻿using System;
using EvoComTest.Models.AppService;
using EvoComTest.Models.HttpService;
using EvoComTest.ViewModels;
using EvoComTest.ViewModels.ContentPage;
using EvoComTest.Views;
using Microsoft.Extensions.DependencyInjection;

namespace EvoComTest;

internal static class DependencyContainer
{
    internal static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        
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
        
        return services.BuildServiceProvider();
    }
}