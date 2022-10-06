using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int Damage;
    protected float SpeedMove;

    protected void Inicialize(int damage, float speedMove)
    {
        Damage = damage;
        SpeedMove = speedMove;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerStats>())
            other.GetComponentInParent<PlayerStats>().ApplayDamage(Damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<PlayerStats>())
            collision.gameObject.GetComponentInParent<PlayerStats>().ApplayDamage(Damage);
    }

    protected virtual void Move()
    {
        
    }
}