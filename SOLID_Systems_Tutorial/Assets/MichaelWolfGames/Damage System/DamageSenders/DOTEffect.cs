using System;
using System.Collections;
using MichaelWolfGames.MeterSystem;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Base class for DOT effects.
    /// This is the object that is attached to a damageable.
    /// A better, more robust system, would start from a "StatusEffect" base class.
    /// This, however, is beyond the scope of this asset, and should come later as a second package.
    /// 
    /// Michael Wolf
    /// March, 2018
    /// </summary>
    public class DOTEffect : DamageSenderBase, IMeterable
    {
        [Header("DOT Settings")]
        public float Duration = 1f;
        public float TickInterval = 0.5f;
        //public int TickCount = 3;
        protected float Timer = 0f;

        public DamageableBase AttachedDamageable;   // This could just be a GameObject

        public bool AttachToParentAtStart = true;   // Auto attaches itself to the parent gameobject at start.
        public bool DestroySelfWhenFinished = true; // Auto destroy self when done.

        public Action OnCompleteCallback = delegate { };

        // IMeterable Interface
        public float PercentValue { get { return Timer/Duration; } }
        public Action<float> OnUpdateValue { get; set; }
        public float MaxValue { get {return Duration;} }
        public float CurrentValue { get { return Timer; } }

        protected virtual void Start()
        {
            if (AttachToParentAtStart)
            {
                if (this.transform.parent != null)
                {
                    var dam = transform.parent.GetComponent<DamageableBase>();
                    if (dam)
                    {
                        AttachEffect(dam);
                    }
                }
            }
        }

        public virtual void AttachEffect(DamageableBase damageable)
        {
            if (AttachedDamageable) return;     //Effect is already attached.
            if(OnUpdateValue == null)
                OnUpdateValue = delegate(float f) { };
            AttachedDamageable = damageable;
            StartCoroutine(CoEffectTimer(OnCompleteCallback));

        }

        protected virtual IEnumerator CoEffectTimer(Action onComplete = null)
        {
            if (TickInterval > Duration)
            {
                TickInterval = Duration;
            }
            //Note: There is no initial tick at t=0.
            int ticks = 1;
            Timer = 0f;
            while (Timer < Duration)
            {
                Timer += Time.deltaTime;

                if (Timer > TickInterval * ticks)
                {
                    Damage.DamageEventArgs args = new Damage.DamageEventArgs(DamageValue, Vector3.zero, damageType, faction, Damage.DamageEventType.DOT);
                    TryDealDamage(AttachedDamageable.gameObject, args);
                    ticks++;
                }
                if (OnUpdateValue != null)
                {
                    OnUpdateValue(Timer);
                }
                yield return null;
            }

            Timer = Duration;
            if(onComplete != null)
            {
                onComplete();
            }
            if (DestroySelfWhenFinished)
            {
                Destroy(gameObject);
            }
        }


#if UNITY_EDITOR
        ///// <summary>
        ///// This OnValidate Method helps assure that the referenced Monobehaviour component implements IMeterable.
        ///// </summary>
        //private void OnValidate()
        //{
        //    if (MeterableBehaviour)
        //    {
        //        if ((MeterableBehaviour as IMeterable) == null)
        //        {
        //            foreach (var behaviour in MeterableBehaviour.gameObject.GetComponents<MonoBehaviour>())
        //            {
        //                if ((behaviour as IMeterable) != null)
        //                {
        //                    MeterableBehaviour = behaviour;
        //                    break;
        //                }
        //            }
        //        } 
        //    }
        //}
#endif
    }
}