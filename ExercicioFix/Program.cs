using ExercicioFix.Entities;
using ExercicioFix.Entities.Enums;
using System;
using System.Globalization;

namespace ExercicioFix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birthday date (dd/MM/yyyy): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter Order Data");
            OrderStatus status = Enum.Parse<OrderStatus>("Processing");
            Console.WriteLine("Order Momment: " + status);
            Console.Write("Quantos produtos vai ter o seu pedido: ");

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");

                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Product product = new Product(productName, price);
                Console.Write("Quantity: ");
                int quant = int.Parse(Console.ReadLine());

                OrderItem item = new OrderItem(quant, price, product);

                order.AddItem(item);
                

            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY");
            status = Enum.Parse<OrderStatus>("Processing");
            Console.WriteLine("Order Momment");
            Console.WriteLine("Order status: " + status);
            Console.WriteLine(client);
            Console.WriteLine();
            Console.WriteLine("Order Items:");
            Console.WriteLine(order);
        }
    }
}
