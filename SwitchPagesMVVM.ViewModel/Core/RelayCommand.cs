using System.Windows.Input;

namespace SwitchPagesMVVM.ViewModel.Core;

// класс, который хранит ссылку на метод, который будет вызываться, когда будет происходить событие
public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter)
    {
        return canExecute == null || canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        execute(parameter);
    }
}
