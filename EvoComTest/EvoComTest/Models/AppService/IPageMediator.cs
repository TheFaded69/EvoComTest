using EvoComTest.ViewModels;

namespace EvoComTest.Models.AppService;

public interface IPageMediator
{
    void RegisterOwner(ViewModelBase vm);
    void RegisterSetter(ViewModelBase vm);
}