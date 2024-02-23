using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK1.Data;
using TASK1.Models;

namespace TASK1.Services
{
	internal class ProductService
	{
		private readonly ApplicationDbContect _context;

        
        public ProductService(ApplicationDbContect context)
		{
			_context = context;
		}

		public void AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}
		public Product GetProduct(string name)
		{
			return _context.Products.FirstOrDefault(x=>x.Name == name);
		}

		public void GetAllProducts()
		{
			var products= _context.Products.ToList();
			foreach (var product in products) { Console.WriteLine("[Name:"+product.Name +", Price:"+product.Price+", Quantity:"+product.Quantity+"]"); }
		}
		public void Update(Product product)
		{
			_context.Products.Update(product);
			_context.SaveChanges();
		}
		public void Delete(int id)
		{
			var product= _context.Products.FirstOrDefault(x => x.Id == id);
			if(product != null)
			{
				_context.Products.Remove(product);
				_context.SaveChanges();
			}
		
		}
	}
}
