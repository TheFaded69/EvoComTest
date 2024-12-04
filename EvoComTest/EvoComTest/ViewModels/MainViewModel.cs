using CommunityToolkit.Mvvm.ComponentModel;
using EvoComTest.Models.AppService;
using EvoComTest.Views;

namespace EvoComTest.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel(IPageMediator pageMediator)
    {
        pageMediator.RegisterOwner(this);

    }
    
    /// <summary>
    /// for design
    /// </summary>
    public MainViewModel() : this(DesignData.PageMediator)
    {
    }
    
    
    
    [ObservableProperty]
    private ViewModelBase _currentPage;
}