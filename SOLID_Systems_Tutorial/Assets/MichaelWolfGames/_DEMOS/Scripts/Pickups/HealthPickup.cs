using MichaelWolfGames.DamageSystem;
using UnityEngine;

namespace MichaelWolfGames.Examples
{
    /// <summary>
    /// Simple Health Pickup
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public class HealthPickup : PickupBase
    {
        public float HealthValue = 25f;
        protected override void DoOnPickedUp(HealthManagerBase healthManager)
        {
            healthManager.AddHealth(HealthValue);
        }

        protected override bool CheckPickUpConditions(HealthManagerBase healthManager)
        {
            if (healthManager.IsDead) return false;
            if (healthManager.PercentValue >= 1f)
            {
                return false;
            }

            return base.CheckPickUpConditions(healthManager);
        }
    }
}