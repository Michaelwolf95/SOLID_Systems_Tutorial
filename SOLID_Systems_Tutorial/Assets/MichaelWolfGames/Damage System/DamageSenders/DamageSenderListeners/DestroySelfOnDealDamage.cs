
namespace MichaelWolfGames.DamageSystem.DamageSenderListeners
{
    /// <summary>
    /// Destroys the GameObject after dealing damage.
    /// This is great for projectiles like arrows and bullets.
    /// 
    /// Michael Wolf
    /// Feb 2018
    /// </summary>
    public class DestroySelfOnDealDamage : DamageSenderListenerBase
    {
        public float DestroyDelay = 0.1f;

        protected override void DoOnDealDamage(object sender, Damage.DamageEventArgs e)
        {
            Destroy(gameObject, DestroyDelay);
        }
    }
}