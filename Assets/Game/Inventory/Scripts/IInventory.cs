namespace DrekGame.Inventory
{
    public interface IInventory
    {
        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        /// <param name="itemId">The ID of the item to add.</param>
        /// <param name="quantity">The quantity of the item to add.</param>
        void AddItem(int itemId, int quantity);

        /// <summary>
        /// Removes an item from the inventory.
        /// </summary>
        /// <param name="itemId">The ID of the item to remove.</param>
        /// <param name="quantity">The quantity of the item to remove.</param>
        void RemoveItem(int itemId, int quantity);

        /// <summary>
        /// Checks if the inventory contains a specific item.
        /// </summary>
        /// <param name="itemId">The ID of the item to check.</param>
        /// <returns>True if the item is in the inventory, false otherwise.</returns>
        bool HasItem(int itemId);
    }
}
