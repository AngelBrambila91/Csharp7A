using System;
using static System.Console;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SharpPad;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WorkingWithEFcore
{
    class Program
    {
        // Object Oriented Model
        // annotations attributes
        // Fluent API
        // Conventions : 
        // nvarchar == string
        // same name of tables in DB
        // same names of fields in DB
        // GUid , IDENTITY
        /*
        [Required]
        [StringLength (40)]
        public string ProductName {get; set;}

        [Column (TypeName) = "money"]
        public decimal? UnitPrice {get; set;}
        */


        static void Main(string[] args)
        {
            //QueryingCategories();
            QueryingProducts();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have : ");
                IQueryable<Category> cats = db.Categories
                .Include(c => c.Products);

                // ASP.net
                // ASP MVC
                // ASP MVVVC

                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("Products that cost more than a price, highest at top");
                string input;
                decimal price;
                do
                {
                    Write("Enter a product price : ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> prods = db.Products
                .Where(product => product.Cost > price)
                .OrderByDescending(product => product.Cost);

                foreach (Product p in prods)
                {
                    WriteLine($"{p.ProductID} : {p.ProductName} costs {p.Cost: #,##0.00} and has {p.Stock} in Stock.");
                }
            }
        }  
    }
}
