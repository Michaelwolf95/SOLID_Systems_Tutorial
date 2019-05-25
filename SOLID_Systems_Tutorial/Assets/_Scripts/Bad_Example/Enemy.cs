using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.Bad_Example
{
    // Example of BAD coding practices.
    // Enemy character.
    public class Enemy : MonoBehaviour
    {
        public float health = 25f;
        private bool isDead = false;

        public float damageValue = 25f;

        // Deal damage to the enemy.
        public void ApplyDamage(float damage)
        {
            if (isDead) return;

            health -= damage;

            if (health <= 0)
            {
                health = 0;
                isDead = true;
                DoDeathAnimation();

                AddScore(1);
            }
            else
                DoTakeDamageAnimation();
        }

        // Deal damage to the player on contact.
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                Player hp = col.gameObject.GetComponent<Player>();

                hp.ApplyDamage(damageValue);
            }
        }


        #region Dummy Methods
        private void DoDeathAnimation()
        {

        }

        private void AddScore(int score)
        {

        }

        private void DoTakeDamageAnimation()
        {

        }

        private void UpdateHealthBar()
        {

        }

        #endregion
    }
}