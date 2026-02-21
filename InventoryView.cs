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
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Inventory Management ===");
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
                        Console.WriteLine("Inventory has been reset to initial stock.");
                        Pause();
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Pause();
                        break;
                }
            }
        }

        private void DisplayInventory()
        {
            var inventory = inventoryService.GetInventory();
            Console.WriteLine("\nCurrent Inventory:");
            Console.WriteLine("-----------------------------");

            for (int i = 0; i < inventory.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[0, i]} - {inventory[1, i]} units");
            }

            Console.WriteLine("-----------------------------");
            Pause();
        }

        private void UpdateStock()
        {
            var inventory = inventoryService.GetInventory();
            Console.WriteLine("\nSelect a product to update:");

            for (int i = 0; i < inventory.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[0, i]} - {inventory[1, i]} units");
            }

            Console.Write("Enter product number: ");
            if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber >= 1 && productNumber <= inventory.GetLength(1))
            {
                Console.Write("Enter new stock quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newStock) && newStock >= 0)
                {
                    inventoryService.UpdateStock(productNumber - 1, newStock);
                    Console.WriteLine("Stock updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid stock quantity.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product selection.");
            }

            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
