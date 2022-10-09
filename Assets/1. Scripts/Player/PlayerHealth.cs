using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IDamageble
{
    [SerializeField] private AudioSource _soundDamage;
    [SerializeField] public int Health { get; private set; } = 5;
    [SerializeField] public int MaxHealth { get; private set; } = 8;
    [SerializeField] public float InvulnerableTime { get; private set; } = 1;
    private bool _invulnerable;

    void Update()
    {
        print(Health);
    }

    public void ApplayDamage(int damage)
    {
        if (!_invulnerable)
        {
            _invulnerable = true;
            _soundDamage.Play();
            Invoke(nameof(InvulnerableOff), InvulnerableTime);

            if (Health > 0)
            {
                Health -= damage;
                EventManager.OnRemoveHealth();
            }
            else
                Die();
        }
    }

    public void AddHealth(int healtValue)
    {
        if (Health < MaxHealth)
        {
            Health++;
            EventManager.OnAddHealth();
            print(Health);
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
