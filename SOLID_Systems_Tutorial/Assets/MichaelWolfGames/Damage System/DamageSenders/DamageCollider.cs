using System;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// DamageSender that sends damage events via OnCollisionEnter.
    /// This is also used as the base class for all physical based damage senders. 
    /// For Triggers, see the DamageTrigger class, which extends from this.
    /// 
    /// Michael Wolf
    /// April, 2017
    /// </summary>
    public class DamageCollider : DamageSenderBase
	{
        public Action OnDealDamageSuccessEvent = delegate { };
        public Action OnDealDamageFailedEvent = delegate { };

        public bool DealDamageOncePerActivation = false;

        protected virtual void OnCollisionEnter(Collision other)
        {
            if (TryDealDamage(other.gameObject, GetDamageEventArgumentsFromCollision(other)))
            {
                OnDealDamageSuccess();
                if (DealDamageOncePerActivation)
                {
                    CanDealDamage = false;
                }
            }
            else
            {
                OnDealDamageFailed();
            }
        }

        protected virtual void OnEnable()
        {
            if (DealDamageOncePerActivation)
                CanDealDamage = true;
        }

        protected virtual void OnDealDamageSuccess()
        {
            OnDealDamageSuccessEvent();
        }

        protected virtual void OnDealDamageFailed()
        {
            OnDealDamageFailedEvent();
        }

        protected virtual Damage.DamageEventArgs GetDamageEventArgumentsFromCollision(Collision collision)
        {
            return new Damage.DamageEventArgs(DamageValue, collision.contacts[0].point, damageType, faction);
        }
    }
}