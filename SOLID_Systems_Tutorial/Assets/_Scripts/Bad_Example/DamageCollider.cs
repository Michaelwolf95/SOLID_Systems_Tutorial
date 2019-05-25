using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.Bad_Example
{
    // Example of BAD coding practices (part 3)
    // This script deals damage to BOTH the Player and Enemies.
    public class DamageCollider : MonoBehaviour
    {
        public float damageValue = 25f;
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
                hp.ApplyDamage(damageValue);
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                EnemyHealth hp = collision.gameObject.GetComponent<EnemyHealth>();
                hp.ApplyDamage(damageValue);
            }
        }
    }
}