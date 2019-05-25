using System;
using MichaelWolfGames.MeterSystem;
using UnityEngine;

namespace MichaelWolfGames.ResourceSystem
{
    /// <summary>
    /// Base Class for Resource Management System. 
    /// Note: It might be better to start with a non-meterable base class, 
    /// for things without a min/max, and are tracked as objects (like runes).
    /// 
    /// Michael Wolf
    /// March, 2018
    /// </summary>
    public abstract class ResourceManagerBase : MonoBehaviour, IMeterable
    {
        public abstract string ResourceName { get; }

        public Action<float> OnUpdateValue { get; set; }

        #region Properties
        [SerializeField] private float _currentValue = 100f;
        public virtual float CurrentValue
        {
            get { return _currentValue; }
            protected set
            {
                if (value != _currentValue)
                {
                    _currentValue = value;
                    OnUpdateValue(_currentValue);
                }
            }
        }
        [SerializeField] private float _maxValue = 100f;
        public virtual float MaxValue
        {
            get { return _maxValue; }
            protected set { _maxValue = value; }
        }

        public float PercentValue { get { return (CurrentValue) / (MaxValue); } }

        #endregion


        #region Drawing Resource

        // As a rule of thumb, all float values should RETURN from the manager object.
        public virtual float DrawResource(float amount)
        {
            if (TryDrawResource(amount))
            {
                return amount;
            }

            return 0f;
        }

        public virtual bool TryDrawResource(float amount)
        {
            if (CurrentValue < amount)
            {
                return false;
            }
            CurrentValue -= amount;
            return true;
        }

        public virtual float DrawUpToAmount(float amount)
        {
            if (CurrentValue < amount)
            {
                var remaining = CurrentValue;
                CurrentValue = 0f;
                return remaining;
            }
            CurrentValue -= amount;
            return amount;
        }

        #endregion

        #region Adding Resource

        public virtual void AddResource(float amount)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + amount, 0f, MaxValue);
        }

        #endregion
    }
}