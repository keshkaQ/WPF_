using Model_;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
namespace ViewModel;

public class ToDoViewModel : INotifyPropertyChanged
{
    private TaskViewModel? selectedTask;
    public TaskViewModel? SelectedTask
    {
        get
        {
            return selectedTask;
        }
        set
        {
            selectedTask = value;
            OnPropertyChanged(nameof(SelectedTask));
        }
    }
    // коллекция ObservableCollection предназначена для того,чтобы обновлять внешнее представление, когда добавляем/удаляем элементы
    public ObservableCollection<TaskViewModel> Tasks { get; set; }

    // обновления поля textTask
    private string textTask;
    public string TextTask
    {
        get
        {
            return textTask;
        }
        set
        {
            textTask = value;
            OnPropertyChanged(nameof(TextTask));
        }
    }
    public ToDoViewModel()
    {
        Tasks =
            [new TaskViewModel { Name = "Homework", IsCompleted = false },
            new TaskViewModel { Name = "Walk", IsCompleted = false },
            new TaskViewModel { Name = "Work", IsCompleted = false },
            new TaskViewModel { Name = "Dance", IsCompleted = false },
            ];
        //  привязываем команду к методу
        AddTaskCommand = new(AddTask);
        DeleteTaskCommand = new(DeleteTask);
    }
    // создаем команду добавления задачи
    public RelayCommand AddTaskCommand { get; set; }

    // создаем метод, который хотим привязать
    private void AddTask(object? parameter)
    {
        if (!string.IsNullOrEmpty(TextTask))
        {
            Tasks.Add(new TaskViewModel { Name = TextTask });
            TextTask = string.Empty; // Сработает благодаря INotifyPropertyChanged
        }
    }
    // создаем команду удаления задачи
    public RelayCommand DeleteTaskCommand { get; set; }

    // создаем метод, который хотим привязать
    private void DeleteTask(object? parameter)
    {
        if (SelectedTask != null)
        {
            Tasks.Remove(SelectedTask);
        }
        else
        {
            MessageBox.Show("Задача не выбрана или список пуст");
        }
    }
    // Реализация интерфейса INotifyPropertyChanged, здесь вызывается метод, который сообщает внешнему представлению, что свойство изменилось
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    //Запись в файл
    public void SaveTasks(string filePath)
    {
        var listTasksModel = new List<TaskModel>();
        foreach (var task in Tasks)
        {
            var taskModel = new TaskModel { Name = task.Name, IsCompleted = task.IsCompleted };
            listTasksModel.Add(taskModel);
        }
        new TaskManager().Write(listTasksModel, filePath);
    }
    //чтение из файла
    public void LoadTasks(string filePath)
    {
        var listTaskModel = new TaskManager().Read(filePath);
        Tasks.Clear();
        foreach(var task in listTaskModel)
        {
            var taskViewModel = new TaskViewModel { Name = task.Name, IsCompleted = task.IsCompleted };
            Tasks.Add(taskViewModel);
        }
    }
}
