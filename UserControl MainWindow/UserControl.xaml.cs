namespace UserControl_MainWindow;

public partial class UserControl
{
    public string Title { get; set; }

    public int MaxLength { get; set; }
    public UserControl()
    {
        InitializeComponent();
        DataContext = this;
    }
}
