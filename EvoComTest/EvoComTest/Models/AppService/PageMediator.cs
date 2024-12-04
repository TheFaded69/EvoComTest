using System.ComponentModel;
using EvoComTest.ViewModels;

namespace EvoComTest.Models.AppService;

public class PageMediator : IPageMediator
{
    public ViewModelBase PageOwnerViewModel { get; set; }
    public ViewModelBase PageSetterViewModel { get; set; }

    public void RegisterOwner(ViewModelBase vm)
    {
        PageOwnerViewModel = vm;
        
        if (PageSetterViewModel == null) return;
        
        if (PageOwnerViewModel is MainViewModel mainWindowViewModel && PageSetterViewModel is MenuViewModel menuViewModel)
        {
            PageSetterViewModel.PropertyChanged += PageOwnerViewModel_PropertyChanged;
        }
    }

    public void RegisterSetter(ViewModelBase vm)
    {
        PageSetterViewModel = vm;

        if (PageOwnerViewModel == null) return;
        if (PageOwnerViewModel is MainViewModel mainWindowViewModel && PageSetterViewModel is MenuViewModel menuViewModel)
        {
            PageSetterViewModel.PropertyChanged += PageOwnerViewModel_PropertyChanged;
        }
    }
    
    private void PageOwnerViewModel_PropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        if (PageSetterViewModel is MenuViewModel menuViewModel && PageOwnerViewModel is MainViewModel mainWindowViewModel)
            if (args.PropertyName == nameof(menuViewModel.CurrentPage))
                mainWindowViewModel.CurrentPage = menuViewModel.CurrentPage;
            
    }
}