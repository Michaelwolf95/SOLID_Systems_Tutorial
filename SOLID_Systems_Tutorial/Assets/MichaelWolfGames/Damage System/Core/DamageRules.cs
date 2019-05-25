using UnityEngine;

namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Static class used for data handling throughout the DamageSystem.
    /// Contains Declarations for:
    /// - Toggling Friendly Fire
    /// - Calculations used when determining damage.
    /// 
    /// Michael K. Wolf
    /// January, 2018
    /// </summary>
    public static partial class Damage
    {
        public static bool FriendlyFireEnabled = false;

        public static void SetFriendlyFire(bool state)
        {
            FriendlyFireEnabled = state;
        }

        //ToDo: Either remove this or implement armor as a feature.
        /// <summary>
        /// ~EXAMPLE OF EXTENSIBILITY~
        /// Returns a subtractive modifier for damage dependent on amount of armor.
        /// Modify this to change how different damage types are subtracted by armor,
        /// Then impement it in HealthManager or your own derived class.
        /// </summary>
        /// <param name="type">The type of incoming damage.</param>
        /// <param name="armorValue">The value of the armor</param>
        /// <returns></returns>
        public static float GetArmorReductionModifier(DamageType type, float armorValue)
        {
            switch (type)
            {
                case DamageType.Default:
                    return armorValue;
                case DamageType.Melee:
                    return armorValue;
                case DamageType.Fire:
                    return armorValue;
                case DamageType.Ice:
                    return armorValue / 2f;
                case DamageType.Poison:
                    return 0f;
                default:
                    Debug.LogWarning("DamageType " + type + " is not supported in this method. Returning zero.");
                    return 0f;
            }
        }
    }
}