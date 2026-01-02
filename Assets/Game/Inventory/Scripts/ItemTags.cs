using System;

namespace DrekGame.Inventory
{
    /// <summary>
    /// Tags that can be assigned to items for categorization.
    /// </summary>
    [Flags]
    public enum ItemTags
    {
        None = 0,
        Consumable = 2,
        Weapon = 4,
        Potion = 8,
        QuestItem = 16,
        Ammunition = 32,
    }
}
