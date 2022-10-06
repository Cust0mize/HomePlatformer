using UnityEngine;

public class Chicken : Enemy
{
    private Rigidbody _ckickenRigibody;
    private Transform _target;

    private void Start()
    {
        _ckickenRigibody = GetComponent<Rigidbody>();
        _target = FindObjectOfType<PlayerMovement>().transform;
        Damage = 1;
        SpeedMove = 0.07f;
        Inicialize(Damage, SpeedMove);
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        if (Vector3.Distance(_target.position, transform.position) < 100)
        {
            Vector3 offcet =  _target.position - transform.position;
            _ckickenRigibody.MovePosition(Vector3.MoveTowards(transform.position, _target.position, SpeedMove));
        }
    }
}
