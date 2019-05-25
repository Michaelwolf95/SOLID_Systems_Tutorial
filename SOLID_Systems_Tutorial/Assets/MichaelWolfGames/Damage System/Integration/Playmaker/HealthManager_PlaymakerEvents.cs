#if PLAYMAKER
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class HealthManager_PlaymakerEvents : SubscriberBase<HealthManager>
    {
        [SerializeField] private PlayMakerFSM _playMaker;
        [SerializeField] private string _onDamageEventName = "TAKE_DAMAGE";
        [SerializeField] private string _onDeathEventName = "DIE";

        protected override void Start()
        {
            base.Start();
            if (!_playMaker) _playMaker = this.GetComponent<PlayMakerFSM>();
        }

        protected override void SubscribeEvents()
        {
            SubscribableObject.OnTakeDamage += DoOnTakeDamage;
            SubscribableObject.OnDeath += DoOnDeath;
        }

        protected override void UnsubscribeEvents()
        {
            SubscribableObject.OnTakeDamage -= DoOnTakeDamage;
            SubscribableObject.OnDeath -= DoOnDeath;
        }

        private void DoOnTakeDamage(object sender, Damage.DamageEventArgs e)
        {
            if (_playMaker)
            {
                _playMaker.SendEvent(_onDamageEventName);
            }
        }

        private void DoOnDeath()
        {
            if (_playMaker)
            {
                _playMaker.SendEvent(_onDeathEventName);
            }
        }

    }
}
#endif