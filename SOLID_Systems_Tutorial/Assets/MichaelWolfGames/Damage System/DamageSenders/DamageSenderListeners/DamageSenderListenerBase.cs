using UnityEngine;

namespace MichaelWolfGames.DamageSystem.DamageSenderListeners
{
    /// <summary>
    /// Base class for defining DamageSenderListeners, which respond to OnDealDamage events from DamageSenders.
    /// 
    /// Michael Wolf
    /// February 2018
    /// </summary>
    public abstract class DamageSenderListenerBase : SubscriberBase<DamageSenderBase>
    {
        // This just "renames" the SubscribableObject for simplicity.
        public DamageSenderBase DamageSender { get { return SubscribableObject; } }

        protected override void SubscribeEvents()
        {
            DamageSender.OnDealDamage += DoOnDealDamage;
        }

        protected override void UnsubscribeEvents()
        {
            DamageSender.OnDealDamage -= DoOnDealDamage;
        }

        protected abstract void DoOnDealDamage(object sender, Damage.DamageEventArgs args);
    }
}