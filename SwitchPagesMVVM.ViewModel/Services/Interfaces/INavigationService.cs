using SwitchPagesMVVM.ViewModel.Core;

namespace SwitchPagesMVVM.ViewModel.Services.Interfaces;
public interface INavigationService
{
    BasePageViewModel BasePageViewModel { get; }
    void NavigateTo<T>() where T : BasePageViewModel;
}
