using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_Tutorial.Bad_Example
{
    // Example of BAD coding practices (part 1)
    public class PlayerHealth : MonoBehaviour
    {
        public float health = 100f;
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

                RestartLevel();
            }
            else
                DoTakeDamageAnimation();

            UpdateHealthBar();
        }

        #region Dummy Methods
        private void DoDeathAnimation()
        {

        }

        private void RestartLevel()
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