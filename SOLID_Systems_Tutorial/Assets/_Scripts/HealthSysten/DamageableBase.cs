using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.HealthSystem
{
    public abstract class DamageableBase : MonoBehaviour, IDamageable
    {
        // Hide the field used by the property.
        private DamageEventHandler _onTakeDamageEvent = delegate { };
        public DamageEventHandler OnTakeDamageEvent
        {
            get { return _onTakeDamageEvent; }
            set { _onTakeDamageEvent = value; }
        }
        // Abstract declaration of ApplyDamage from interface.
        public abstract void ApplyDamage(object sender, float damage);
    }
}
