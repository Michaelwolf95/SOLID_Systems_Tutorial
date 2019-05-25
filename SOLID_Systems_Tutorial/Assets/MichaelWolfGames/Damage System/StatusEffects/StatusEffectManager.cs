using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem.StatusEffects
{

    /// <summary>
    /// The SEF attaches to a damageable and manages all status effects that can be attached to it.
    /// 
    /// Michael Wolf
    /// October, 2018
    /// </summary>
    public class StatusEffectManager : MonoBehaviour
    {
        // Maybe this doesn't need to be connected to the damageable?
        //[SerializeField] protected DamageableBase damageable;
        public Action<StatusEffectBase> OnStatusEffectAdded = delegate (StatusEffectBase status) { };
        public Action<StatusEffectBase> OnStatusEffectRemoved = delegate (StatusEffectBase status) { };

        public List<StatusEffectBase> statusEffects = new List<StatusEffectBase>();


        public StatusEffectBase AddStatusEffect(StatusEffectBase statusEffectAsset)
        {
            // ToDo: Check if asset file ref

            var instance = statusEffectAsset.CreateRuntimeInstance();
            statusEffects.Add(instance);
            instance.Initialize(this);
            instance.OnStatusApplied();
            OnStatusEffectAdded(instance);
            return instance;
        }

        public void RemoveStatusEffect(StatusEffectBase statusEffectInstance)
        {
            if(statusEffects.Contains(statusEffectInstance))
            {
                statusEffects.Remove(statusEffectInstance);
                OnStatusEffectRemoved(statusEffectInstance);

                // Called last because it might be destroyed.
                statusEffectInstance.OnStatusRemoved(); 
            }
        }

        public void ClearAllStatusEffects()
        {
            StatusEffectBase[] statuses = statusEffects.ToArray();
            foreach (StatusEffectBase status in statuses)
            {
                RemoveStatusEffect(status);
            }
        }

    }
}