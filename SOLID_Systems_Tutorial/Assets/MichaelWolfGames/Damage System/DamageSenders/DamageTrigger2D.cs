using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// DamageSender that sends damage events via OnTriggerEnter2D.
    /// Extends DamageCollider.
    /// 
    /// Michael Wolf
    /// April, 2017
    /// </summary>
    public class DamageTrigger2D : DamageCollider
    {
        // Overridden to do nothing.
        protected override void OnCollisionEnter(Collision other) { }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            var go = (other.attachedRigidbody) ? other.attachedRigidbody.gameObject : other.gameObject;
            if (TryDealDamage(go, GetDamageEventArgumentsFromCollider2D(other)))
            {
                OnDealDamageSuccess();
            }
            else
            {
                OnDealDamageFailed();
            }
        }
        protected virtual Damage.DamageEventArgs GetDamageEventArgumentsFromCollider2D(Collider2D col)
        {
            Vector3 point = col.bounds.ClosestPoint(this.transform.position);
            // Normal found using center of bounds to hit point.
            Vector3 norm = (point - col.bounds.center).normalized;
            return new Damage.DamageEventArgs(DamageValue, point, norm, damageType, faction);
        }
    }
}