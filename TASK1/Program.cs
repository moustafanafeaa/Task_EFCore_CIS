using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TASK1;
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
        case "1" : 
            CRUD.AddNewProduct(productService);
            break;
        case "2" : 
            CRUD.UpdateProduct(productService);
            break;
        case "3" :
			CRUD.DeleteProduct(productService);
            break;
        case "4" :
			CRUD.GetAllProducts(productService);
            break;
        case "5" : Environment.Exit(0);
            break;
        default: Console.WriteLine("Please Try again");break;
    }
}
