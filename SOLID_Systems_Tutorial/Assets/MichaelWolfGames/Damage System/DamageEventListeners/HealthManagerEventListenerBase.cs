using System;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Base class for defining HealthManagerEventListeners, which respond to events from HealthManagers:
    /// OnTakeDamage, OnDeath, and OnRevive.
    /// 
    /// Michael Wolf
    /// February 2018
    /// </summary>
    public abstract class HealthManagerEventListenerBase : SubscriberBase<HealthManagerBase>
    {
        // This just "renames" the SubscribableObject for simplicity.
        public HealthManagerBase HealthManager { get { return SubscribableObject; } }

        protected override void SubscribeEvents()
        {
            HealthManager.OnTakeDamage += DoOnTakeDamage;
            HealthManager.OnDeath += DoOnDeath;
            HealthManager.OnRevive += DoOnRevive;
        }

        protected override void UnsubscribeEvents()
        {
            HealthManager.OnTakeDamage -= DoOnTakeDamage;
            HealthManager.OnDeath -= DoOnDeath;
            HealthManager.OnRevive -= DoOnRevive;

        }

        // These don't NEED to be overridden by the end-user, they are abstract instead of virtual for clarity.
        // It's up to the end-user to decide if they will be empty.
        protected abstract void DoOnTakeDamage(object sender, Damage.DamageEventArgs damageEventArgs);
        protected abstract void DoOnDeath();
        protected abstract void DoOnRevive();
    }
}