using System.Collections;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// 
    /// ToDo: Seperate these into different classes? Color effects may vary depending on sender.
    /// 
    /// </summary>
    public class HM_SpriteColorEffects : HealthManagerEventListenerBase
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [Header("OnTakeDamage Flash")]
        [SerializeField] private Color _takeDamageColor = Color.red;
        [SerializeField] private float _takeDamageFlashDuration = 0.15f;
        [Header("OnDeath Fade Out")]
        [SerializeField] private Color _deathColor = Color.gray;
        [SerializeField] private float _deathFadeDuration = 0.15f;
        [Header("OnDeath Fade Out")]
        [SerializeField] private float _reviveFadeDuration = 0.15f;


        private Color _originalColor = Color.white;
        private Coroutine _effectCoroutine = null;

        protected override void Start()
        {
            base.Start();
            if (!_spriteRenderer)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            if (_spriteRenderer)
            {
                _originalColor = _spriteRenderer.color;
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_spriteRenderer)
            {
                _spriteRenderer.color = _originalColor;
            }
        }

        protected override void DoOnTakeDamage(object sender, Damage.DamageEventArgs e)
        {
            if (_spriteRenderer)
            {
                if (_effectCoroutine != null)
                {
                    StopCoroutine(_effectCoroutine);
                    _effectCoroutine = null;
                    _spriteRenderer.color = _originalColor;
                }
                _effectCoroutine = StartCoroutine(CoFlashColor(_takeDamageColor, _originalColor, _takeDamageFlashDuration));
            }
        }

        protected override void DoOnDeath()
        {
            if (_spriteRenderer)
            {
                if (_effectCoroutine != null)
                {
                    StopCoroutine(_effectCoroutine);
                    _effectCoroutine = null;
                }
                _effectCoroutine = StartCoroutine(CoFadeColor(_deathColor, _deathFadeDuration));
            }
        }

        protected override void DoOnRevive()
        {
            if (_spriteRenderer)
            {
                if (_effectCoroutine != null)
                {
                    StopCoroutine(_effectCoroutine);
                    _effectCoroutine = null;
                }
                _effectCoroutine = StartCoroutine(CoFadeColor(_originalColor,_reviveFadeDuration));
            }
        }


        private IEnumerator CoFlashColor(Color flashColor, Color originalColor, float duration)
        {
            float timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                _spriteRenderer.color = Color.Lerp(flashColor, originalColor, timer / duration);
                yield return null;
            }
            _spriteRenderer.color = originalColor;
            _effectCoroutine = null;
        }

        private IEnumerator CoFadeColor(Color targetColor, float duration)
        {
            Color startColor = _spriteRenderer.color;
            float timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                _spriteRenderer.color = Color.Lerp(startColor, targetColor, timer / duration);
                yield return null;
            }
            _spriteRenderer.color = targetColor;
            _effectCoroutine = null;
        }


    }
}