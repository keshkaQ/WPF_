using System.Windows.Input;

namespace ViewModel;

// Класс, который реализовывает интерфейс ICommand, 
// который хранить ссылку на метод (те действия, которые будут происходить при нажатии на кнопку),
// когда будет срабатывать команда

public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand
{
    private readonly Action<object?> execute = execute;
    private Func<object?, bool>? canExecute = canExecute;

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute(parameter);
    }
    // выполнение той функции, которой я хочу
    public void Execute(object? parameter)
    {
        execute(parameter);
    }
}