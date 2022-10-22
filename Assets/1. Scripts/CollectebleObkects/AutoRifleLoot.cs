using UnityEngine;

public class AutoRifleLoot : CollectebleObjects
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory player))
        {
            player.AddGun(other.attachedRigidbody.GetComponentInChildren<AutoRifle>(true));
            player.TakeGunByIndex(1);
            Die();
        }
    }
}
