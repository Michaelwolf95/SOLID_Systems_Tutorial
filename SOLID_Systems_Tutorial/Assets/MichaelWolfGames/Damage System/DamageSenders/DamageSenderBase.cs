using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Base class to be used for sending damage to IDamagables.
    /// Contains a TryDealDamage method that looks for an IDamagable on a target gameobject, 
    /// and calls it's ApplyDamageEvent if it finds one.
    /// 
    /// Michael Wolf
    /// April 8, 2017
    /// </summary>
    public abstract class DamageSenderBase : MonoBehaviour
    {
        [SerializeField] protected float defaultDamageValue = 1f;
        [SerializeField] protected Damage.Faction faction = Damage.Faction.Player;
        [SerializeField] protected Damage.DamageType damageType = Damage.DamageType.Default;
        [SerializeField] private bool _canDealDamage = true;

        //protected float damageValue
        public event Damage.DamageEventHandler OnDealDamage = delegate(object sender, Damage.DamageEventArgs args) {  };

        /// <summary>
        /// Property for DamageValue.
        /// Override this to Calculate DamageValue based on current conditions, 
        /// OR simply call TryDealDamage with your own check method,
        /// OR use DamageEventMutators, for a more dynamic system.
        /// </summary>
        public virtual float DamageValue
        {
            get { return defaultDamageValue; }
            protected set { defaultDamageValue = value; }
        }

        public bool CanDealDamage
        {
            get { return _canDealDamage; }
            protected set { _canDealDamage = value; }
        }

        public void ToggleCanDealDamage(bool state)
        {
            if (state != CanDealDamage)
            {
                OnToggleCanDealDamage(state);
                CanDealDamage = state;
            }
        }
        public void SetDamageValue(float damageValue)
        {
            DamageValue = damageValue;
        }
        public void SetDamageType(Damage.DamageType type)
        {
            damageType = type;
        }

        protected virtual void OnToggleCanDealDamage(bool state)
        {
            // Override this for specific functionality for when the damage sender is toggled on and off.
        }

        /// <summary>
        /// Checks for an IDamagable on the target GameObject, then attempts to call its ApplyDamage method.
        /// If an IDamagable isn't found, returns false.
        /// </summary>
        /// <param name="damageTarget"> The Target to look for an IDamagable on.</param>
        /// <param name="args"> Damage Event Arguments.</param>
        /// <returns></returns>
        public virtual bool TryDealDamage(GameObject damageTarget, Damage.DamageEventArgs args)
        {
            if (!CanDealDamage) return false;
            if (args.DamageValue <= 0) return false;
            IDamageable damageable = damageTarget.GetComponent<IDamageable>();
            if (damageable != null)
            {
                if (this.faction == damageable.GetFaction() && !Damage.FriendlyFireEnabled)
                    return false;

                // By using a ref parameter, we can see the results of the damage delt after it has been changed by resistances and multipliers.
                damageable.ApplyDamage(this, ref args);
                if (args.DamageValue > 0) 
                {
                    OnDealDamage(damageable, args);
                    return true;
                }
            }
            // No IDamagable Found - Return false.
            return false;
        }

        #region TryDealDamage Helper Methods

        public virtual bool TryDealDamage(GameObject damageTarget)
        {
            return TryDealDamage(damageTarget, DamageValue);
        }

        public virtual bool TryDealDamage(GameObject damageTarget, float damage, Vector3? hitPoint = null)
        {
            Vector3 point = (hitPoint != null) ? (Vector3)hitPoint : transform.position;        // Default on transform position if no hitPoint is set.
            Damage.DamageEventArgs e = new Damage.DamageEventArgs(damage, point, damageType, faction);
            return TryDealDamage(damageTarget, e);
        }
        #endregion
    }
}