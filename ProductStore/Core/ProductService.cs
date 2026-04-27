using System.Collections.Generic;
using System.Linq;
using ProductStore.Model;

namespace ProductStore.Core;

public class ProductService : IRepository<Product>
{
    private readonly ProductContext _dbContext;

    public ProductService(string connectionString)
    {
        _dbContext = new ProductContext(connectionString);
    }

    public void Add(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _dbContext.Products.Remove(_dbContext.Products.Find(id));
        _dbContext.SaveChanges();
        //FIXME
    }

    public void Update(Product product)
    {
        var newProduct = _dbContext.Products.Find(product.Id);
        if (newProduct != null)
        {
            newProduct.Name = product.Name;
            newProduct.Manufacturer = product.Manufacturer;
            newProduct.Price = product.Price;
            newProduct.Quantity = product.Quantity;

            _dbContext.SaveChanges();
        }
    }

    public List<Product> GetAll()
    {
        return _dbContext.Products.ToList();
    }

    public Product GetById(int id)
    {
        return _dbContext.Products.Find(id);
    }

    public Product GetByArticle(string article)
    {
        return _dbContext.Products.SingleOrDefault(p => p.Article == article);
    }

    public List<Product> GetByManufacturer(string manufacturer)
    {
        return _dbContext.Products.Where(p => p.Manufacturer == manufacturer).ToList();
    }

    public List<Product> GetByQuantity(int quantity)
    {
        return _dbContext.Products.Where(p => p.Quantity == quantity).ToList();
    }

    public List<Product> GetByPrice(decimal price)
    {
        return _dbContext.Products.Where(p => p.Price == price).ToList();
    }

    public List<Product> GetByName(string name)
    {
        return _dbContext.Products.Where(p => p.Name == name).ToList();
    }
}