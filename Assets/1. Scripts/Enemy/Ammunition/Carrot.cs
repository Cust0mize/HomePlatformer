using UnityEngine;

public class Carrot : PursuingEnemy
{
    [SerializeField] private Rigidbody _carrotRigibody;
    [SerializeField] private float _carrotSpeedMove = 10;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;

    protected override void Start()
    {
        base.Start();
        if (_isPaused) return;
        MoveToPlayer();
    }

    protected override void MoveToPlayer()
    {
        if (PlayerTransform == null) return;
        Vector3 toPlayer = (PlayerTransform.position - transform.position).normalized;
        _carrotRigibody.velocity = toPlayer * _carrotSpeedMove;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Die();
    }
}
