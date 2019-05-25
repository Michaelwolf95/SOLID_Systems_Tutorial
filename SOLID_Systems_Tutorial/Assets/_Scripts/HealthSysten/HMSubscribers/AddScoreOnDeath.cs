using UnityEngine;
using System.Collections;

namespace SOLID_Tutorial.HealthSystem
{
    public class AddScoreOnDeath : HealthManagerEventSubscriberBase
    {
        public int scoreValue = 1;

        protected override void OnTakeDamage(object sender, float damage)
        {
            // Nothing
        }
        protected override void OnDeath()
        {
            // Add Score.
        }
    }
}