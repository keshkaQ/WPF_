
namespace SwitchPagesMVVM.Model;

public class CookieFile
{

    public void Write(string page)
    {
        File.AppendAllText("C:\\Users\\TitanPC\\source\\repos\\WPF_\\SwitchPagesMVVM.Model\\cookies.txt", $"Страница: {page}\n");
    }
    public string GetLastPage()
    {
       var prefixPages = File.ReadAllLines("C:\\Users\\TitanPC\\source\\repos\\WPF_\\SwitchPagesMVVM.Model\\cookies.txt");
       var lastPrefixPage = prefixPages.Last();
       var elementPrefixPage = lastPrefixPage.Split();
       return elementPrefixPage.Last();
    }
}
