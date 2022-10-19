using UnityEngine;

public class Rocket : PursuingEnemy
{
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedMove;
    private int _damage = 1;
    private int _health = 1;

    private void Start()
    {
        Inicialize(_damage, _health);
    }

    private void Update()
    {
        MoveToPlayer();
    }

    protected override void MoveToPlayer()
    {
        base.MoveToPlayer();
        Vector3 targetVector = transform.position + transform.forward;
        transform.position = Vector3.MoveTowards(transform.position, targetVector, _speedMove * Time.deltaTime);
        Vector3 targetDirection = PlayerTransform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _speedRotate * Time.deltaTime, 10f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        DieOnAnyCollision(other);
    }
}
