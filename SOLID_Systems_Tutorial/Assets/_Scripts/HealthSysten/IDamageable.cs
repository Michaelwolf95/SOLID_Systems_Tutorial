using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.HealthSystem
{
    // Delegate for handling Damage Events.
    public delegate void DamageEventHandler(object sender, float damage);

    public interface IDamageable
    {
        // Deal damage to this object.
        void ApplyDamage(object sender, float damage);

        // Event for when damage happens.
        DamageEventHandler OnTakeDamageEvent { get; set; }
    }
}
