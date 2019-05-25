using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Base class implementation of the IDamagable Interface.
    /// Hosts a helper function that wraps values in a Damage.DamageEventArgs before calling OnTakeDamage.
    /// 
    /// Michael Wolf
    /// April 8, 2017
    /// </summary>
    public abstract class DamageableBase : MonoBehaviour, IDamageable
    {
        public Damage.Faction Faction = Damage.Faction.Enemy;
        public event Damage.DamageEventHandler OnTakeDamage = delegate { };
        public event Damage.DamageEventMutator MutateDamage = delegate(object sender, ref Damage.DamageEventArgs args) {  };

        public virtual void ApplyDamage(object sender, ref Damage.DamageEventArgs args)
        {
            MutateDamage(sender, ref args);
            OnTakeDamage(sender, args);
        }
        public virtual void ApplyDamage(object sender, float damage, Vector3 hitPoint)
        {
            var args = new Damage.DamageEventArgs(damage, hitPoint);
            ApplyDamage(sender, ref args);
        }

        public virtual void ApplyDamage(float damage)
        {
            var args = new Damage.DamageEventArgs(damage, this.transform.position);
            ApplyDamage(this, ref args);
        }

        public virtual Damage.Faction GetFaction()
        {
            return Faction;
        }

        //From https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes
        //The event-invoking method that derived classes can override.
        protected virtual void InvokeOnTakeDamage(object sender, Damage.DamageEventArgs args)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            Damage.DamageEventHandler handler = OnTakeDamage;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        protected virtual void InvokeMutateDamage(object sender, ref Damage.DamageEventArgs args)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            Damage.DamageEventMutator handler = MutateDamage;
            if (handler != null)
            {
                handler(this, ref args);
            }
        }

    }
}