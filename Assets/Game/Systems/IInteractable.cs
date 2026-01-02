using UnityEngine;

namespace DrekGame.Systems
{
    /// <summary>
    /// Interface for interactable objects in the game world.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Method to be called when the player interacts with the object.  
        /// </summary>
        void Interact(GameObject interactor);

        /// <summary>
        /// Checks if the object is currently interactable.
        /// </summary>
        bool IsInteractable { get; }

        /// <summary>
        /// Gets the interaction prompt text.
        /// </summary>
        string InteractionPrompt { get; }
    }
}
