using DrekGame.Systems;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

namespace DrekGame.Character
{
    /// <summary>
    /// Defines the possible states of an entity.
    /// </summary>
    public enum EntityState
    {
        Idle,
        Moving,
        Dead
    }

    public class EntityController : NetworkBehaviour
    {
        /// <summary>
        /// The current state of the entity, synchronized across the network.
        /// </summary>
        public NetworkVariable<EntityState> State { get; private set; } = new();

        #region Movement Fields
        public NetworkVariable<Vector3> TargetPosition { get; private set; } = new();

        [SerializeField]
        private NavMeshAgent _navMeshAgent;

        #endregion

        public override void OnNetworkSpawn()
        {
            // Return if not server
            if (!IsServer) return;

            // Assign nav mesh only on server
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Movement()
        {
            
        }
    }
}
