using UnityEngine;
using Player;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private float _rateCameraLerp;
    private bool _jumpGunIsActive;

    private void Start() => EventManager.JumpGun += JumpGunOn;

    private void Update()
    {
        if (_target == null) return;

        if (!_playerMove.IsGround && _jumpGunIsActive)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position - new Vector3(0, 2f, 15), _rateCameraLerp * Time.deltaTime / 3);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _rateCameraLerp * Time.deltaTime);
            _jumpGunIsActive = false;
        }
    }

    private void JumpGunOn(float time)
    {
        _jumpGunIsActive = true;
    }
}