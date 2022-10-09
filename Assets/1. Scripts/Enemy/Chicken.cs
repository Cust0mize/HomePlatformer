using UnityEngine;

public class Chicken : Enemy
{
    [SerializeField] private Renderer[] _chickenRenderer;
    [SerializeField] private AudioSource _chickenSoundDamage;
    [SerializeField] private float _chickenSpeedMove = 3f;
    [SerializeField] private float _chickenTimeToReachSpeed = 1f;
    private Rigidbody _ckickenRigibody;
    private int _damage = 1;
    private int _health = 2;

    private void Start()
    {
        _ckickenRigibody = GetComponent<Rigidbody>();
        Inicialize(_damage, _health, _chickenRenderer, _chickenSoundDamage);
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    protected override void MoveToPlayer()
    {
        Vector3 toPlayer = (PlayerTransform.position - transform.position).normalized;
        Vector3 force = _ckickenRigibody.mass * (toPlayer * _chickenSpeedMove - _ckickenRigibody.velocity) / _chickenTimeToReachSpeed;
        _ckickenRigibody.AddForce(force);
    }
}
