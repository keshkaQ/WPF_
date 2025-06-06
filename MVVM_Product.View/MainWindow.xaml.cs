using MVVM_Product._ViewModel;
using System.Windows;
namespace MVVM_Product.View;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ShopViewModel();
    }
}