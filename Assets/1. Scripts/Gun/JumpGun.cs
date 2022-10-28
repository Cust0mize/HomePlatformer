using System.Collections;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigibody;
    [SerializeField] private Transform _spawn;
    [SerializeField] private PlayerArmory _player;
    [SerializeField] private float _jumpSpeed = 14f;
    [SerializeField] public float _timeCharged { get; private set; } = 3f;
    private Coroutine _chargedCorutine;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;
    private bool _isCharged = true;
    public bool _pausedActivated { get; private set; }
    public bool StartTimer { get; private set; }

    private void Update()
    {
        Timer();
        PauseChecker();
        UnPauseChecker();
        JumpGunActive();
    }

    private void JumpGunActive()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_isCharged)
            {
                if (_player.CurrentGun.BulletIsReady)
                {
                    _playerRigibody.AddForce(-_spawn.forward * _jumpSpeed, ForceMode.VelocityChange);
                    _player.CurrentGun.Shoot();
                    _isCharged = false;
                    EventManager.OnJumpGun(_timeCharged);
                    _chargedCorutine = StartCoroutine(OnIsCharged(_timeCharged));
                }
            }
        }
    }

    private void Timer()
    {
        if (StartTimer)
        {
            _timeCharged -= Time.unscaledDeltaTime;
        }
    }

    private void PauseChecker()
    {
        if (_isPaused && !_isCharged)
        {
            StopCoroutine(_chargedCorutine);
            StartTimer = false;
            _pausedActivated = true;
        }
    }

    private void UnPauseChecker()
    {
        if (_pausedActivated && !_isPaused)
        {
            _pausedActivated = false;
            _chargedCorutine = StartCoroutine(OnIsCharged(_timeCharged));
        }
    }

    private IEnumerator OnIsCharged(float time)
    {
        StartTimer = true;
        yield return new WaitForSecondsRealtime(time);
        _timeCharged = 3f;
        StartTimer = false;
        _isCharged = true;
    }
}