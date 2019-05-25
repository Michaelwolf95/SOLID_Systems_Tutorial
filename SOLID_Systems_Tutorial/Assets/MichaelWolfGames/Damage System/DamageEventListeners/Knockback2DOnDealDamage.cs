using MichaelWolfGames.DamageSystem.DamageSenderListeners;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Attempts to knockback the target after dealing damage.
    /// 
    /// Michael Wolf
    /// February 2018
    /// </summary>
    public class Knockback2DOnDealDamage : DamageSenderListenerBase
    {
        [Tooltip("Magnitude of the knockback force vector.")]
        [SerializeField] private float _knockbackForce = 3f;
        [Tooltip("Rotate the knockback vector. 0 is all horizontal, 1 is all upwards.")]
        [Range(0f, 1f)]
        [SerializeField] private float _upwardModifier = 0.5f;
        [Tooltip("Additional, flat force to add to the existing force. This is independed of all other variables.")]
        [SerializeField] private Vector3 _flatForceVector;

        [SerializeField] private bool _debug;

        protected override void DoOnDealDamage(object sender, Damage.DamageEventArgs args)
        {
            ApplyKnockback(sender, args);
        }

        private void ApplyKnockback(object receiver, Damage.DamageEventArgs e)
        {
            if (receiver.GetType() == typeof(DamageableBase) || receiver.GetType().IsSubclassOf(typeof(DamageableBase)))
            {
                var damagable = (DamageableBase) receiver;
                var go = damagable.gameObject;
                var rb = go.GetComponent<Rigidbody2D>();
                if (rb)
                {
                    Vector3 forceDir = ((Vector3)rb.position - e.HitPoint).normalized;
                    forceDir = Vector3.Project(forceDir, Vector2.right).normalized;
                    forceDir += Vector3.up *_upwardModifier;
                    forceDir = forceDir.normalized;
                    rb.AddForce(forceDir*_knockbackForce, ForceMode2D.Impulse);
                    rb.AddForce(_flatForceVector, ForceMode2D.Impulse);

                    if (_debug)
                    {
                        Debug.Log("Applying Knockback!");
                        var rbPos = (Vector3) rb.position;

                        // Pink: The initial difference line.
                        Debug.DrawLine(e.HitPoint, rbPos, new Color(255f, 0f, 97f), 0.5f);
                        // Red: The force direction.
                        Debug.DrawLine(rbPos, rbPos + forceDir * 5f, Color.red, 0.5f);
                        // Blue: The flat force vector.
                        Debug.DrawLine(rbPos, rbPos + _flatForceVector, Color.blue, 0.5f);

                    }
                }

            }
        }

    }
}