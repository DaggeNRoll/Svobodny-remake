public interface IDamageable
{
    public int Health { get; }

    public void ReduceHealth(int amount);
    
}