using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace SOLID_Tutorial.HealthSystem
{
    public class RestartOnDeath : HealthManagerEventSubscriberBase
    {
        protected override void OnTakeDamage(object sender, float damage)
        {
            // Nothing
        }
        protected override void OnDeath()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}