using UnityEngine;

public class SniperRifleLoot : CollectebleObjects
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory player))
        {
            player.AddGun(other.attachedRigidbody.GetComponentInChildren<SniperRifle>(true));
            player.TakeGunByIndex(2);
            Die();
        }
    }
}
