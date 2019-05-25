using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// CURRENTLY UNUSED
    /// Class meant to simplify defining damage senders in the the inspector.
    /// 
    /// Michael Wolf
    /// October 2018
    /// </summary>
    [System.Serializable]
    public class DamageSenderParams 
    {
        public float defaultDamageValue = 1f;
        public Damage.Faction faction = Damage.Faction.Player;
        public Damage.DamageType damageType = Damage.DamageType.Default;
        
    }
}
