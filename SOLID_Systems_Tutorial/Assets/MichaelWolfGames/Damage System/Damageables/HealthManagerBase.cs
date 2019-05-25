using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Base Class for most (if not all) Health Managers. 
    /// Extends from DamagableBase and implements IHealthManager.
    /// This class:
    /// - Receives ApplyDamage calls, triggers OnTakeDamage events, and handles health changes accordingly.
    /// - When health reaches 0, fires an OnDeath events and toggles an IsDead bool.
    /// - Hosts public methods for Kill, SetHealth, and Revive.
    /// 
    /// Michael Wolf
    /// April, 2017
    /// </summary>
    public abstract class HealthManagerBase : DamageableBase, IHealthManager
    {
        #region Properties

        [SerializeField] private float maxHealth = 100f;
        public float MaxHealth
        {
            get { return maxHealth; }
            protected set { maxHealth = value; }
        }

        [SerializeField] private float currentHealth = 100f;
        public float CurrentHealth
        {
            get { return currentHealth; }
            protected set { currentHealth = value; }
        }

        public bool IsDead { get; protected set; }
        
        // IMeterable properties
        public float PercentValue
        {
            get { return CurrentHealth / MaxHealth; }
        }
        public Action<float> OnUpdateValue // Wraps OnUpdateHealth
        {
            get { return OnUpdateHealth; }
            set { OnUpdateHealth = value; }
        }
        public float MaxValue
        {
            get { return MaxHealth; }
        }
        public float CurrentValue
        {
            get { return CurrentHealth; }
        }

        #endregion

        //================================================================================

        #region Events

        private Action _onDeath = delegate { };
        public Action OnDeath
        {
            get { return _onDeath; }
            set { _onDeath = value; }
        }
        private Action _onRevive = delegate { };
        public Action OnRevive
        {
            get { return _onRevive; }
            set { _onRevive = value; }
        }

        private Action<float> _onUpdateHealth = delegate { };
        public Action<float> OnUpdateHealth
        {
            get { return _onUpdateHealth; }
            set { _onUpdateHealth = value; }
        }

        #endregion

        //================================================================================

        #region Public Methods

        public void SetHealth(float health)
        {
            currentHealth = health;
            OnUpdateHealth(currentHealth);
        }

        public void AddHealth(float health)
        {
            currentHealth += health;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            OnUpdateHealth(currentHealth);
        }

        public void Revive()
        {
            if (!IsDead) return;
            currentHealth = maxHealth;
            OnUpdateHealth(currentHealth);
            HandleRevive();
        }
        public virtual void Kill()
        {
            if (IsDead) return;
            currentHealth = 0f;
            OnUpdateHealth(currentHealth);
            HandleDeath();
        }

        // Health Regen
        public virtual void RegenerateHealthToFull(float regenSpeed)
        {
            RegenerateHealth((MaxHealth - CurrentHealth), regenSpeed);
        }
        public virtual void RegenerateHealth(float healAmmount, float regenSpeed)
        {
            StopHealthRegen();
            RegenerateHealthCoroutine = StartCoroutine(CoRegenerateHealth(healAmmount, regenSpeed));
        }
        public void StopHealthRegen()
        {
            if (RegenerateHealthCoroutine != null)
            {
                StopCoroutine(RegenerateHealthCoroutine);
                RegenerateHealthCoroutine = null;
            }
        }

        #endregion

        //================================================================================

        #region Initialization

        protected virtual void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            IsDead = false;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            OnUpdateHealth(currentHealth);
            if (currentHealth <= 0f)
            {
                Kill();
            }
        }
        #endregion

        //================================================================================

        #region Damage Handling

        public override void ApplyDamage(object sender, ref Damage.DamageEventArgs args)
        {
            if (IsDead)
            {
                args.DamageValue = 0f;
                return;
            }
            // Cannot receive damage from same faction.
            if (args.SourceFaction == Faction && args.SourceFaction != Damage.Faction.Generic)
            {
                return;
            }
            
            HandleDamage(sender, ref args);
        }

        protected virtual void HandleDamage(object sender, ref Damage.DamageEventArgs args)
        {
            if (IsDead) return;
            InvokeMutateDamage(sender, ref args);
            float damage = CalculateDamage(args);
            args.DamageValue = damage;
            currentHealth -= damage;

            // We still call TakeDamage if the damage would kill them, and leave it up to the listeners to check for death.
            InvokeOnTakeDamage(sender, args);

            if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                HandleDeath();
            }
            OnUpdateHealth(currentHealth);

        }
        protected virtual void HandleDeath()
        {
            if (IsDead) return;
            IsDead = true;
            OnDeath();
        }
        protected virtual void HandleRevive()
        {
            if (!IsDead) return;
            IsDead = false;
            OnRevive();
        }

        /// <summary>
        /// Calculates the effective damage on the HealthManager, AFTER mutators.
        /// Override this for changing how damage is handled specifically on this class.
        /// Alternatively, attach a mutator.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual float CalculateDamage(Damage.DamageEventArgs args)
        {
            // For the simplest case, just pass the raw DamageValue.
            return args.DamageValue;
        }

        #endregion

        #region Health Regeneration

        protected Coroutine RegenerateHealthCoroutine = null;
        protected virtual IEnumerator CoRegenerateHealth(float healAmmount, float regenRate)
        {
            float duration = healAmmount / regenRate;
            float timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                AddHealth((regenRate * Time.deltaTime));
                yield return null;
            }
            RegenerateHealthCoroutine = null;
        }
        #endregion

    }
}