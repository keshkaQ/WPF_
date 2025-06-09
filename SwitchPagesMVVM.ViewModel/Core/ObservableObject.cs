using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SwitchPagesMVVM.ViewModel.Core;

// абстрактный класс для страниц, который реализует интерфейс INotifyPropertyChanged
public abstract class ObservableObject : INotifyPropertyChanged
{
    public string Title { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
