namespace DrekGame.Systems
{
    /// <summary>
    /// Interface for Networked damageable entities.
    /// </summary>
    public interface IDamageable
    {
        // Entity's current health.
        int Health { get; }

        /// <summary>
        /// Method to apply damage to a networked entity.
        /// </summary>
        /// <param name="dealerId">The ID of the damage dealer.</param>
        /// <param name="source">The source of the damage.</param>
        /// <param name="damageAmount">The amount of damage to apply.</param>
        /// <param name="damageType">The type of damage being applied.</param>
        void TakeDamage(ulong dealerId, Source source, int damageAmount, DamageTypes damageType);

        /// <summary>
        /// Method to heal a networked entity.
        /// </summary>
        /// <param name="healerId">The ID of the healer.</param>
        /// <param name="source">The source of the healing.</param>
        /// <param name="healAmount">The amount of healing to apply.</param>
        void Heal(ulong healerId, Source source, int healAmount);
    }
}
