using MichaelWolfGames.DamageSystem;
using UnityEngine;

namespace MichaelWolfGames.Examples
{
    /// <summary>
    /// Childs a Prefab object to the healthmanager that picks it up.
    /// This is useful for adding shields, resistances, etc, since they auto-subscribe when they are created.
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public class ComponentPickup : PickupBase
    {
        public GameObject ShieldPrefab;
        protected override void DoOnPickedUp(HealthManagerBase healthManager)
        {
            var go = GameObject.Instantiate(ShieldPrefab, healthManager.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
        }
    }
}