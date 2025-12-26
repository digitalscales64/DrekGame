using System;
using Unity.Netcode;
using UnityEngine;

namespace Game.Movement
{
    public class Cameramanager : MonoBehaviour
    {
        // Singleton implementation
        private static Lazy<Cameramanager> _instance = new Lazy<Cameramanager>(() => new Cameramanager());
        public static Cameramanager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public Action<GameObject> OnCameraChanged;

        public void Start()
        {
            // Get 
        }
    }
}
