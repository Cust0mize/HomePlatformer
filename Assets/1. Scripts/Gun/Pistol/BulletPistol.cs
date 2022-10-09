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
        if (collision.gameObject.GetComponent<PlayerMovement>()) return;
        Destroy(gameObject);
        Instantiate(_particlePrefab, transform.position, transform.rotation);
        if (collision.gameObject.TryGetComponent(out IDamageble damageble))
            damageble.ApplayDamage(_damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Enemy>()) return;
        Destroy(gameObject);
        Instantiate(_particlePrefab, transform.position, transform.rotation);
        if (other.TryGetComponent(out IDamageble damageble))
            damageble.ApplayDamage(_damage);
    }
}
