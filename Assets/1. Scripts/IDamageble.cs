using UnityEngine;

public interface IDamageble
{
    public int Health { get; }

    public void ApplayDamage(int damage);

    public void Die();
}