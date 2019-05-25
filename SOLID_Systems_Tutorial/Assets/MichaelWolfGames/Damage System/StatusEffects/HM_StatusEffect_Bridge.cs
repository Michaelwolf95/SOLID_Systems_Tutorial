using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem.StatusEffects
{
    public class HM_StatusEffect_Bridge : HealthManagerEventListenerBase
    {
        [SerializeField] protected StatusEffectManager statusManager;

        protected override void DoOnInitialize()
        {
            base.DoOnInitialize();
            if(statusManager == null)
            {
                statusManager = SubscribableObject.GetComponent<StatusEffectManager>();
            }
            // else ...
        }

        protected override void DoOnDeath()
        {
            if (statusManager != null)
            {
                statusManager.ClearAllStatusEffects();
            }
        }

        protected override void DoOnRevive()
        {
            if (statusManager != null)
            {
                statusManager.ClearAllStatusEffects();
            }
        }

        protected override void DoOnTakeDamage(object sender, Damage.DamageEventArgs damageEventArgs)
        {
            // Nothing
        }
    }
}