using SwitchPagesMVVM.ViewModel.PagesViewModel;
using System.Windows;
namespace SwitchPagesMVVM.View;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}