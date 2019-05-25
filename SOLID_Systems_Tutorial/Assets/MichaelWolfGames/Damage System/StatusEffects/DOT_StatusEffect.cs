using System;
using System.Collections.Generic;
using MichaelWolfGames.MeterSystem;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem.StatusEffects
{
    /// <summary>
    /// 
    /// 
    /// Michael Wolf
    /// October, 2018
    /// </summary>
    [CreateAssetMenu(fileName = "New DOT Status", menuName = "StatusEffects/DOT Status")]
    public class DOT_StatusEffect : TimedStatusEffect
    {
        public float TickInterval = 0.5f;
        public float damageValue = 1;
        public Damage.DamageType damageType = Damage.DamageType.Default;
        
        [SerializeField] public bool useOverrideDescription = false;
        [TextArea(1,4)]
        [SerializeField] protected string overrideDescription = "";

        // ToDo: This could be much nicer. Refactor.
        DOTEffect dotObject;

        public override Action<float> OnUpdateValue
        {
            get { return (dotObject==null)? null : dotObject.OnUpdateValue; }
            set
            {
                if (dotObject != null)
                    dotObject.OnUpdateValue = value;
            }
        }
        public override float CurrentValue
        {
            get { return (dotObject == null) ? 0 : dotObject.CurrentValue; }
        }
        public override float MaxValue
        {
            get { return (dotObject == null) ? 0 : dotObject.MaxValue; }
        }
        public override float PercentValue
        {
            get { return (dotObject == null) ? 0 : dotObject.PercentValue; }
        }

        public override void OnStatusApplied()
        {
            if(effectAttachment != null)
            {
                dotObject = effectAttachment.GetComponent<DOTEffect>();
                if(dotObject != null)
                {
                    dotObject.Duration = Duration;
                    dotObject.TickInterval = TickInterval;
                    dotObject.SetDamageValue(damageValue);
                    dotObject.SetDamageType(damageType);

                    dotObject.OnCompleteCallback += () =>
                    {
                        RemoveSelf();
                    };
                }
            }

        }

        public override void OnStatusRemoved()
        {
            if (dotObject != null)
            {
                // Force complete
                Destroy(dotObject);
            }
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnUpdate(float Timer)
        {
            
        }

        protected override void OnFinished()
        {
            
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
                description = "<b>{0}</b>: Deals {1} {2} Damage every {3} seconds over {4} seconds.";
                
            }
            return String.Format(description, effectName, this.damageValue, this.damageType, this.TickInterval, this.Duration);
        }
    }
}
