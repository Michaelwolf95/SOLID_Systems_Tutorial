namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Static class used for data handling throughout the DamageSystem.
    /// Contains Declarations for:
    /// - DamageType Enumeration.
    /// 
    /// Michael K. Wolf
    /// January, 2018
    /// </summary>
    public static partial class Damage
    {
        /// <summary>
        /// Expandable Enumeration for different Damage Types. 
        /// </summary>
        public enum DamageType
        {
            Default,
            Melee,
            Fire,
            Ice,
            Poison,
            Electric,
        }
    }
}