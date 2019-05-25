using System;
using UnityEngine;

namespace MichaelWolfGames
{
    public abstract class SubscriberBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T SubscribableObject;
        protected bool IsInitialized = false;
        protected bool IsSubscribed = false;

        protected virtual void Awake()
        {
            if (!IsInitialized)
            {
                Initialize();
            }
        }

        protected virtual void Start()
        {
            Initialize();
        }

        protected virtual void OnEnable()
        {
            if (!IsInitialized)
            {
                Initialize();
            }
            HandleEventSubscription(true);
        }

        protected virtual void OnDisable()
        {
            HandleEventSubscription(false);
        }

        protected virtual void Initialize()
        {
            if (!IsInitialized)
            {
                FetchSubscribableObject();
                if (SubscribableObject)
                {
                    DoOnInitialize();
                    OnInitialized();
                    IsInitialized = true;
                }
            }
            if (!IsSubscribed && this.isActiveAndEnabled)
                HandleEventSubscription(true);
        }

        protected virtual void FetchSubscribableObject()
        {
            if (!SubscribableObject) SubscribableObject = GetComponent<T>();
            if (!SubscribableObject) SubscribableObject = GetComponentInParent<T>();
        }

        protected virtual void HandleEventSubscription(bool state)
        {
            if (SubscribableObject && IsInitialized)
            {
                if (state)
                {
                    if (!IsSubscribed)
                    {
                        SubscribeEvents();
                    }
                }
                else
                {
                    if (IsSubscribed)
                    {
                        UnsubscribeEvents();
                    }
                }

                IsSubscribed = state;
            }
        }
        protected virtual void DoOnInitialize() { }
        protected virtual void OnInitialized() { }

        protected abstract void SubscribeEvents();
        protected abstract void UnsubscribeEvents();
    }
}