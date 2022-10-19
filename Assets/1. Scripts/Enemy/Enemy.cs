using UnityEngine;
using DG.Tweening;

public abstract class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private Renderer[] _enemyRenderer;
    protected Transform PlayerTransform;
    private AudioSource _damageSound;
    [field: SerializeField] public float VisibilityDistance { get; protected set; }
    private int _damage;
    private int _health;

    protected void Inicialize(int damage, int health, AudioSource damageSound = null)
    {
        PlayerTransform = FindObjectOfType<PlayerMovement>().transform;
        _damage = damage;
        _health = health;
        _damageSound = damageSound;
    }

    private void Touch(Collider collider)
    {
        if (collider.attachedRigidbody != null)
            if (collider.attachedRigidbody.TryGetComponent(out PlayerHealth player))
                player.ApplayDamage(_damage);
    }

    public void ApplayDamage(int damage)
    {
        _health -= damage;
        PlayDamageEffects();
        PlayDamageSound();
        if (_health <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void DieOnAnyCollision(Collider collider)
    {
        if (!collider.isTrigger)
            Die();
    }

    protected virtual void PlayDamageEffects()
    {
        if (_enemyRenderer == null) return;
        for (int i = 0; i < _enemyRenderer.Length; i++)
        {
            for (int j = 0; j < _enemyRenderer[i].materials.Length; j++)
            {
                Material material = _enemyRenderer[i].materials[j];
                material.SetColor("_EmissionColor", Color.clear);
                material.DOColor(Color.red, "_EmissionColor", 0.1f).SetLoops(10, LoopType.Yoyo).Restart(true);
            }
        }
    }

    protected virtual void PlayDamageSound()
    {
        _damageSound?.Play();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Touch(other);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Touch(collision.collider);
    }
}