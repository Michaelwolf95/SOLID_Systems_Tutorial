using UnityEngine;
using System.Collections;
namespace SOLID_Tutorial.Bad_Example
{
    // Example of BAD coding practices.
    // The players sword. Turned on during attacks.
    public class PlayerSword : MonoBehaviour
    {
        public float damageValue = 25f;

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Enemy hp = col.gameObject.GetComponent<Enemy>();

                hp.ApplyDamage(damageValue);
            }
        }
    }
}
