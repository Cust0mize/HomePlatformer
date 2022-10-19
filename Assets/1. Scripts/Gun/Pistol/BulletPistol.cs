using UnityEngine;

public class BulletPistol : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    private int _damage = 1;

    private void Start()
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
