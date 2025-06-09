using SwitchPagesMVVM.ViewModel.Core;
using SwitchPagesMVVM.ViewModel.PagesViewModel;

namespace SwitchPagesMVVM.ViewModel.Factories;

// Паттерн фабрика - передача параметра и создание конкретного класса
public class FactoryPageViewModel
{
    // делегат каждый раз возвращает новый экзепляр класса
    private Dictionary<Type, Func<BasePageViewModel>> pageViewModelByType = [];
    // словарь для восстановления последней страницы
    private Dictionary<string, Func<BasePageViewModel>> pageViewModelByNameType = [];
    public FactoryPageViewModel()
    {
        // добавляем страницы в словарь, где ключ - тип страницы
        pageViewModelByType.Add(typeof(AboutPageViewModel), ()=>new AboutPageViewModel());
        pageViewModelByType.Add(typeof(HomePageViewModel), () => new HomePageViewModel());
        
        // добавляем страницы в словарь, где ключ - имя типа
        pageViewModelByNameType.Add(nameof(AboutPageViewModel), () => new AboutPageViewModel());
        pageViewModelByNameType.Add(nameof(HomePageViewModel), () => new HomePageViewModel());
    }
    // в этом методе возвращаем конкретную страницу из словаря по ее типу
    public BasePageViewModel Create(Type type)
    {
        return pageViewModelByType[type].Invoke();
    }
    // в этом методе возвращаем последнюю страницу из куки файлов
    public BasePageViewModel Create(string nameType)
    {
        return pageViewModelByNameType[nameType].Invoke();
    }
}
