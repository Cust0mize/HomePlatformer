using UnityEngine;

public class Acorn : StaticEnemy
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed;

    protected override void Start()
    {
        base.Start();
        Rigidbody rigibody = GetComponent<Rigidbody>();
        rigibody.AddRelativeForce(_velocity, ForceMode.VelocityChange);
        rigibody.angularVelocity = new Vector3(
        Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
        Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
        Random.Range(-_maxRotationSpeed, _maxRotationSpeed));
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        DieOnAnyCollision(other);
    }
}
