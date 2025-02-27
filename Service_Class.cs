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
    internal class Class3
    {
        public class Service
        {
            private readonly DBContext _dbContext;

            public Service(DBContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Product GetProductById(int id) => _dbContext.Products.FirstOrDefault(p => p.Id == id);

            public List<Product> SearchProducts(string searchTerm) =>
                _dbContext.Products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

            public List<Product> SortProductsByPrice() => _dbContext.Products.OrderBy(p => p.Price).ToList();

            public void PurchaseProduct(int productId, int customerId)
            {
                var product = GetProductById(productId);
                if (product != null && product.Stock > 0)
                {
                    product.Stock--;
                    _dbContext.Orders.Add(new Order { ProductId = productId, CustomerId = customerId, OrderDate = DateTime.Now });
                }
                else
                {
                    Console.WriteLine("Product is out of stock.");
                }
            }

            public void ReturnProduct(int orderId)
            {
                var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    var product = GetProductById(order.ProductId);
                    if (product != null)
                    {
                        product.Stock++;
                        _dbContext.Orders.Remove(order);
                    }
                }
            }

            public void AddStock(int productId, int quantity)
            {
                var product = GetProductById(productId);
                if (product != null)
                {
                    product.Stock += quantity;
                }
            }
        }
    }
}
