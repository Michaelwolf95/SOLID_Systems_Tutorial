using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.HealthSystem
{
    public class DestructableObject : HealthManagerEventSubscriberBase
    {
        protected override void OnTakeDamage(object sender, float damage)
        {
            Debug.Log("Destruct!");
            Destroy(this.gameObject);
        }
        protected override void OnDeath()
        {
            // Nothing
        }
    }
}
