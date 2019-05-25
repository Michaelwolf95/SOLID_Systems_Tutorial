using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Spawns an effect at the point where damage was recieved.
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public class PlayEffectOnTakeDamage : DamageEventListenerBase
    {
        [SerializeField] private GameObject _damageEffectPrefab;
        [SerializeField] private float _destroyTime = 1f;
        [SerializeField] private bool _filterByDamageType = false;
        [SerializeField] private Damage.DamageType _typeFilter;

        protected override void DoOnTakeDamage(object sender, Damage.DamageEventArgs damageEventArgs)
        {
            if(_filterByDamageType)
                if (damageEventArgs.DamageType != _typeFilter)
                    return;
            if (_damageEffectPrefab)
            {
                var go = GameObject.Instantiate(_damageEffectPrefab);
                go.transform.position = damageEventArgs.HitPoint;
                go.transform.LookAt(damageEventArgs.HitPoint + damageEventArgs.HitNormal);

                Destroy(go, _destroyTime);
            }
        }
    }
}