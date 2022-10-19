using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Chicken : PursuingEnemy
{
    [SerializeField] private AudioSource _chickenSoundDamage;
    private Rigidbody _ckickenRigibody;
    [SerializeField] private float _chickenSpeedMove = 3f;
    [SerializeField] private float _chickenTimeToReachSpeed = 1f;
    
    private int _damage = 1;
    private int _health = 2;

    protected override void Start()
    {
        base.Start();
        _ckickenRigibody = GetComponent<Rigidbody>();
        Inicialize(_damage, _health, _chickenSoundDamage);
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    protected override void MoveToPlayer()
    {
        base.MoveToPlayer();
        Vector3 toPlayer = (PlayerTransform.position - transform.position).normalized;
        Vector3 force = _ckickenRigibody.mass * (toPlayer * _chickenSpeedMove - _ckickenRigibody.velocity) / _chickenTimeToReachSpeed;
        _ckickenRigibody.AddForce(force);
    }
}
