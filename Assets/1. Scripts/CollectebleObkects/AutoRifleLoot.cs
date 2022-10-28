using UnityEngine;

public class AutoRifleLoot : CollectebleGuns
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory player))
        {
            player.AddGun(other.attachedRigidbody.GetComponentInChildren<AutoRifle>(true));
            base.OnTriggerEnter(other);
        }
    }
}