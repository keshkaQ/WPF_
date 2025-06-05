using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
namespace View;
public partial class ToDo : Window
{
    private readonly ToDoViewModel toDoViewModel = new();
    public ToDo()
    {
        InitializeComponent();
        DataContext = toDoViewModel;
    }

    private void SaveTasksToFile(object sender, RoutedEventArgs e)
    {
        var saveFile = new SaveFileDialog();
        if (saveFile.ShowDialog() == true)
        {
            toDoViewModel.SaveTasks(saveFile.FileName);
            MessageBox.Show("задачи сохранены в файл");
        }
    }

    private void LoadTasksFromFile(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            toDoViewModel.LoadTasks(openFileDialog.FileName);
            MessageBox.Show("Задачи из файла загружены");
        }
    }
}