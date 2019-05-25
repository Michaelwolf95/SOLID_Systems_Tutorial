using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem.StatusEffects
{
    /// <summary>
    /// 
    /// 
    /// Michael Wolf
    /// October, 2018
    /// </summary>
    [CreateAssetMenu(fileName = "New DamgeModifier StatusEffect", menuName = "StatusEffects/Damage Modifier")]
    public class DamageModifierStatusEffect : StatusEffectBase
    {
        [SerializeField] protected IDamageable damageable;

        [SerializeField] protected float multiplier = 1f;
        [SerializeField] protected float flatModifier = 0f;

        [SerializeField] public bool useOverrideDescription = false;
        [TextArea(1,4)]
        [SerializeField] protected string overrideDescription = "";

        public override void OnStatusApplied()
        {
            damageable = Owner.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.MutateDamage += ModifyDamage;
            }
        }

        public override void OnStatusRemoved()
        {
            damageable.MutateDamage -= ModifyDamage;
        }


        private void ModifyDamage(object sender, ref Damage.DamageEventArgs args)
        {
            args.DamageValue = (args.DamageValue * multiplier) + flatModifier;
        }


        public override string GetDescription()
        {
            string description = "";
            if (useOverrideDescription)
            {
                description = overrideDescription;
            }
            else
            {
                description = "<b>{0}</b>:";
                if (multiplier != 1)
                {
                    description += " Multiplies all damage by {1}";
                    if (flatModifier > 0)
                    {
                        description += " and adds {2}";
                    }
                    else if (flatModifier < 0)
                    {
                        description += " and subtracts {2}";
                    }
                }
                else
                {
                    if (flatModifier > 0)
                    {
                        description += " Increases all damage by {2}.";
                    }
                    else if (flatModifier < 0)
                    {
                        description += " Reduces all damage by {2}.";
                    }
                    else
                    {
                        description += " Does nothing...";
                    }
                }
            }
            return String.Format(description, effectName, multiplier, Mathf.Abs(flatModifier));
        }
    }
}
