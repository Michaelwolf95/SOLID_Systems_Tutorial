using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Fundamental interface for damage event recievers.
    /// 
    /// Michael Wolf
    /// April 8, 2017
    /// </summary>
    public interface IDamageable
    {
        event Damage.DamageEventHandler OnTakeDamage;
        event Damage.DamageEventMutator MutateDamage;
        Damage.Faction GetFaction();

        void ApplyDamage(object sender, ref Damage.DamageEventArgs args);
        void ApplyDamage(object sender, float damage, Vector3 hitPoint);

    }
}