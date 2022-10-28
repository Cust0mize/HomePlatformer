using UnityEngine;

public class ShotgunLoot : CollectebleGuns
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory player))
        {
            player.AddGun(other.attachedRigidbody.GetComponentInChildren<Shotgun>(true));
            base.OnTriggerEnter(other);
        }
    }
}