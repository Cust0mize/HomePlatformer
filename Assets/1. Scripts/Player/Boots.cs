using Infrastructure;
using Services.Input;
using UnityEngine;

public class Boots : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerBodyTransform;
    [SerializeField] private Transform _bootsPoint;
    private IInputService _inputService;

    private void Awake()
    {
        _inputService = Game.InputService;
    }

    private void Update()
    {
        transform.position = _bootsPoint.position;
        float dot = -Vector3.Dot(_playerBodyTransform.forward, _inputService.Axis);
        float sigh = Mathf.Sign(dot);
        float blandValue = sigh * Mathf.Abs(_inputService.Axis.x);
        _animator.speed = Mathf.Abs(blandValue);
        _animator.SetFloat("Blend", blandValue);
    }
}