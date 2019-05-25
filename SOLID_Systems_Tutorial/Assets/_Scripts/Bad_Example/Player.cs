using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_Tutorial.Bad_Example
{
    // Example of BAD coding practices.
    public class Player : MonoBehaviour
    {
        #region Movement Variables ...

        #endregion
        private bool isAttacking = false;

        public float health = 100f;
        private bool isDead = false;

        private void Update()
        {
            // Just assume this works.
            UpdateMovement();

            // Attack on click.
            if (isAttacking == false)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    // Starts attack animation 
                    // and sets "isAttacking"
                    DoSwordAttack();
                }
            }
        }

        // Deal damage to the player.
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
        // None of these actually do anything.
        private void DoDeathAnimation() { }
        private void RestartLevel() { }
        private void DoTakeDamageAnimation() { }
        private void UpdateHealthBar() { }

        private void DoSwordAttack() { }
        private void UpdateMovement() { }

        #endregion
    }
}