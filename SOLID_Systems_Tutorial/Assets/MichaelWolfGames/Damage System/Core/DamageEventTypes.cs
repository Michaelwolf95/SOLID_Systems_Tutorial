namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Static class used for data handling throughout the DamageSystem.
    /// Contains Declarations for:
    /// - DamageEventType Enumeration.
    /// 
    /// ToDo: Implement DamageEventListeners Filter
    /// Michael K. Wolf
    /// March, 2018
    /// </summary>
    public static partial class Damage
    {
        /// <summary>
        /// Expandable Enumeration for differentiating between the TYPES of damage events.
        /// Use this to filter DamageEventListeners, so that things such as DOTs don't cause hit reactions, and vice versa.
        /// </summary>
        public enum DamageEventType
        {
            HIT,    // Stadard Damage Event
            DOT,    // Damage Over Time 
            //AOE,    // Area of Effect. 
        }
    }
}