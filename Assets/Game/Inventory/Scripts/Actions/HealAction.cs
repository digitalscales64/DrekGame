using System;
using DrekGame.Systems;
using UnityEngine;

namespace DrekGame.Inventory.Actions
{
    /// <summary>
    /// An item action that heals the user when executed.
    /// </summary>
    [Serializable]
    public class HealAction : ItemAction
    {
        [field: SerializeField] 
        public int HealAmount { get; private set; }

        #region ItemAction Implementation

        /// <summary>
        /// Increases the health of the user by HealAmount.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target">The GameObject that is being targeted by the item.</param>
        public override void Execute(GameObject user, GameObject target)
        {
            if (user == null)
            {
                #if UNITY_EDITOR
                Debug.LogWarning("[HealAction] The user GameObject is null. HealAction cannot be executed.");
                #endif
                
                return;
            }

            var damageable = user.GetComponent<IDamageable>();
            if (damageable == null)
            {
                #if UNITY_EDITOR
                Debug.LogWarning($"[HealAction] The user {user} does not implement IDamageable. HealAction cannot be executed.");
                #endif
                
                return;
            }

            #if UNITY_EDITOR
            Debug.Log($"[HealAction] Executing HealAction on {user.name}, healing for {HealAmount} HP.");
            #endif

            //damageable.Heal(itemID, Source.POTION, HealAmount);
        }

        #endregion
    }
}
