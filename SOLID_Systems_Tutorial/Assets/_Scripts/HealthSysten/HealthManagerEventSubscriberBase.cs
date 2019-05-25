using UnityEngine;
using System.Collections;


namespace SOLID_Tutorial.HealthSystem
{
    // Base class for all subscribers to healthmanager.
    public abstract class HealthManagerEventSubscriberBase : MonoBehaviour
    {
        [SerializeField] protected HealthManager owner;

        protected virtual void Awake() {
            if(owner == null) owner = GetComponent<HealthManager>();
        }
        // Connect/Disconnect from owner.
        protected virtual void OnEnable() {
            if (owner != null) {
                owner.OnTakeDamageEvent += OnTakeDamage;
                owner.OnDeathEvent += OnDeath;
            }
        }
        protected virtual void OnDisable() {
            if (owner != null) {
                owner.OnTakeDamageEvent -= OnTakeDamage;
                owner.OnDeathEvent -= OnDeath;
            }
        }

        protected abstract void OnTakeDamage(object sender, float damage);
        protected abstract void OnDeath();
    }
}
