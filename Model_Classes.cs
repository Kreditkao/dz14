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
    internal class Class1
    {
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int CategoryId { get; set; }
            public int ManufacturerId { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }

        public class Order
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int CustomerId { get; set; }
            public DateTime OrderDate { get; set; }
        }

        public class Manufacturer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
