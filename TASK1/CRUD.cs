using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK1.Models;
using TASK1.Services;

namespace TASK1
{
	internal static  class CRUD
	{
		public static void AddNewProduct(ProductService ProductService)
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

		public static void UpdateProduct(ProductService ProductService)
		{
			Console.WriteLine("Enter Product Name: ");

			string productName = Console.ReadLine();
			var product = ProductService.GetProduct(productName);
			if (product != null)
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

		public static void DeleteProduct(ProductService ProductService)
		{
			Console.WriteLine("Enter Product Name: ");

			string productName = Console.ReadLine();
			var product = ProductService.GetProduct(productName);
			if (product != null)
			{
				ProductService.Delete(product.Id);
				Console.WriteLine("Product deleted now");
			}
		}

		public static void GetAllProducts(ProductService productService)
		{

			productService.GetAllProducts();
		}
	}
}
