using UnityEngine;

public class SniperRifleLoot : CollectebleGuns
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory player))
        {
            player.AddGun(other.attachedRigidbody.GetComponentInChildren<SniperRifle>(true));
            base.OnTriggerEnter(other);
        }
    }
}