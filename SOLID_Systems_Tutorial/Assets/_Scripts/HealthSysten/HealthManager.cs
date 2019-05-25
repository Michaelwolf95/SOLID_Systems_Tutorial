using UnityEngine;
using System.Collections;
using System;
namespace SOLID_Tutorial.HealthSystem
{
    public class HealthManager : DamageableBase
    {
        [SerializeField] protected float maxHealth = 100f;
        [SerializeField] protected float currentHealth = 100f;

        protected bool isDead = false;

        public Action OnDeathEvent = delegate { };

        public override void ApplyDamage(object sender, float damage)
        {
            if (isDead) return;

            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                currentHealth = 0f;
                isDead = true;

                OnDeathEvent();
            }

            OnTakeDamageEvent(sender, damage);
        }
    }
}
