using System;
using System.Collections;
using System.Collections.Generic;
using MichaelWolfGames.MeterSystem;
using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Interface for HealthManagers containing common public properties and methods.
    /// Extends from IDamagable.
    /// 
    /// Michael Wolf
    /// April 8, 2017
    /// </summary>
    public interface IHealthManager : IDamageable, IMeterable
    {
        // Public Properties
        float MaxHealth { get; }
        float CurrentHealth { get; }
        bool IsDead { get; }
        Action OnDeath { get; set; }
        Action OnRevive { get; set; }

        // Public Methods 
        void Kill();
        void SetHealth(float health);
        void Revive();
    }
}
