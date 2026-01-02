using System.Collections.Generic;
using DrekGame.Systems;
using UnityEngine;

namespace DrekGame.Inventory.Database
{
    /// <summary>
    /// Singleton database managing all item definitions.
    /// </summary>
    public class ItemDatabase : MonoBehaviourSingleton<ItemDatabase>
    {
        /// <summary>
        /// List of items in the database.
        /// </summary>
        [field: SerializeField]
        private List<ItemValuePair> _items = new();

        // TODO: Consider using a Dictionary for faster lookups if performance becomes an issue.

        /// <summary>
        /// Retrieve an item by its unique ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ItemDefinition GetItemById(int id)
        {
            // Negative IDs are invalid.
            if (id < 0)
            {

#if UNITY_EDITOR
                Debug.LogWarning($"Invalid item ID: {id}");
#endif

                return null;
            }

            // TODO: Implement a dictionary for faster lookups if performance becomes an issue.

            // For now, we do a linear search.
            ItemValuePair item = _items.Find(i => i.Value == id);

            if (item != null)
            {
                return item.Item;
            }

#if UNITY_EDITOR
            Debug.LogWarning($"Item with ID {id} not found in database.");
#endif

            return null;
        }
    }
}
