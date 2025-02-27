using static ConsoleApp3.Class1;
using static ConsoleApp3.Class2;
using static ConsoleApp3.Class3;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DBContext();
            var service = new Service(dbContext);

            var product = service.GetProductById(1);
            Console.WriteLine($"Product: {product?.Name}, Price: {product?.Price}, Stock: {product?.Stock}");

            var sortedProducts = service.SortProductsByPrice();
            Console.WriteLine("Sorted Products:");
            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }

            service.PurchaseProduct(1, 1);
            Console.WriteLine($"Smartphone Stock: {service.GetProductById(1).Stock}");

            service.AddStock(1, 5);
            Console.WriteLine($"Smartphone Stock after restocking: {service.GetProductById(1).Stock}");

            var order = dbContext.Orders.FirstOrDefault();
            if (order != null)
            {
                service.ReturnProduct(order.Id);
                Console.WriteLine($"Smartphone Stock after return: {service.GetProductById(1).Stock}");
            }
        }
    }
}
