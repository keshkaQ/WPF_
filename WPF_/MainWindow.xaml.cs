using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (String.IsNullOrWhiteSpace(x.Text) || (String.IsNullOrWhiteSpace(y.Text)))
        {
            MessageBox.Show("Поля не могут быть пустыми");
            return;
        }
        if (!double.TryParse(x.Text, out double xNum) || !double.TryParse(y.Text, out double yNum))
        {
            MessageBox.Show("Введите корректные числа");
            return;
        }
        result.Text = $"{xNum} + {yNum} = {xNum + yNum}";
    }
}