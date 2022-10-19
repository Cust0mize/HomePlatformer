using UnityEngine;

public class Acorn : StaticEnemy
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed;
    private int _damage = 1;
    private int _health = 1;

    protected override void Start()
    {
        base.Start();
        Inicialize(_damage, _health);
        GetComponent<Rigidbody>().AddRelativeForce(_velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
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
