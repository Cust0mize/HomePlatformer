using UnityEngine;

public class Rocket : PursuingEnemy
{
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedMove;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void Update()
    {
        if (_isPaused) return;
        MoveToPlayer();
    }

    protected override void MoveToPlayer()
    {
        if (PlayerTransform == null) return;
        transform.position += transform.forward * _speedMove * Time.deltaTime;
        Vector3 targetDirection = PlayerTransform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _speedRotate * Time.deltaTime, 10f);
        transform.rotation = Quaternion.LookRotation(newDirection, Vector3.forward);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        DieOnAnyCollision(other);
    }
}
