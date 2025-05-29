using System.Windows;
namespace Homework__2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Add_Click(object sender, RoutedEventArgs e)
    {

        var item = text.Text.ToString();
        if (!String.IsNullOrWhiteSpace(item))
        {
            list.Items.Add(item);
            list.SelectedIndex = list.Items.Count - 1;
            text.Text = "";
            text.Focus();
        }
        if (list.Items.Count == 0)
        {
            MessageBox.Show("Ошибка: Список пуст");
            return;
        }
    }

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        if (list.Items.Count == 0)
        {
            MessageBox.Show("Ошибка: Список пуст");
            return;
        }

        if (list.SelectedItem == null && list.Items.Count > 0)
        {
            list.SelectedIndex = list.Items.Count - 1;
        }

        var currentElem = list.SelectedItem;
        if (currentElem == null)
        {
            MessageBox.Show("Ошибка: Элемент для удаления не выбран");
            return;
        }
        list.Items.Remove(currentElem);
    }
}