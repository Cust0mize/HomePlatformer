using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageble
{
    private int _damage;
    private float _speedMove;
    private int _health;


    protected void Inicialize(int damage, float speedMove, int health)
    {
        _damage = damage;
        _speedMove = speedMove;
        _health = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerHealth>())
            other.GetComponentInParent<PlayerHealth>().ApplayDamage(_damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<PlayerHealth>())
            collision.gameObject.GetComponentInParent<PlayerHealth>().ApplayDamage(_damage);
    }

    public void ApplayDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    protected virtual void Move()
    {

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}