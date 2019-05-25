using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.Bad_Example
{
    // Example of BAD coding practices (part 3)
    // This script deals damage to BOTH the Player and Enemies.
    public class DamageSpikes : MonoBehaviour
    {
        public float damageValue = 25f;

        private void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.tag == "Player")
            {
                Player hp = col.gameObject.GetComponent<Player>();
                hp.ApplyDamage(damageValue);
            }
            else if (col.gameObject.tag == "Enemy")
            {
                Enemy hp = col.gameObject.GetComponent<Enemy>();
                hp.ApplyDamage(damageValue);
            }
        }
    }
}
