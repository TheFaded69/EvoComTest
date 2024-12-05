using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using EvoComTest.ViewModels;
using EvoComTest.Views;
using ShopViewModel = EvoComTest.ViewModels.ShopViewModel;

namespace EvoComTest;

public class ViewLocator : IDataTemplate
{
    private readonly Dictionary<Type, Func<Control?>> _locator = new();

    public ViewLocator()
    {
        RegisterViewFactory<MainViewModel, MainWindowView>();
        RegisterViewFactory<MenuViewModel, MenuView>();
        RegisterViewFactory<TitleViewModel, TitleView>();
        RegisterViewFactory<CartViewModel, CartView>();
        RegisterViewFactory<ShopViewModel, ShopView>();
        RegisterViewFactory<ProfileViewModel, ProfileView>();
    }

    public Control? Build(object? data)
    {
        if (data is null)
        {
            return new TextBlock { Text = "No VM provided" };
        }

        _locator.TryGetValue(data.GetType(), out var factory);

        return factory?.Invoke() ?? new TextBlock { Text = $"VM Not Registered: {data.GetType()}" };
    }

    public bool Match(object? data)
    {
        return data is ObservableObject;
    }

    /// <summary>
    /// Получение формы из контейнера, а не по контракту названий
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    /// <typeparam name="TView"></typeparam>
    private void RegisterViewFactory<TViewModel, TView>()
        where TViewModel : class
        where TView : Control
        => _locator.Add(
            typeof(TViewModel),
            Design.IsDesignMode
                ? Activator.CreateInstance<TView>
                : Ioc.Default.GetService<TView>);
}