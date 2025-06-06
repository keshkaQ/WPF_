namespace MVVM_Product.Model;

public class RepositoryProduct
{
    public List<Product> products = new();
    public List<Product> GetFirstProducts()
    {
        products.Add(new Product { Brand = "MSI", Name = "Laptop", Price = 85_000 });
        products.Add(new Product { Brand = "Iphone", Name = "Iphone 15", Price = 90_000 });
        products.Add(new Product { Brand = "Xiaomi", Name = "Smartphone", Price = 30_000 });
        products.Add(new Product { Brand = "Lenovo", Name = "TV", Price = 25_000 });
        products.Add(new Product { Brand = "Razer", Name = "HeadPhones", Price = 15_000 });
        return products;
    }

    public List<Product> GetNewProducts()
    {
        products.Clear();
        products.Add(new Product { Brand = "Iphone", Name = "Iphone 12", Price = 27_000 });
        products.Add(new Product { Brand = "Iphone", Name = "Iphone 13", Price = 38_000 });
        products.Add(new Product { Brand = "Iphone", Name = "Iphone 14", Price = 45_000 });
        products.Add(new Product { Brand = "Iphone", Name = "Iphone 15", Price = 50_000 });
        products.Add(new Product { Brand = "Iphone", Name = "Iphone 16", Price = 55_000 });
        return products;
    }
}
