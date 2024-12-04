using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using EvoComTest.Models.AppService;
using EvoComTest.ViewModels.Items;
using EvoComTest.Views;

namespace EvoComTest.ViewModels;

public partial class MenuViewModel : ViewModelBase
{
    public MenuViewModel(IPageMediator pageMediator)
    {
        pageMediator.RegisterSetter(this);
        
        MenuItems = new()
        {
            new MenuItemViewModel(typeof(ShopViewModel), "Cart", "Магазин"),
            new MenuItemViewModel(typeof(CartViewModel), "Money", "Корзина"),
            new MenuItemViewModel(typeof(ProfileViewModel), "Accessibility", "Профиль"),
        };
    }

    /// <summary>
    /// for design
    /// </summary>
    public MenuViewModel() : this(DesignData.PageMediator)
    {
        
    }
    
    [ObservableProperty]
    private bool _isMenuOpen;

    [ObservableProperty]
    private ViewModelBase _currentPage;
    
    [RelayCommand]
    private void TriggerMenu()
    {
        IsMenuOpen = !_isMenuOpen;
    }
    
    
    public ObservableCollection<MenuItemViewModel> MenuItems { get; }
    
    [ObservableProperty]
    private MenuItemViewModel? _selectedMenuItem;

    partial void OnSelectedMenuItemChanged(MenuItemViewModel? value)
    {
        if (value is null) return;
        
        var vm = Design.IsDesignMode
            ? Activator.CreateInstance(value.ModelType)
            : Ioc.Default.GetService(value.ModelType);
        
        if (vm is not ViewModelBase obs) return;

        CurrentPage = obs;
    }
}