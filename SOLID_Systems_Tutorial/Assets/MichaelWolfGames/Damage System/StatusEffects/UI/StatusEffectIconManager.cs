using MichaelWolfGames.MeterSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MichaelWolfGames.DamageSystem.StatusEffects
{
    /// <summary>
    /// 
    /// 
    /// Michael Wolf
    /// October, 2018
    /// </summary>
    public class StatusEffectIconManager : SubscriberBase<StatusEffectManager>
    {
        Dictionary<StatusEffectBase, StatusEffectIcon> IconDictionary = new Dictionary<StatusEffectBase, StatusEffectIcon>();

        [SerializeField] private Transform iconGroupRoot;

        protected override void Start()
        {
            base.Start();
            if(iconGroupRoot == null)
            {
                iconGroupRoot = this.transform;
            }
        }

        protected override void SubscribeEvents()
        {
            SubscribableObject.OnStatusEffectAdded += AddIcon;
            SubscribableObject.OnStatusEffectRemoved += RemoveIcon;
        }

        protected override void UnsubscribeEvents()
        {
            SubscribableObject.OnStatusEffectAdded -= AddIcon;
            SubscribableObject.OnStatusEffectRemoved -= RemoveIcon;
        }

        private void AddIcon(StatusEffectBase statusEffect)
        {
            if (statusEffect.effectIcon != null && IconDictionary.ContainsKey(statusEffect) == false)
            {
                Debug.Log("Adding Status Effect Icon");
                GameObject iconGo = GameObject.Instantiate(statusEffect.effectIcon, iconGroupRoot);
                StatusEffectIcon icon = iconGo.GetComponent<StatusEffectIcon>();
                IconDictionary.Add(statusEffect, icon);

                icon.Initialize(statusEffect);

            }
        }

        private void RemoveIcon(StatusEffectBase statusEffect)
        {
            if (statusEffect.effectIcon != null && IconDictionary.ContainsKey(statusEffect) == true)
            {
                StatusEffectIcon icon = IconDictionary[statusEffect];
                icon.OnStatusRemoved();
                Destroy(icon.gameObject);
                IconDictionary.Remove(statusEffect);
            }
        }
    }
}