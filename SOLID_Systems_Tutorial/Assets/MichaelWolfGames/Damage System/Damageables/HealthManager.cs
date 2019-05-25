using System.Collections;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Simple Implementation of HealthManagerBase.
    /// Simply Implements the defaults from the abstract class HealthManagerBase
    /// Adds the functionailty of an invlunerability delay. 
    /// 
    /// Michael Wolf
    /// April, 2017
    /// </summary>
    public class HealthManager : HealthManagerBase
	{
        [Header("Invulnerability")]
	    [SerializeField] protected bool _useInvulnerability = true;
	    [SerializeField] protected float _invulnTime = 0.25f;
	    [SerializeField] protected bool _isInvulnerable = false;

	    protected override void HandleDamage(object sender, ref Damage.DamageEventArgs args)
	    {
            // Invulnerability Check.
            if (_useInvulnerability)
	        {
	            if(_isInvulnerable) return;
	            StartCoroutine(CoInvulnerabilityDelay(_invulnTime));
	        }

	        base.HandleDamage(sender, ref args);
	    }

	    protected virtual IEnumerator CoInvulnerabilityDelay(float delay)
	    {
	        _isInvulnerable = true;
            yield return new WaitForSeconds(_invulnTime);
	        _isInvulnerable = false;
	    }
	}
}