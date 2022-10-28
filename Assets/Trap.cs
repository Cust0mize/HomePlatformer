using DG.Tweening;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Rigidbody _rigibody;
    [SerializeField] private float _delay;
    private Sequence _sequence;
    private Vector3 startPosition;

    private void Awake()
    {
        _targetPoint.SetParent(null);
        startPosition = transform.position;
    }

    private void Start()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOShakePosition(0.9f, 0.1f, 50));
        _sequence.Append(_rigibody.DOMove(_targetPoint.position, 0.1f));
        _sequence.Append(_rigibody.DOMove(_targetPoint.position, 1f));
        _sequence.Append(_rigibody.DOMove(startPosition, 3));
        _sequence.SetLoops(-1, LoopType.Restart).SetDelay(_delay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.attachedRigidbody.TryGetComponent(out IDamageble damageble))
        {
            damageble.ApplayDamage(damageble.Health);
        }
    }
}