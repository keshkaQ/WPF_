using SwitchPagesMVVM.Model;
using SwitchPagesMVVM.ViewModel.Core;
using SwitchPagesMVVM.ViewModel.Factories;
using SwitchPagesMVVM.ViewModel.Services.Interfaces;

namespace SwitchPagesMVVM.ViewModel.Services;

public class NavigateService(CookieFile cookieFile,FactoryPageViewModel factoryPageViewModel) : ObservableObject, INavigationService
{
    private BasePageViewModel? basePageViewModel;
    public BasePageViewModel? BasePageViewModel
    {
        get
        {
            return basePageViewModel;
        }
        set
        {
            basePageViewModel = value;
            OnPropertyChanged();
        }

    }
    // метод создает страницу ViewModel
    public void NavigateTo<T>() where T : BasePageViewModel
    {
        if (basePageViewModel is not T)
        {
            cookieFile.Write(typeof(T).Name);
            BasePageViewModel = factoryPageViewModel.Create(typeof(T));
        }
    }

    public void SetPageViewModel(BasePageViewModel pageViewModel)
    {
        BasePageViewModel = pageViewModel;
    }
}
