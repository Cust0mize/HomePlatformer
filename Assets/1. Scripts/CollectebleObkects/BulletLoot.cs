using UnityEngine;

public class BulletLoot : CollectebleObjects
{
    private int _bulletNumber = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.transform.GetComponentInChildren<TakedGun>(true))
        {
            other.attachedRigidbody.transform.GetComponentInChildren<TakedGun>(true).AddBullet(_bulletNumber);
            Die();
        }
    }
}
