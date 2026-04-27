using System;
using System.IO;
using ProductStore.Core;
using ProductStore.Model;

const string path = @"C:\Users\COLLEGE\RiderProjects\ProductStore\product.db";

string connectionString = $"Data Source={path}";
ProductService productService = new ProductService(connectionString);

Console.WriteLine("1. Добавление продукта:");
var product = new Product
{
    Article = "ART-001",
    Name = "Молоко 3.2%",
    Manufacturer = "Простоквашино",
    Price = 89.99m,
    Quantity = 50
};
productService.Add(product);
Console.WriteLine($"   Продукт '{product.Name}' добавлен\n");

Console.WriteLine("2. Все продукты:");
var all = productService.GetAll();
all.ForEach(p => Console.WriteLine($"   {p.Id}: {p.Name} - {p.Price} руб. ({p.Quantity} шт.)"));
Console.WriteLine();

Console.WriteLine("3. Поиск по ID (1):");
var byId = productService.GetById(1);
Console.WriteLine($"   Найден: {byId.Name}\n");

Console.WriteLine("4. Поиск по артикулу (ART-001):");
var byArticle = productService.GetByArticle("ART-001");
Console.WriteLine($"   Найден: {byArticle.Name}\n");

Console.WriteLine("5. Поиск по названию ('молоко'):");
var byName = productService.GetByName("молоко");
byName.ForEach(p => Console.WriteLine($"   Найден: {p.Name}"));
Console.WriteLine();

Console.WriteLine("6. Поиск по производителю ('Простоквашино'):");
var byManufacturer = productService.GetByManufacturer("Простоквашино");
byManufacturer.ForEach(p => Console.WriteLine($"   {p.Name}"));
Console.WriteLine();

Console.WriteLine("7. Поиск по цене:");
var byPrice = productService.GetByPrice(89.99m);
byPrice.ForEach(p => Console.WriteLine($"   {p.Name} - {p.Price} руб."));

var byPriceRange = productService.GetByPrice(80);
Console.WriteLine("   80руб.:");
byPriceRange.ForEach(p => Console.WriteLine($"   {p.Name} - {p.Price} руб."));
Console.WriteLine();

Console.WriteLine("8. Поиск по количеству:");
var byQuantity = productService.GetByQuantity(50);
byQuantity.ForEach(p => Console.WriteLine($"   {p.Name} - {p.Quantity} шт."));

Console.WriteLine("9. Обновление продукта:");
Console.WriteLine($"   До: {product.Name} - {product.Price} руб. ({product.Quantity} шт.)");
product.Price = 95.00m;
product.Quantity = 45;
productService.Update(product);
var updated = productService.GetById(1);
Console.WriteLine($"   После: {updated.Name} - {updated.Price} руб. ({updated.Quantity} шт.)\n");