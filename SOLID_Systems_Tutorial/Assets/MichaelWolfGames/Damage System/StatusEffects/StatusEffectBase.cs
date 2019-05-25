using UnityEngine;
using System.Collections;
//using UnityEditor;

namespace MichaelWolfGames.DamageSystem.StatusEffects
{
    /// <summary>
    /// Base class for status effect objects.
    /// 
    /// Michael Wolf
    /// October, 2018
    /// </summary>
    public abstract class StatusEffectBase : ScriptableObject
    {
        // ToDo: Create an asset library SO for all status effect SOs, and index them.
        // ToDo: Allow references to other statuses as sub-components?

        public StatusEffectManager Owner { get; protected set; }

        public string effectName;
        public GameObject effectAttachment;
        public GameObject effectIcon;

        public virtual StatusEffectBase CreateRuntimeInstance()
        {
            StatusEffectBase instance = Object.Instantiate(this);

            return instance;
        }

        public virtual void Initialize(StatusEffectManager newOwner)
        {
            Owner = newOwner;

            if (effectAttachment != null)
            {
                // Spawn an instance of 
                var attachment = GameObject.Instantiate(effectAttachment);
                attachment.transform.SetParent(Owner.transform);
                effectAttachment = attachment;
            }
            //OnStatusApplied();
        }
        //ToDo: Rename
        public virtual void RemoveSelf()
        {
            if (Owner != null)
            {
                Owner.RemoveStatusEffect(this);
            }
        }

        //public virtual void Remove()
        //{
        //    OnStatusRemoved();
        //}

        public abstract void OnStatusApplied();

        public abstract void OnStatusRemoved();

        public abstract string GetDescription();

    }
}