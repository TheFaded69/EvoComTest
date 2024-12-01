using CommunityToolkit.Mvvm.ComponentModel;

namespace EvoComTest.ViewModels;

public partial class TitleViewModel : ViewModelBase
{
    public TitleViewModel()
    {
        Title = "Test title";
    }

    [ObservableProperty] private string _title;
}