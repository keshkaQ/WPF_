using Homework_3._2.Xaml;
using System.Windows;
namespace Homework_3._2;

public partial class MainWindow : Window
{
    private List<Window> windows;
    private AnswerContext answerContext;
    public MainWindow()
    {
        InitializeComponent();
        answerContext = new AnswerContext();
        windows = new List<Window>();
        windows.Add(new SecondQuestion(windows, answerContext));
        windows.Add(new ThirdQuestion(windows, answerContext));
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (q1Option1.IsChecked == true)
        {
            answerContext.countCorrectAnswers++;
        }
        var nextWindow = windows[answerContext.CurrentQuestion];
        answerContext.CurrentQuestion++;
        nextWindow.Show();
        Close();
    }
}
