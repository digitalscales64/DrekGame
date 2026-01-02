using UnityEngine;
using DrekGame.Inventory.Actions;

namespace DrekGame.Inventory
{
    /// <summary>
    /// Defines an item in the inventory system.
    /// </summary>
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class ItemDefinition : ScriptableObject
    {
        [field: SerializeField, Tooltip("The display name of the item.")]
        public string Name { get; private set; }

        [field: SerializeField, TextArea, Tooltip("A brief description of the item.")]
        public string Description { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }

        [field: SerializeField, Tooltip("Maximum number of items that can be stacked together.")]
        public int MaxStackSize { get; private set; } = 1;
        public bool IsStackable => MaxStackSize > 1;

        /// <summary>
        /// The category specifying item's rarity.
        /// </summary>
        [field: SerializeField]
        public ItemCategories Category { get; private set; }

        /// <summary>
        /// Tags assigned to the item for categorization.
        /// </summary>
        [field: SerializeField]
        public ItemTags Tags { get; private set; }

        [field: SerializeReference, SubclassSelector, Tooltip("Actions that this item can perform when used.")]
        public ItemAction[] Actions { get; private set; }

        public void OnValidate()
        {
            // Ensure MaxStackSize is at least 1
            if (MaxStackSize < 1)
            {
                MaxStackSize = 1;
            }

#if UNITY_EDITOR
#endif
        }
    }
}
