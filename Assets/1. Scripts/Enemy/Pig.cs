using UnityEngine;

public class Pig : PatrollingEnemy
{
    [SerializeField] private Transform _pigLeftPoint;
    [SerializeField] private Transform _pigRightPoint;
    [SerializeField] private float _pigRotationSpeed = 3;
    [SerializeField] private float _pigLeftAngle = -20;
    [SerializeField] private float _pigRightAngle = -150;
    [SerializeField] private float _pigSpeedMove = 3;
    [SerializeField] private float _pigStopTime = 0.5f;
    private Vector3 _pigTargetEuler;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;
    private bool _isStop;


    protected override void Start()
    {
        base.Start();
        DisableParent(ref _pigLeftPoint, ref _pigRightPoint);
    }

    private void Update()
    {
        if (_isStop || _isPaused) return;

        transform.rotation = RotateToTargetPoint(transform.rotation, _pigTargetEuler, _pigLeftAngle, _pigRightAngle, _pigRotationSpeed);
        transform.position = MoveToPoints(transform.position, _pigLeftPoint, _pigRightPoint, _pigSpeedMove);
        transform.position = ProjectoryToGround(transform.position);

        if (transform.position.x < _pigLeftPoint.position.x || transform.position.x > _pigRightPoint.position.x)
        {
            _isStop = true;
            Invoke(nameof(GoMove), _pigStopTime);
        }
    }

    private void GoMove()
    {
        _isStop = false;
    }
}
