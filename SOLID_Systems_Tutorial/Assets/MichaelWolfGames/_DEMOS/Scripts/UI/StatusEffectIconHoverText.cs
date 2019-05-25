using System;
using System.Collections.Generic;
using UnityEngine;
using MichaelWolfGames.DamageSystem.StatusEffects;

namespace MichaelWolfGames.Examples
{
    /// <summary>
    /// Connects HoverText to StatusEffectIcons
    /// 
    /// Michael Wolf
    /// November, 2018
    /// </summary>
    [RequireComponent(typeof(HoverText))]
    public class StatusEffectIconHoverText : SubscriberBase<StatusEffectIcon>
    {
        [SerializeField] private HoverText hoverText;
        protected override void DoOnInitialize()
        {
            base.DoOnInitialize();
            if(hoverText == null)
            {
                hoverText = GetComponent<HoverText>();
            }
            // Check if icon is already initialized.
            if (SubscribableObject.statusEffect != null)
            {
                SetHoverText();
            }
        }
        protected override void SubscribeEvents()
        {
            SubscribableObject.OnInitialized += SetHoverText;
        }

        protected override void UnsubscribeEvents()
        {
            SubscribableObject.OnInitialized -= SetHoverText;
        }

        private void SetHoverText()
        {
            if (hoverText != null)
            {
                hoverText.textValue = SubscribableObject.statusEffect.GetDescription();
            }
        }
    }
}
