using UnityEngine;

namespace DrekGame.Systems
{
    public class BillBoard : MonoBehaviour
    {
        [field: SerializeField]
        private Transform _cameraTransform;

        private void Start()
        {
            if (_cameraTransform == null && Camera.main != null)
            {
                _cameraTransform = Camera.main.transform;
            }
        }

        private void LateUpdate()
        {
            if (_cameraTransform != null)
            {
                transform.LookAt(transform.position + (_cameraTransform.rotation * Vector3.forward),
                    _cameraTransform.rotation * Vector3.up);
            }
        }
    }
}
