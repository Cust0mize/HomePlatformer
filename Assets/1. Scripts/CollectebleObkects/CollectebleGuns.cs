using UnityEngine;

public class CollectebleGuns : CollectebleObjects
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory player))
        {
            player.TakeGunByIndex(player.Guns.Count - 1);
            Die();
        }
    }
}