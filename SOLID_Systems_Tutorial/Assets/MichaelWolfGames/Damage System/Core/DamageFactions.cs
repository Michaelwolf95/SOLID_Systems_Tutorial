namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Static class used for data handling throughout the DamageSystem.
    /// Contains Declarations for:
    /// - Damage Factions
    /// 
    /// Michael K. Wolf
    /// January, 2018
    /// </summary>
    public static partial class Damage
    {
        /// <summary>
        /// Expandable Enumeration for different Factions.
        /// This helps for immunity. 
        /// </summary>
        public enum Faction
        {
            Generic,
            Player,
            Enemy
        }
    }
}