using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Static class used for data handling throughout the DamageSystem.
    /// Contains Declarations for:
    /// - DamageEventHandler Delegate.
    /// - DamageEventArgs Struct.
    /// 
    /// Michael K. Wolf
    /// January, 2018
    /// </summary>
    public static partial class Damage
    {
        /// <summary>
        /// Core delegate used for DamageEvents.
        /// </summary>
        /// <param name="sender">Object that is sending the DamageEvent.</param>
        /// <param name="args">Damage Event Arguments</param>
        public delegate void DamageEventHandler(object sender, DamageEventArgs args);

        /// <summary>
        /// Core delegate used for DamageEvent Mutators.
        /// These delegates will MODFIY the event arguments before they're interpreted by the Damagable.
        /// Example: Mutator that adds resistances or weaknesses to damage types.
        /// </summary>
        /// <param name="sender">Object that is sending the DamageEvent.</param>
        /// <param name="args">Mutated Damage Event Arguments</param>
        public delegate void DamageEventMutator(object sender, ref DamageEventArgs args);

        public struct DamageInstance
        {
            public float DamageValue;
            public DamageType DamageType;
        }
        /// <summary>
        /// Arguments passed during DamageEvents.
        /// </summary>
        [System.Serializable]
        public struct DamageEventArgs
        {
            public float DamageValue;
            public DamageType DamageType;
            public Vector3 HitPoint;
            public Vector3 HitNormal;
            public Faction SourceFaction;
            public DamageEventType EventType;
            public DamageEventArgs(float damageValue, Vector3 hitPoint, DamageType type = DamageType.Default, Faction faction = Faction.Generic, DamageEventType eType = DamageEventType.HIT)
            {
                DamageValue = damageValue;
                DamageType = type;
                HitPoint = hitPoint;
                HitNormal = Vector3.up;
                SourceFaction = faction;
                EventType = eType;
            }
            public DamageEventArgs(float damageValue, Vector3 hitPoint, Vector3 hitNormal, DamageType type = DamageType.Default, Faction faction = Faction.Generic, DamageEventType eType = DamageEventType.HIT)
            {
                DamageValue = damageValue;
                DamageType = type;
                HitPoint = hitPoint;
                HitNormal = hitNormal;
                SourceFaction = faction;
                EventType = eType;
            }
        }

        /// <summary>
        /// Arguments passed during DamageEvents.
        /// </summary>
        [System.Serializable]
        public struct DamageDealerParams
        {

        }
        ///// <summary>
        ///// Static utility method to try to deal damage to a gameobject.
        ///// 
        ///// </summary>
        ///// <param name="damageTarget"></param>
        ///// <param name="args"></param>
        ///// <param name="sender"></param>
        ///// <returns></returns>
        //public static bool TryDealDamage(GameObject damageTarget, Damage.DamageEventArgs args, object sender = null)
        //{
        //    if (args.DamageValue <= 0) return false;
        //    IDamageable damageable = damageTarget.GetComponent<IDamageable>();
        //    if (damageable != null)
        //    {
        //        if (this.faction == damageable.GetFaction() && !Damage.FriendlyFireEnabled)
        //            return false;

        //        // By using a ref parameter, we can see the results of the damage delt after it has been changed by resistances and multipliers.
        //        damageable.ApplyDamage(sender, ref args);

        //    }
        //    // No IDamagable Found - Return false.
        //    return false;
        //}
    }
}