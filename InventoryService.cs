using System;

namespace InventoryManagement.Services
{
    public class InventoryService
    {
        private string[,] products;
        private string[,] initialStock;

        public InventoryService()
        {
            // Initialize the inventory
            products = new string[2, 3]
            {
                { "Apples", "Milk", "Bread" },  // Product names
                { "10", "5", "20" }             // Stock quantities
            };

            // Store the initial stock for reset
            initialStock = new string[2, 3];
            Array.Copy(products, initialStock, products.Length);
        }

        // Get the inventory data
        public string[,] GetInventory()
        {
            return products;
        }

        // Update stock for a given product index (0-based)
        public void UpdateStock(int productIndex, int newStock)
        {
            if (productIndex >= 0 && productIndex < products.GetLength(1))
            {
                products[1, productIndex] = newStock.ToString();
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid product index.");
            }
        }

        // Reset the inventory to its initial stock
        public void ResetInventory()
        {
            Array.Copy(initialStock, products, products.Length);
        }
    }
}
