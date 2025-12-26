using UnityEngine;

namespace Game.World
{
    /// <summary>
    /// Interface for objects that can be interacted with.
    /// </summary>
    public interface IInteractable
    {
        void Interact(GameObject source, GameObject target);
    }
}
