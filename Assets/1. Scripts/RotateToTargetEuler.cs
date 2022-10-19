using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] private Vector3 _rightEuler;
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private float _rotationSpeed = 10;
    private Vector3 _targetEuler;

    private void Update()
    {
        RotateToPEuler();
    }

    private void RotateToPEuler()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), _rotationSpeed * Time.deltaTime);
    }

    public void RotateToLeft()
    {
        _targetEuler = _leftEuler;
    }

    public void RotateToRight()
    {
        _targetEuler = _rightEuler;
    }
}
