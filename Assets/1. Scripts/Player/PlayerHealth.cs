using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageble
{
    public int Health { get; private set; } = 5;
    public int MaxHealth { get; private set; } = 8;
    public float InvulnerableTime { get; private set; } = 1;
    private bool _invulnerable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            AddHealth(1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ApplayDamage(1);
        }
    }

    public void ApplayDamage(int damage)
    {
        if (!_invulnerable)
        {
            _invulnerable = true;
            Invoke(nameof(InvulnerableOff), InvulnerableTime);
            Health -= damage;
            EventManager.OnRemoveHealth();
            if (Health <= 0)
            {
                Die();
            }
        }
    }

    public void AddHealth(int healtValue)
    {
        if (Health < MaxHealth)
        {
            Health++;
            EventManager.OnAddHealth();
        }
        else Health = MaxHealth;
    }

    public void Die()
    {
        Health = 0;
    }

    private void InvulnerableOff()
    {
        _invulnerable = false;
    }
}
