using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
	public class PlayAudioOnTakeDamage : DamageEventListenerBase
	{
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private AudioClip _clipToPlay;

		protected override void DoOnTakeDamage(object sender, Damage.DamageEventArgs damageEventArgs)
		{
			_audioSource.PlayOneShot(_clipToPlay);
		}
	}
}
