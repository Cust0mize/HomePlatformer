using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(_particlePrefab, transform.position, transform.rotation);
    }
}
