using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp3.Class1;
using static ConsoleApp3.Class2;
using static ConsoleApp3.Class3;

namespace ConsoleApp3
{
    internal class Class2
    {
        public class DBContext
        {
            public List<Category> Categories { get; set; } = new List<Category>();
            public List<Product> Products { get; set; } = new List<Product>();
            public List<Order> Orders { get; set; } = new List<Order>();
            public List<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
            public List<Customer> Customers { get; set; } = new List<Customer>();

            public DBContext()
            {
                InitializeData();
            }

            private void InitializeData()
            {
                // Sample data
                Categories.Add(new Category { Id = 1, Name = "Electronics" });
                Categories.Add(new Category { Id = 2, Name = "Clothing" });

                Manufacturers.Add(new Manufacturer { Id = 1, Name = "Samsung" });
                Manufacturers.Add(new Manufacturer { Id = 2, Name = "Nike" });

                Customers.Add(new Customer { Id = 1, Name = "John" });
                Customers.Add(new Customer { Id = 2, Name = "Mary" });

                Products.Add(new Product { Id = 1, Name = "Smartphone", CategoryId = 1, ManufacturerId = 1, Price = 1000, Stock = 10 });
                Products.Add(new Product { Id = 2, Name = "T-shirt", CategoryId = 2, ManufacturerId = 2, Price = 50, Stock = 20 });
            }

            // CRUD 
            public void AddCategory(Category category) => Categories.Add(category);
            public void AddProduct(Product product) => Products.Add(product);
            public void AddOrder(Order order) => Orders.Add(order);
            public void AddManufacturer(Manufacturer manufacturer) => Manufacturers.Add(manufacturer);
            public void AddCustomer(Customer customer) => Customers.Add(customer);

            public void UpdateCategory(Category category)
            {
                var existingCategory = Categories.FirstOrDefault(c => c.Id == category.Id);
                if (existingCategory != null)
                {
                    existingCategory.Name = category.Name;
                }
            }

            public void UpdateProduct(Product product)
            {
                var existingProduct = Products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.ManufacturerId = product.ManufacturerId;
                    existingProduct.Price = product.Price;
                    existingProduct.Stock = product.Stock;
                }
            }

            public void DeleteCategory(int id) => Categories.RemoveAll(c => c.Id == id);
            public void DeleteProduct(int id) => Products.RemoveAll(p => p.Id == id);
            public void DeleteOrder(int id) => Orders.RemoveAll(o => o.Id == id);
            public void DeleteManufacturer(int id) => Manufacturers.RemoveAll(m => m.Id == id);
            public void DeleteCustomer(int id) => Customers.RemoveAll(c => c.Id == id);
        }
    }
}
