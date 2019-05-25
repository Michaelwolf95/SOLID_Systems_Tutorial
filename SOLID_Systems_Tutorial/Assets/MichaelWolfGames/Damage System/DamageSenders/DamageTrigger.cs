using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// DamageSender that sends damage events via OnTriggerEnter
    /// Extends DamageCollider, overriding its OnCollision functionality and replacing it with an OnTrigger approach.
    /// 
    /// Michael Wolf
    /// April, 2017
    /// </summary>
    public class DamageTrigger : DamageCollider 
	{
        // Overridden to do nothing.
        protected override void OnCollisionEnter(Collision other) { }   

	    protected virtual void OnTriggerEnter(Collider other)
	    {
	        var go = (other.attachedRigidbody) ? other.attachedRigidbody.gameObject : other.gameObject;
            if (TryDealDamage(go, GetDamageEventArgumentsFromCollider(other)))
            {
                OnDealDamageSuccess();
            }
            else
            {
                OnDealDamageFailed();
            }
        }

        protected virtual Damage.DamageEventArgs GetDamageEventArgumentsFromCollider(Collider col)
        {
            Vector3 point = col.ClosestPointOnBounds(transform.position);
            // Normal found using center of bounds to hit point.
            Vector3 norm = (point - col.bounds.center).normalized;
            return new Damage.DamageEventArgs(DamageValue, point, norm, damageType);
        }
	}
}