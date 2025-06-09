using SwitchPagesMVVM.ViewModel.PagesViewModel;
using System.Windows;
namespace SwitchPagesMVVM.View;
public partial class App : Application
{
    private readonly MainViewModel mainViewModel = new();
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = new MainWindow { DataContext = mainViewModel };
        mainWindow.Show();
        mainViewModel.RestoreDataPage();
        base.OnStartup(e);
    }
    protected override void OnExit(ExitEventArgs e)
    {
        mainViewModel.SaveDataPage();
        base.OnExit(e);
    }
}

