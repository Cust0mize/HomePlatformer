using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Chicken : PursuingEnemy
{
    private Rigidbody _ckickenRigibody;
    [SerializeField] private float _chickenSpeedMove = 3f;
    [SerializeField] private float _chickenTimeToReachSpeed = 1f;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;

    protected override void Start()
    {
        base.Start();
        _ckickenRigibody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_isPaused) return;
        MoveToPlayer();
    }

    protected override void MoveToPlayer()
    {
        if (PlayerTransform == null) return;
        Vector3 toPlayer = (PlayerTransform.position - transform.position).normalized;
        Vector3 force = _ckickenRigibody.mass * (toPlayer * _chickenSpeedMove - _ckickenRigibody.velocity) / _chickenTimeToReachSpeed;
        _ckickenRigibody.AddForce(force);
    }
}
