using System;
using UnityEngine;

namespace DrekGame.Inventory.Actions
{
    /// <summary>
    /// Base class for any effect an item can trigger.
    /// </summary>
    [Serializable]
    public abstract class ItemAction
    {
        /// <summary>
        /// Executes the item action.
        /// </summary>
        /// <param name="user">The GameObject that is using the item.</param>
        /// <param name="target">The GameObject that is being targeted by the item.</param>
        public abstract void Execute(GameObject user, GameObject target);
    }
}
