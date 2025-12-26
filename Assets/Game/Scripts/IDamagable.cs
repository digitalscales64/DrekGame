namespace Game.World
{
    /// <summary>
    /// Interface for network objects that can take damage.
    /// </summary>
    public interface INetworkDamagable
    {
        void TakeDamage(int amount);
        void Heal(int amount);
    }
}
