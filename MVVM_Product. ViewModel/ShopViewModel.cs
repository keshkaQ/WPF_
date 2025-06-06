using MVVM_Product.Model;
using System.Collections.ObjectModel;

namespace MVVM_Product._ViewModel;

public class ShopViewModel
{
    public readonly RepositoryProduct repositoryProduct = new();
    public ObservableCollection<Product> Products { get; set; } = [];
    public ShopViewModel()
    {
        var products = repositoryProduct.GetFirstProducts();
        for(int i = 0; i<products.Count;i++)
        {
            Products.Add(products[i]);
        }
        LoadProductsCommand = new(LoadProducts);
    }
    public RelayCommand LoadProductsCommand { get; set; }
    public void LoadProducts(object? parameter)
    {
        var products = repositoryProduct.GetNewProducts();
        Products.Clear();
        for (int i = 0; i < products.Count; i++)
        {
            Products.Add(products[i]);
        }
    }
}
