using System.Windows;
using System.Windows.Controls;
namespace Homework_3._2.Xaml;

public partial class ThirdQuestion : Window
{
    private List<Window> _windows;
    private AnswerContext _answerContext;
    public ThirdQuestion(List<Window> windows, AnswerContext answerContext)
    {
        _windows = windows;
        _answerContext = answerContext;
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (q3Option3.IsChecked == true)
        {
            _answerContext.countCorrectAnswers++;
        }
        if (_answerContext.CurrentQuestion == _windows.Count)
        {
            MessageBox.Show($"Тест пройден. Количество правильных ответов: {_answerContext.countCorrectAnswers}");
            Close();
        }
    }
}
