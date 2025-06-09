namespace SwitchPagesMVVM.Model;

public class Storage
{
    public string Read()
    {
        var data = File.ReadAllText("C:\\Users\\TitanPC\\source\\repos\\WPF_\\SwitchPagesMVVM.Model\\data.txt");
        return data;
    }
    public void Write(string data)
    {
        File.WriteAllText("C:\\Users\\TitanPC\\source\\repos\\WPF_\\SwitchPagesMVVM.Model\\data.txt", data);
    }
}
