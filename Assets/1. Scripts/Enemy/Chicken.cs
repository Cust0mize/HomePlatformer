using UnityEngine;

public class Chicken : Enemy
{
    private Rigidbody _ckickenRigibody;
    private Transform _target;
    private int _damage = 1;
    private float _speedMove = 0.07f;
    private int _health = 3;

    private void Start()
    {
        _ckickenRigibody = GetComponent<Rigidbody>();
        _target = FindObjectOfType<PlayerMovement>().transform;
        Inicialize(_damage, _speedMove, _health);
    }

    private void FixedUpdate()
    {
        //Move();
    }

    protected override void Move()
    {
        if (Vector3.Distance(_target.position, transform.position) < 100)
        {
            Vector3 offcet = _target.position - transform.position;
            _ckickenRigibody.MovePosition(Vector3.MoveTowards(transform.position, _target.position, _speedMove));
        }
    }
}
