using CommunityToolkit.Mvvm.ComponentModel;

namespace EvoComTest.ViewModels;

public partial class ProfileViewModel : ViewModelBase

{
    public ProfileViewModel()
    {
        
    }


    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _phoneNumber;
}