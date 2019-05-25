using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// DamageSender that sends damage events via OnCollisionEnter2D.
    /// Extends DamageCollider.
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public class DamageCollider2D : DamageCollider
    {
        // Overridden to do nothing.
        protected override void OnCollisionEnter(Collision other) { }

        protected virtual void OnCollisionEnter2D(Collision2D col)
        {
            var go = (col.collider.attachedRigidbody) ? col.collider.attachedRigidbody.gameObject : col.collider.gameObject;
            if (TryDealDamage(go, GetDamageEventArgumentsFromCollision2D(col)))
            {
                OnDealDamageSuccess();
            }
            else
            {
                OnDealDamageFailed();
            }
        }
        protected virtual Damage.DamageEventArgs GetDamageEventArgumentsFromCollision2D(Collision2D col)
        {
            return new Damage.DamageEventArgs(DamageValue, col.contacts[0].point, col.contacts[0].normal, damageType, faction);
        }
    }
}