using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TASK1.Data;
using TASK1.Models;
using TASK1.Services;

var serviceProvider = new ServiceCollection()
    .AddDbContext<ApplicationDbContect>()
    .AddTransient<ProductService>()
    .BuildServiceProvider();

var productService = serviceProvider.GetService<ProductService>();
while (true)
{
    Console.WriteLine("Choose a number to");
    
    Console.WriteLine("1) Add");
    Console.WriteLine("2) Update");
    Console.WriteLine("3) Delete");
	Console.WriteLine("4) List of All products");
    Console.WriteLine("5) Exit");

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1" : AddNewProduct(productService);
            break;
        case "2" : UpdateProduct(productService);
            break;
        case "3" : DeleteProduct(productService);
            break;
        case "4" : GetAllProducts(productService);
            break;
        case "5" : Environment.Exit(0);
            break;
        default: Console.WriteLine("Please Try again");break;
    }


}

void AddNewProduct(ProductService ProductService)
{
    Console.Write("Product Name: ");
    string name = Console.ReadLine();
    Console.Write("Price: ");
    decimal price = decimal.TryParse(Console.ReadLine(), out price) ? price : 0;
    Console.Write("Quantity: ");
    int quantity = int.TryParse(Console.ReadLine(), out quantity) ? quantity : 0;

    Product product = new Product
    {
        Name = name,
        Price = price,
        Quantity = quantity
    };
    ProductService.AddProduct(product);
    Console.WriteLine("Product now in our collections.");
}
void UpdateProduct(ProductService ProductService)
{
    Console.WriteLine("Enter Product Name: ");

    string productName = Console.ReadLine();
    var product = ProductService.GetProduct(productName);
    if( product != null)
    {
		Console.Write("Product Name: ");
        string name = Console.ReadLine();
		Console.Write("Price: ");
		decimal price = decimal.TryParse(Console.ReadLine(), out price) ? price : 0;
		Console.Write("Quantity: ");
		int quantity = int.TryParse(Console.ReadLine(), out quantity) ? quantity : 0;
        product.Name = name; product.Price = price; product.Quantity = quantity;

        ProductService.Update(product);
        Console.WriteLine("Product Updated");
	}
    else
    { Console.WriteLine("this name is wrong"); }

}

void DeleteProduct(ProductService ProductService)
{
	Console.WriteLine("Enter Product Name: ");

	string productName = Console.ReadLine();
	var product = ProductService.GetProduct(productName);
	if ( product != null )
    {
        ProductService.Delete(product.Id); 
        Console.WriteLine("Product deleted now");
    }
}

void GetAllProducts(ProductService productService)
{
    
    productService.GetAllProducts();
}


