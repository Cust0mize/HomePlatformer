using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private int _damage;

    protected void Inicialize(int damage)
    {
        _damage = damage;
    }

    private  void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(other);
    }

    private void Hit(Collider collider)
    {
        if (collider.GetComponent<PlayerMovement>()) return;
        if (collider.TryGetComponent(out IDamageble damageble))
        {
            DestroyBullet();
            damageble.ApplayDamage(_damage);
        }

        if (!collider.isTrigger)
            DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
        Instantiate(_particlePrefab, transform.position, transform.rotation);
    }
}
