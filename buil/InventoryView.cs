using System;
using InventoryManagement.Services;

namespace InventoryManagement.Views
{
    public class InventoryView
    {
        private InventoryService inventoryService;

        public InventoryView()
        {
            inventoryService = new InventoryService();
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n==== Inventory Management ====");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayInventory();
                        break;

                    case "2":
                        UpdateStock();
                        break;

                    case "3":
                        inventoryService.ResetInventory();
                        Console.WriteLine("Inventory has been reset.");
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void DisplayInventory()
        {
            var products = inventoryService.GetInventory();

            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - Stock: {products[1, i]}");
            }
        }

        private void UpdateStock()
        {
            DisplayInventory();
            Console.Write("Select product number to update: ");

            if (int.TryParse(Console.ReadLine(), out int productNumber))
            {
                Console.Write("Enter new stock quantity: ");
                string newStock = Console.ReadLine();

                inventoryService.UpdateStock(productNumber - 1, newStock);
                Console.WriteLine("Stock updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
