using UnityEngine;

public class EffectorPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _forceVector;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.attachedRigidbody.TryGetComponent(out Rigidbody rigibody))
        {
            rigibody.AddForce(_forceVector * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}