using UnityEngine;

public class ShotgunLoot : CollectebleObjects
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory player))
        {
            player.AddGun(other.attachedRigidbody.GetComponentInChildren<Shotgun>(true));
            player.TakeGunByIndex(3);
            Die();
        }
    }
}
