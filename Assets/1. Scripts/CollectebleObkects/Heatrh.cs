using UnityEngine;

public class Heatrh : CollectebleObjects
{
    private int _numberHealth = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.AddHealth(_numberHealth);
            Die();
        }
    }
}
