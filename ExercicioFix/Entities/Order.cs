using ExercicioFix.Entities;
using ExercicioFix.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExercicioFix
{
    class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime date, OrderStatus status, Client client)
        {
            Date = date;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        
     
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Momment: " + Date.ToString("dd/MM/yyyy hh:mm:ss"));
            foreach(OrderItem item in Items)

            {
                sb.AppendLine(item.ToString());
                Console.WriteLine();
            }
            sb.AppendLine("Total Price: " + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
            
        }
    }
}
