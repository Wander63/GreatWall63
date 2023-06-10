using CheckOutLib;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Create pricing rules
        var itemCounts = new Dictionary<char, int>();
        Dictionary<char, decimal> unitPrices = new Dictionary<char, decimal>()
        {
            {'A', 50},
            {'B', 30},
            {'C', 20},
            {'D', 15},
            {'&', 5 }
        };

        Dictionary<char, Tuple<int, decimal>> specialPrices = new Dictionary<char, Tuple<int, decimal>>()
        {
            {'A', new Tuple<int, decimal>(3, 130)},
            {'B', new Tuple<int, decimal>(2, 45)},
            {'&', new Tuple<int, decimal>(5, 5)}
        };

        // Create a checkout instance
        ICheckout checkout = new Checkout(unitPrices, itemCounts, specialPrices, '&');

        // Scan items
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("C");
        checkout.Scan("D");
        checkout.Scan("A");
        checkout.Scan("B");

        // Get total price
        decimal totalPrice = checkout.GetTotalPrice();
        Console.WriteLine("Total price: " + totalPrice);
    }
}
