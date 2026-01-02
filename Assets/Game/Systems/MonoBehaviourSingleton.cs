using UnityEngine;

namespace DrekGame.Systems
{
    /// <summary>
    /// A generic singleton pattern for MonoBehaviour classes.
    /// Ensures only one instance exists and provides global access.
    /// </summary>
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Accessible singleton instance
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            // Check for existing instance
            if (Instance != null && Instance != (this as T))
            {
#if UNITY_EDITOR
                Debug.LogWarning($"Multiple instances of singleton {typeof(T).Name} detected. Destroying duplicate.");
#endif

                Destroy(gameObject);
                return;
            }

            // Assign the instance and don't destroy between scenes
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}
