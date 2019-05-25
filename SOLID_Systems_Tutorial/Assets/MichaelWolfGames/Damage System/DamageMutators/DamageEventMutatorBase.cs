using System;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Base class for DamageMutators.
    /// DamageMutators modify DamageEventArgs as they are received my Damageables, before Damage is applied.
    /// The most common use of this is changing the damage value argument, but other args can be changed as well.
    /// 
    /// ToDo: Restructure system to have a finer control of the order in which mutators are applied.
    ///     Perhaps have a "controller" mutator with a public array of other mutators.
    ///     This class would unsubscribe other mutators, and invoke their MutateDamageEvent method itself.
    ///     OR - just have a "priority" value associated with each mutator, and subscribe to the HM via a List.
    /// Michael Wolf
    /// January, 2018
    /// </summary>
    public abstract class DamageEventMutatorBase : SubscriberBase<DamageableBase>
    {
        // Just "renames" the SubscribableObject for clarity.
        public DamageableBase Damageable { get { return SubscribableObject; } }

        protected override void SubscribeEvents()
        {
            Damageable.MutateDamage += MutateDamageEvent;
        }

        protected override void UnsubscribeEvents()
        {
            Damageable.MutateDamage -= MutateDamageEvent;
        }

        public abstract void MutateDamageEvent(object sender, ref Damage.DamageEventArgs args);

    }
}