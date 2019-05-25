using UnityEngine.Events;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Exposes HealthManager events as UnityEvents.
    /// This is great for producing fast results.
    /// 
    /// Michael Wolf
    /// February 2018
    /// </summary>
    public class HM_UnityEvents : HealthManagerEventListenerBase
    {
        public UnityEvent OnTakeDamageEvent;
        public UnityEvent OnDeathEvent;
        public UnityEvent OnReviveEvent;

        protected override void DoOnTakeDamage(object sender, Damage.DamageEventArgs e)
        {
            OnTakeDamageEvent.Invoke();
        }

        protected override void DoOnDeath()
        {
            OnDeathEvent.Invoke();
        }

        protected override void DoOnRevive()
        {
            OnReviveEvent.Invoke();
        }
    }
}