using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK1.Models;

namespace TASK1.Data
{
    internal class ApplicationDbContect : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=EFCore_CisTask;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
    }
}
