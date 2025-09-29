using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Direcciones
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Clientes
        Customer customer1 = new Customer("Juan Pérez", address1);
        Customer customer2 = new Customer("Ana Gómez", address2);

        // Productos
        Product p1 = new Product("Laptop", "LP1001", 1200m, 1);
        Product p2 = new Product("Mouse", "MS2001", 25m, 2);
        Product p3 = new Product("Keyboard", "KB3001", 45m, 1);
        Product p4 = new Product("Monitor", "MN4001", 200m, 1);

        // Orden 1
        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        // Orden 2
        Order order2 = new Order(customer2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);

        // Mostrar resultados
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost()}\n");
        }

        Console.ReadLine();
    }
}
