using System.Windows;
namespace Homework_3._2.Xaml;

public partial class SecondQuestion : Window
{
    private List<Window> _windows;
    private AnswerContext _answerContext;
    public SecondQuestion(List<Window> windows, AnswerContext answerContext)
    {
        _windows = windows;
        _answerContext = answerContext;
        InitializeComponent();

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (q2Option1.IsChecked == true && q2Option2.IsChecked == true)
        {
            _answerContext.countCorrectAnswers++;
        }
        var nextWindow = _windows[_answerContext.CurrentQuestion];
        _answerContext.CurrentQuestion++;
        nextWindow.Show();
        Close();
    }
}
