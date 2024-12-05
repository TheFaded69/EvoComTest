using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EvoComTest.ViewModels;

public partial class ProfileViewModel : ViewModelBase

{
    public ProfileViewModel()
    {
        //TODO ВМ профиля
    }


    [EmailAddress]
    //[RegularExpression(@"/^[A-Z0-9._%+-]+@[A-Z0-9-]+.+.[A-Z]{2,4}$/i")]
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    [RegularExpression(@"^(\+7|8)\d{10}$")]
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => SetProperty(ref _phoneNumber, value);
    }

    private string _email;
    private string _phoneNumber;
}