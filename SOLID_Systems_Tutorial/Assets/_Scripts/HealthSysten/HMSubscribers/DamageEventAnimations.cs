using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.HealthSystem
{
    public class DamageEventAnimations : HealthManagerEventSubscriberBase
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string damageAnimTrigger = "TAKE_DAMAGE";
        [SerializeField] private string deathAnimTrigger = "DEATH";

        protected override void OnTakeDamage(object sender, float damage)
        {
            animator.Play(damageAnimTrigger);
        }
        protected override void OnDeath()
        {
            animator.Play(deathAnimTrigger);
        }
    }
}
