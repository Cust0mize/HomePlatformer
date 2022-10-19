using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rateCameraLerp;

    private void Update()
    {
        if (_target == null) return;
        transform.position = Vector3.Lerp(transform.position, _target.position, _rateCameraLerp * Time.deltaTime);
    }
}
