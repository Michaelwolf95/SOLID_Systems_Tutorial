using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Tells the Animator to play animations in the animator based on HealthManager events.
    /// 
    /// Michael Wolf
    /// </summary>
    public class HM_PlayAnimation : HealthManagerEventListenerBase
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _takeDamageState = "";
        [SerializeField] private string _deathState = "";
        [SerializeField] private string _reviveState = "";

        protected override void DoOnTakeDamage(object sender, Damage.DamageEventArgs damageEventArgs)
        {
            PlayAnimation(_takeDamageState);
        }

        protected override void DoOnDeath()
        {
            PlayAnimation(_deathState);
        }

        protected override void DoOnRevive()
        {
            PlayAnimation(_reviveState);
        }

        private void PlayAnimation(string stateName)
        {
            if (_animator && stateName.Length > 0)
            {
                _animator.Play(stateName, 0, 0f);
            }
        }
    }
}