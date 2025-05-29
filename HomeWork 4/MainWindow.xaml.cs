using HomeWork_4.Pages;
using System.Windows;
using System.Windows.Controls;
namespace HomeWork_4;
public partial class MainWindow : Window
{
    private readonly Dictionary<int, Page> pagesByNumber = [];
    public MainWindow()
    {
        InitializeComponent();
        var homePage = new HomePage();
        pagesByNumber.Add(0, homePage);
        pagesByNumber.Add(1, new AboutPage());
        pagesByNumber.Add(2, new ContactPage());

        MyFrame.Navigate(homePage);
    }

    private void NavigateToPage(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var commandParametr = int.Parse(button.CommandParameter.ToString());
        var page = pagesByNumber[commandParametr];
        MyFrame.Navigate(page);
    }
}