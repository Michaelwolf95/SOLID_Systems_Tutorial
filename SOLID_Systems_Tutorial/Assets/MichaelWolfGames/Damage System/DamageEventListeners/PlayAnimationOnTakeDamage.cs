using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    public class PlayAnimationOnTakeDamage : DamageEventListenerBase
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _stateName = "";

        protected override void DoOnTakeDamage(object sender, Damage.DamageEventArgs damageEventArgs)
        {
            if (_animator)
            {
                if (_stateName.Length > 0)
                {
                    _animator.Play(_stateName);
                }
            }
        }
    }
}