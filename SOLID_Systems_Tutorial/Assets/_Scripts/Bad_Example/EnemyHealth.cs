using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.Bad_Example
{
    // Example of BAD coding practices (part 2)
    public class EnemyHealth : MonoBehaviour
    {
        public float health = 25f;
        private bool isDead = false;

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