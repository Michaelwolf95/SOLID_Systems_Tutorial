using UnityEngine;
using System.Collections;

namespace MichaelWolfGames.DamageSystem.StatusEffects
{
    /// <summary>
    /// 
    /// 
    /// Michael Wolf
    /// October, 2018
    /// </summary>
    public class StatusEffectTester : MonoBehaviour
    {
        public StatusEffectBase statusEffectAsset;
        public StatusEffectManager target;
        public StatusEffectBase instance;

        private void Start()
        {
            instance = null;
        }
        public void ApplyStatusEffect()
        {
            instance = target.AddStatusEffect(statusEffectAsset);
        }
        public void RemoveStatusEffect()
        {
            if (instance != null)
            {
                target.RemoveStatusEffect(instance);
                instance = null;
            }

        }

    }
}