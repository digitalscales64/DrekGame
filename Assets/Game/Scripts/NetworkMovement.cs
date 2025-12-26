using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Game.Movement
{
    public class NetworkMovement : NetworkBehaviour
    {
        // Target position synchronized over the network
        public NetworkVariable<Vector3> TargetPosition = new();
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private string _playerInputName = "Player Input";
        [SerializeField] private string _attackActionName = "Attack";
        private InputAction _attackAction;

        private void Awake()
        {
            _navMeshAgent = _navMeshAgent != null ? _navMeshAgent : GetComponent<NavMeshAgent>();
        }

        public override void OnNetworkSpawn()
        {
            // Only the server should control movement
            if (IsServer)
            {
                TargetPosition.OnValueChanged += OnTargetPositionChanged;
            }

            // find the player input actions
            if (IsClient)
            {
                PlayerInput inputComponent = GameObject.Find(_playerInputName).GetComponent<PlayerInput>();
                _attackAction = inputComponent.actions[_attackActionName];

                // Subscribe to the attack action
                _attackAction.performed += OnClickPerformed;
            }
        }

        public override void OnNetworkDespawn()
        {
            if (IsServer)
            {
                TargetPosition.OnValueChanged -= OnTargetPositionChanged;
            }

            if (IsClient)
            {
                _attackAction.performed -= OnClickPerformed;
            }
        }

        public void OnTargetPositionChanged(Vector3 previousValue, Vector3 newValue)
        {
            _ = _navMeshAgent.SetDestination(newValue);
        }

        private void OnClickPerformed(InputAction.CallbackContext context)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                SetTargetPositionServerRpc(hit.point);
            }
        }

        // Request to set target position on the server
        [ServerRpc]
        private void SetTargetPositionServerRpc(Vector3 position)
        {
            TargetPosition.Value = position;
        }
    }
}
