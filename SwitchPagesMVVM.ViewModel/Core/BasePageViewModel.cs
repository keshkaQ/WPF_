namespace SwitchPagesMVVM.ViewModel.Core;

public class BasePageViewModel:ObservableObject
{
    // привязка свойства, чтобы текст сохранялся при переходе в текстбоксе
    public string? Text { get; set; }
}
