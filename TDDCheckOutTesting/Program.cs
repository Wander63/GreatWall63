using CheckOutLib;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Create pricing rules
        Dictionary<char, int> unitPrices = new Dictionary<char, int>()
        {
            {'A', 50},
            {'B', 30},
            {'C', 20},
            {'D', 15}
        };

        Dictionary<char, Tuple<int, int>> specialPrices = new Dictionary<char, Tuple<int, int>>()
        {
            {'A', new Tuple<int, int>(3, 130)},
            {'B', new Tuple<int, int>(2, 45)}
        };

        // Create a checkout instance
        ICheckout checkout = new Checkout(unitPrices, specialPrices);

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
