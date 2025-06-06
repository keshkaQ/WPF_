namespace MVVM_Product._ViewModel;
using System.Windows.Input;
public class RelayCommand : ICommand
{
    private Action<object> execute;

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public RelayCommand(Action<object> execute)
    {
        this.execute = execute;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }
}
