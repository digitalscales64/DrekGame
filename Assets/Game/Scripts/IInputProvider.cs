using UnityEngine;

namespace Game.Movement
{
    /// <summary>
    /// Interface for input providers to supply movement and interaction inputs.
    /// </summary>
    public interface IInputProvider
    {
        Vector2 MovementInput { get; }
        bool AttackInput { get; }
        bool InteractionInput { get; }
    }
}
