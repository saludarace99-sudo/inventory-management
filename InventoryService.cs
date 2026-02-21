namespace InventoryManagement.Services
{
    public class InventoryService
    {
        private string[,] products;
        private string[] initialStock;

        public InventoryService()
        {
            products = new string[2, 3]
            {
                { "Apples", "Milk", "Bread" },   // Row 0: Product Names
                { "10", "5", "20" }              // Row 1: Stock Quantities
            };

            // Store original stock for reset
            initialStock = new string[3];
            for (int i = 0; i < 3; i++)
            {
                initialStock[i] = products[1, i];
            }
        }

        public string[,] GetInventory()
        {
            return products;
        }

        public void UpdateStock(int index, string newStock)
        {
            if (index >= 0 && index < 3)
            {
                products[1, index] = newStock;
            }
        }

        public void ResetInventory()
        {
            for (int i = 0; i < 3; i++)
            {
                products[1, i] = initialStock[i];
            }
        }
    }
}
