using UnityEngine;
using DG.Tweening;

public abstract class Enemy : MonoBehaviour, IDamageble
{
    protected Transform PlayerTransform;
    private Renderer[] _enemyRenderer;
    private AudioSource _damageSound;
    private int _damage;
    private int _health;

    protected void Inicialize(int damage, int health, Renderer[] enemyRenderer = null, AudioSource damageSound = null)
    {
        PlayerTransform = FindObjectOfType<PlayerMovement>().transform;
        _damage = damage;
        _health = health;
        _enemyRenderer = enemyRenderer;
        _damageSound = damageSound;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
            if (other.attachedRigidbody.TryGetComponent(out PlayerHealth player))
                player.ApplayDamage(_damage);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
            if (collision.rigidbody.TryGetComponent(out PlayerHealth player))
                player.ApplayDamage(_damage);
    }

    public void ApplayDamage(int damage)
    {
        _health -= damage;
        PlayDamageEffects();
        if (_health <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void PlayDamageEffects()
    {
        if (_enemyRenderer == null) return;
        Material[] material = new Material[_enemyRenderer.Length];
        for (int i = 0; i < _enemyRenderer.Length; i++)
        {
            for (int j = 0; j < _enemyRenderer[i].materials.Length; j++)
            {
                material[i] = _enemyRenderer[i].materials[j];
                material[i].SetColor("_EmissionColor", Color.clear);
                material[i].DOColor(Color.red, "_EmissionColor", 0.1f).SetLoops(10, LoopType.Yoyo).Restart(true);
            }
        }
        _damageSound?.Play();
    }

    protected virtual void MoveToPlayer()
    {
    }
}