using System;
using System.Collections.Generic;
using MichaelWolfGames.DamageSystem;
using UnityEngine;
using UnityEngine.Events;

namespace MichaelWolfGames.Utility
{
    /// <summary>
    /// Utility class to test DamageEventArgs
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public class DamageTester : MonoBehaviour
    {
        [SerializeField] private KeyCode m_DebugKey;
        [SerializeField] private string m_DebugLogMessage = "";
        [SerializeField] private DamageableBase m_Damageable;
        [SerializeField] private bool _worldSpaceHitPoint = false;
        [SerializeField] private Damage.DamageEventArgs m_DamageArgs;

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(m_DebugKey))
            {
                if (m_DebugLogMessage.Length > 0)
                    Debug.Log("[MethodDebugger]: " + m_DebugLogMessage);
                if (m_Damageable)
                {
                    var dmg = m_DamageArgs;
                    if (!_worldSpaceHitPoint)
                        dmg.HitPoint = m_Damageable.transform.position + dmg.HitPoint;
                    m_Damageable.ApplyDamage(this, ref dmg);
                }
            }
        }
#endif
    }
}