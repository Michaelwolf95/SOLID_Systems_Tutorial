using System;
using MichaelWolfGames.DamageSystem;
using UnityEngine;

namespace MichaelWolfGames.Examples
{
    /// <summary>
    /// Base class for Pickups used for the demos.
    /// Simply checks for a HealthManager in OnTriggerEnter, and calls DoOnPickedUp when it is.
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public abstract class PickupBase : MonoBehaviour
    {
        public bool DestroyOnPickup = true;
        protected bool IsPickedUp = false;
        public Action<HealthManagerBase> OnPickedUp = delegate { };

        protected abstract void DoOnPickedUp(HealthManagerBase healthManager);

        public void PickUp(HealthManagerBase healthManager)
        {
            DoOnPickedUp(healthManager);
            OnPickedUp(healthManager);
            IsPickedUp = true;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            var go = (other.attachedRigidbody) ? other.attachedRigidbody.gameObject : other.gameObject;
            if (TryPickUp(go))
            {
                if (DestroyOnPickup)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        protected virtual bool TryPickUp(GameObject target)
        {
            HealthManagerBase hm = target.GetComponent<HealthManagerBase>();
            if (hm != null)
            {
                if (CheckPickUpConditions(hm))
                {
                    PickUp(hm);
                    return true;
                }
            }

            return false;
        }

        protected virtual bool CheckPickUpConditions(HealthManagerBase healthManager)
        {
            return !IsPickedUp;
        }


    }
}