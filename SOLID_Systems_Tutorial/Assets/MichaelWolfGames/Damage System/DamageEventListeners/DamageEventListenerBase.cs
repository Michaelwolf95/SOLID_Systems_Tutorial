using System;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Base class for defining DamageEventListeners, 
    /// which respond to events OnTakeDamage events from Damageables.
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public abstract class DamageEventListenerBase : SubscriberBase<DamageableBase>
    {
        // Just "renames" the SubscribableObject for clarity.
        public DamageableBase Damageable { get { return SubscribableObject; } }

        protected override void SubscribeEvents()
        {
            Damageable.OnTakeDamage += DoOnTakeDamage;
        }

        protected override void UnsubscribeEvents()
        {
            Damageable.OnTakeDamage -= DoOnTakeDamage;
        }

        protected abstract void DoOnTakeDamage(object sender, Damage.DamageEventArgs damageEventArgs);

    }
}