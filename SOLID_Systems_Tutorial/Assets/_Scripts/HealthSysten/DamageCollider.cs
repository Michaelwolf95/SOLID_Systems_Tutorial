using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.HealthSystem
{
    public class DamageCollider : MonoBehaviour
    {
        [SerializeField] protected float damageValue = 25f;

        private void OnCollisionEnter(Collision col)
        {
            IDamageable dam = col.gameObject.GetComponent<IDamageable>();
            if(dam != null)
            {
                dam.ApplyDamage(this, damageValue);
            }
        }
    }
}
