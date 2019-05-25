using System;
using UnityEngine;

namespace MichaelWolfGames.MeterSystem
{
    /// <summary>
    /// Base class for all meter objects, which read information from IMeterable objects.
    /// 
    /// Michael Wolf
    /// Last Updated: October, 2018
    /// </summary>
    public abstract class MeterBase : MonoBehaviour
    {
        // MonoBehaviour reference for meterables.
        public UnityEngine.Object MeterableObject;

        protected bool IsSubscribed = false;
        protected IMeterable Meterable = null;

        protected virtual void OnEnable()
        {
            HandleEventSubscription(true);
            if(IsSubscribed)
                UpdateMeter(Meterable.PercentValue);
        }

        protected virtual void OnDisable()
        {
            HandleEventSubscription(false);
        }

        private void HandleEventSubscription(bool state)
        {
            //if(!MeterableBehaviour && Meterable == null) return;
            if (Meterable == null && MeterableObject != null)
            {
                var m = MeterableObject as IMeterable;
                if(m != null)
                {
                    Meterable = m;
                }
            }

            if (Meterable != null)
            {
                if (state)
                {
                    if (!IsSubscribed)
                    {
                        Meterable.OnUpdateValue += DoOnUpdateValue;
                    }
                }
                else
                {
                    if (IsSubscribed)
                    {
                        Meterable.OnUpdateValue -= DoOnUpdateValue;
                    }
                }

                IsSubscribed = state;
            }
        }

        private void DoOnUpdateValue(float currentValue)
        {
            UpdateMeter(Meterable.PercentValue);
        }

        public virtual void SetMeterable(IMeterable meterable)
        {
            if (Meterable != null)
            {
                HandleEventSubscription(false);
            }
            Meterable = meterable;
            if(Meterable.GetType().IsAssignableFrom(typeof(UnityEngine.Object)))
            {
                MeterableObject = Meterable as UnityEngine.Object;
            }
            HandleEventSubscription(true);

            if (IsSubscribed)
            {
                UpdateMeter(Meterable.PercentValue);
            }
        }

        protected abstract void UpdateMeter(float percentValue);


#if UNITY_EDITOR
        /// <summary>
        /// This OnValidate Method helps assure that the referenced Monobehaviour component implements IMeterable.
        /// </summary>
        private void OnValidate()
        {
            if (Meterable == null && MeterableObject != null)
            {
                if ((MeterableObject as IMeterable) != null)
                {
                    Meterable = MeterableObject as IMeterable;
                }
                else
                {
                    // If the object is a gameObject or a Monobehaviour, check Monobehaviours on same object.
                    GameObject go = (MeterableObject as GameObject);
                    if(go == null)
                    {
                        MonoBehaviour mb = (MeterableObject as MonoBehaviour);
                        if(mb != null)
                        {
                            go = mb.gameObject;
                        }
                    }
                    if(go != null)
                    {
                        foreach (var behaviour in go.GetComponents<MonoBehaviour>())
                        {
                            if ((behaviour as IMeterable) != null)
                            {
                                MeterableObject = behaviour;
                                Meterable = (behaviour as IMeterable);
                                break;
                            }
                        }
                    }
                }
            }

        }
#endif

    }
}