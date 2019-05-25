using UnityEngine;
using System.Collections;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Mutator that applies a flat modifier to the damage recieved based on the damage type.
    /// This can be a flat reduction, or a flat addition.
    /// For multiplicative modifiers, use DamageTypeMultiplier instead.
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public class DamageTypeFlatModifier : DamageEventMutatorBase
    {
        public DamageTypeValueStruct[] TypeValues;

        public override void MutateDamageEvent(object sender, ref Damage.DamageEventArgs args)
        {
            foreach (var tm in TypeValues)
            {
                if (args.DamageType == tm.DamageType)
                {
                    args.DamageValue += tm.Value;
                    if (args.DamageValue < 0) args.DamageValue = 0f;
                }
            }
        }
    }
}
