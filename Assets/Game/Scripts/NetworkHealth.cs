using System;
using Unity.Netcode;

namespace Game.World
{
    /// <summary>
    /// Networked health component that implements INetworkDamagable.
    /// </summary>
    public class NetworkHealth : NetworkBehaviour, INetworkDamagable
    {
        // Health value synchronized over the network
        public NetworkVariable<int> Health = new(100);

        // Public events
        public event Action<int, int> OnDamageTaken;
        public event Action<int, int> OnHealed;

        #region IDamagable Implementation

        public void Heal(int amount)
        {
            // Only the server should modify health
            if (!IsServer)
            {
                return;
            }

            int hp = Math.Clamp(Health.Value + amount, 0, 100);

            OnHealed?.Invoke(Health.Value, hp);
        }

        public void TakeDamage(int amount)
        {
            // Only the server should modify health
            if (!IsServer)
            {
                return;
            }

            int hp = Math.Clamp(Health.Value - amount, 0, 100);

            OnDamageTaken?.Invoke(Health.Value, hp);
        }

        #endregion
    }
}
