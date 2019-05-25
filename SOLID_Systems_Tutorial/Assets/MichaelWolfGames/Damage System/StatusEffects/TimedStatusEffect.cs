using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MichaelWolfGames.MeterSystem;

namespace MichaelWolfGames.DamageSystem.StatusEffects
{
    /// <summary>
    /// Base class for timed status effect objects.
    /// 
    /// Michael Wolf
    /// October, 2018
    /// </summary>
    public abstract class TimedStatusEffect : StatusEffectBase, IMeterable
    {
        public float Duration = 1f;
        protected float Timer = 0f;

        protected Coroutine statusCoroutine = null;

        // IMeterable Interface
        public virtual float PercentValue { get { return Timer / Duration; } }
        private Action<float> _onUpdateValue = delegate (float value) { };
        public virtual Action<float> OnUpdateValue
        {
            get { return _onUpdateValue; }
            set { _onUpdateValue = value; }
        }
        public virtual float MaxValue { get { return Duration; } }
        public virtual float CurrentValue { get { return Timer; } }

        public override void Initialize(StatusEffectManager newOwner)
        {
            base.Initialize(newOwner);

            Owner.StartCoroutine(CoEffectTimer());
        }

        public override void OnStatusRemoved()
        {
            if (statusCoroutine != null)
            {
                Owner.StopCoroutine(statusCoroutine);
                statusCoroutine = null;
            }
            OnFinished();
        }

        protected abstract void OnStart();
        protected abstract void OnUpdate(float Timer);
        protected abstract void OnFinished();


        protected virtual IEnumerator CoEffectTimer()
        {
            OnStart();
            Timer = 0f;
            while (Timer < Duration)
            {
                Timer += Time.deltaTime;

                OnUpdate(Timer);
                if(OnUpdateValue != null)
                {
                    OnUpdateValue(Timer);
                }
                yield return null;
            }

            Timer = Duration;
            statusCoroutine = null;
            OnFinished();
        }

    }
}