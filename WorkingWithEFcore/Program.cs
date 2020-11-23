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
            //QueryingProducts();
            //QueryingWithLike();

            // Loading Patterns
            // Lazy Loading
            // Eager Loading
            // Explicit Loading

            ListProducts();
            
            if(AddProduct(7, "Poki's Chocolate Candy", 500M))
            {
                WriteLine("Add product successful");
            }

            ListProducts();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Categories and how many products they have : ");
                IQueryable<Category> cats; //= db.Categories
                //.Include(c => c.Products);

                db.ChangeTracker.LazyLoadingEnabled = false;

                Write ("Enable eager loading? (Y / N) : ");
                bool eagerloading = ReadKey().Key == ConsoleKey.Y;
                bool explicitloading = false;

                if(eagerloading)
                {
                    cats = db.Categories.Include(c => c.Products);
                }
                else
                {
                    cats = db.Categories;
                    Write("Enable explicit loading? (Y / N) : ");
                    explicitloading = ReadKey().Key == ConsoleKey.Y;
                    WriteLine();
                }

                // ASP.net
                // ASP MVC
                // ASP MVVVC

                foreach (Category c in cats)
                {
                    if(explicitloading)
                    {
                        Write($"Explicitly load products for {c.CategoryName}? (Y / N)");
                        bool explicitKey = ReadKey().Key == ConsoleKey.Y;
                        WriteLine();
                        if(explicitKey)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if(!products.IsLoaded) products.Load();
                        }
                    }
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Products that cost more than a price, highest at top");
                string input;
                decimal price;
                do
                {
                    Write("Enter a product price : ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> prods = db.Products
                .TagWith("Products filtered by price and sorted.")
                .Where(product => product.Cost > price)
                .OrderByDescending(product => product.Cost);

                foreach (Product p in prods)
                {
                    WriteLine($"{p.ProductID} : {p.ProductName} costs {p.Cost: #,##0.00} and has {p.Stock} in Stock.");
                }
            }
        }

        static void QueryingWithLike()
        {
             using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                Write("Enter a part of a product name: ");
                string input = ReadLine();
                IQueryable<Product> prods = db.Products
                .Where(product => EF.Functions.Like(product.ProductName , $"%{input}%"));
                foreach (Product item in prods)
                {
                    WriteLine($"{item.ProductName} has {item.Stock} units in Stock. Discontinued? {item.Discontinued}");
                }
            }
        }

        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };

                db.Products.Add(newProduct);

                // save changes to DB
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0, -3} {1, -35} {2, 8} {3, 5} {4}",
                "ID", "Product Name", "Cost", "Stock", "Disc.");

                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine($"{item.ProductID : 000} {item.ProductName, -35} {item.Cost:#,##0.00} {item.Stock, 5} {item.Discontinued}");
                }
            }
        }
    }
}
