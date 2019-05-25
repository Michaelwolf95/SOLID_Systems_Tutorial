using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Sub-Health Pool for Shields.
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public class HealthShield : DamageEventMutatorBase
    {
        [SerializeField] protected HealthManagerBase ShieldHealth;

        public HealthManagerBase Health { get { return ShieldHealth;} }

        public Action OnShieldActivated = delegate { };
        public Action OnShieldDestroyed = delegate { };

        public override void MutateDamageEvent(object sender, ref Damage.DamageEventArgs args)
        {
            if(ShieldHealth.IsDead) return;
            var healthBefore = ShieldHealth.CurrentHealth;
            ShieldHealth.ApplyDamage(sender, ref args);
            if (ShieldHealth.IsDead)
            {
                var overflow = args.DamageValue - healthBefore;
                args.DamageValue = overflow;
                OnShieldDestroyed();
                this.enabled = false; 
            }
            else
            {
                args.DamageValue = 0f;
            }
        }

        protected override void FetchSubscribableObject()
        {
            if (!ShieldHealth)
            {
                var hm = this.GetComponent<HealthManagerBase>();
                if (hm)
                    if (hm != SubscribableObject)
                        ShieldHealth = hm;
                if (!ShieldHealth)
                {
                    ShieldHealth = this.gameObject.AddComponent<HealthManager>();
                }
            }
            var hms = GetComponentsInParent<HealthManagerBase>();
            foreach (var hm in hms)
            {
                if (hm != ShieldHealth)
                {
                    SubscribableObject = hm;
                }
            }
        }

        protected override void Start()
        {
            base.Start();
            if (ShieldHealth)
            {
                ShieldHealth.OnRevive += ReActivateShield;
                OnShieldActivated();
            }
        }

        protected virtual void OnDestroy()
        {
            ShieldHealth.OnRevive -= ReActivateShield;
            OnShieldDestroyed();
        }

        protected void ReActivateShield()
        {
            this.enabled = true;
            OnShieldActivated();
        }

    }
}