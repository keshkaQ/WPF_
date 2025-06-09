using SwitchPagesMVVM.Model;
using SwitchPagesMVVM.ViewModel.Core;
using SwitchPagesMVVM.ViewModel.Factories;
using SwitchPagesMVVM.ViewModel.Services;
using System.Net;

namespace SwitchPagesMVVM.ViewModel.PagesViewModel;

public class MainViewModel
{
    public NavigateService NavigateService { get; }
    public RelayCommand NavigateToAboutCommand { get; set; }
    public RelayCommand NavigateToHomeCommand { get; set; }
    private readonly CookieFile cookieFile = new();
    private readonly FactoryPageViewModel factoryPageViewModel = new();
    private readonly Storage storage = new();
    public MainViewModel()
    {
        NavigateService = new(cookieFile, factoryPageViewModel);
        NavigateToAboutCommand = new(obj => NavigateService.NavigateTo<AboutPageViewModel>());
        NavigateToHomeCommand = new(obj => NavigateService.NavigateTo<HomePageViewModel>());
    }

    public void SaveDataPage()
    {
        if (NavigateService.BasePageViewModel == null || NavigateService.BasePageViewModel.Text == null)
        {
            return;
        }
        storage.Write(NavigateService.BasePageViewModel.Text);
    }
    public void RestoreDataPage()
    {
        var nameTypeLastPage = cookieFile.GetLastPage();
        var pageViewModel = factoryPageViewModel.Create(nameTypeLastPage);
        NavigateService.SetPageViewModel(pageViewModel);
        if (NavigateService.BasePageViewModel == null)
        {
            return;
        }
        NavigateService.BasePageViewModel.Text = storage.Read();
    }
}
