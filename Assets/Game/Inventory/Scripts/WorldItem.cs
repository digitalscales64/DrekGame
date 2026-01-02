using DrekGame.Systems;
using TMPro;
using Unity.Netcode;
using UnityEngine;

namespace DrekGame.Inventory
{
    /// <summary>
    /// Represents a networked item in the game world.
    /// </summary>
    public class WorldItem : NetworkBehaviour, IInteractable
    {
        [field: SerializeField]
        public ItemDefinition Item { get; private set; }

        [field: SerializeField]
        public int Quantity { get; private set; } = 1;

        [SerializeField]
        private TMP_Text _itemText;

        private void Start()
        {
            // Ensure quantity is at least 1
            if (Quantity < 1)
            {
                Quantity = 1;
            }

            if (Item != null)
            {
                // Assign Sprite
                SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = Item.Icon;
                }

                // Update Text
                if (_itemText != null)
                {
                    // Prepare text as "Item_Name (100)" if quantity > 1
                    string msg = $"{Item.Name} {(Quantity > 1 ? $"({Quantity.ToString()})" : string.Empty)}";
                    _itemText.text = msg;
                }
            }
        }

        #region IInteractable Implementation

        [field: SerializeField]
        public bool IsInteractable { get; private set; }

        [field: SerializeField]
        public string InteractionPrompt { get; private set; } = "Pick up item";

        public void Interact(GameObject interactor)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
