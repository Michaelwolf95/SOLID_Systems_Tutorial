using System;
using System.Collections.Generic;
using UnityEngine;
using MichaelWolfGames.MeterSystem;

namespace MichaelWolfGames.DamageSystem.StatusEffects
{
    /// <summary>
    /// UI icon associated with status effects.
    /// 
    /// Michael Wolf
    /// October, 2018
    /// </summary>
    public class StatusEffectIcon : MonoBehaviour
    {
        public StatusEffectBase statusEffect;

        public MeterBase[] meters;

        public Action OnInitialized = delegate { };

        public void Initialize(StatusEffectBase statEffect)
        {
            if (statusEffect != null)
            {
                Debug.LogWarning("Status Effect was already assigned!");
            }
            statusEffect = statEffect;

            // Attach meters
            if (meters.Length > 0 && typeof(IMeterable).IsAssignableFrom(statusEffect.GetType()))
            {
                IMeterable m = statusEffect as IMeterable;
                foreach (MeterBase meter in meters)
                {
                    meter.SetMeterable(m);
                }
            }

            OnInitialized();
        }

        public virtual void OnStatusRemoved()
        {

        }


    }
}
