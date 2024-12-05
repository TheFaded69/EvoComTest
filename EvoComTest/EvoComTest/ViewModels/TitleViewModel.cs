using CommunityToolkit.Mvvm.ComponentModel;

namespace EvoComTest.ViewModels;

public partial class TitleViewModel : ViewModelBase
{
    public TitleViewModel()
    {
        Title = "Test title";
        
        //TODO обновление заголовка
    }

    [ObservableProperty] private string _title;
}