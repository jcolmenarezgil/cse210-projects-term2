using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Create dumb address
        Address usaAddress1 = new Address("1536 Main St", "Doral", "FL", "USA");
        Address usaAddress2 = new Address("87th Oak Avenue", "SpringField", "IL", "USA");
        Address canadaAddress = new Address("88state Pine Rd", "Toronto", "ON", "Canada");

        // Name customers
        Customer customer1 = new Customer("Jhonny Dwason", usaAddress1);
        Customer customer2 = new Customer("Alice Smith", usaAddress2);
        Customer customer3 = new Customer("Dianey Roy", canadaAddress);

        // Product Slot
        Product product1 = new Product("Intel 9, 11 Gen, Laptop 15 Inch'", 0585, 2300.36, 1);
        Product product2 = new Product("Mouse w/Pad Wirelss", 0045, 32.81, 1);
        Product product3 = new Product("Flat Screen 35' 120Hz Imax", 1005, 209.58, 1);
        Product product4 = new Product("Drone 1080p FVP Voice control", 0998, 132.99, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product4);

        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product4);

        // Display information about order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}\n");

        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order3.CalculateTotalCost():F2}\n");
    }
}