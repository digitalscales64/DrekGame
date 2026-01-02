using System;
using UnityEngine;

namespace DrekGame.Inventory.Database
{
    /// <summary>
    /// Pairing of an item definition with its unique integer ID.
    /// </summary>
    [Serializable]
    public class ItemValuePair
    {
        [field: SerializeField]
        public ItemDefinition Item { get; private set; }
        [field: SerializeField]
        public int Value { get; private set; }

        public ItemValuePair(ItemDefinition item, int value)
        {
            Item = item;
            Value = value;
        }
    }
}
