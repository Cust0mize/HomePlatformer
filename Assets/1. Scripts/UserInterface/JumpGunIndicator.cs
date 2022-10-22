using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JumpGunIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private Image _imageForGround;
    [SerializeField] private CanvasGroup _imageBackGround;
    [SerializeField] private JumpGun _jumpGun;
    private Tween _fillMountAnimation;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void Start()
    {
        EventManager.JumpGun += JumpGunReload;
    }

    private void Update()
    {
        RefreshTimer();
        if (_isPaused)
        {
            _fillMountAnimation.Pause();
        }
        if (_jumpGun.StartTimer && !_isPaused)
        {
            _fillMountAnimation.Play();
        }
    }

    private void RefreshTimer()
    {
        if (_isPaused || !_jumpGun.StartTimer) return;
        _imageBackGround.alpha = 0.2f;
        _timer.gameObject.SetActive(true);
        _timer.text = $"{_jumpGun._timeCharged:f0}";

        if (_jumpGun._timeCharged <= 0)
        {
            _imageBackGround.alpha = 1;
            _timer.gameObject.SetActive(false);
        }
    }

    private void JumpGunReload(float time)
    {
        if (_isPaused) return;
        _fillMountAnimation = _imageForGround.DOFillAmount(0, time).SetUpdate(true);
        _imageForGround.fillAmount = 1;
        _fillMountAnimation.Play();
        _timer.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EventManager.JumpGun -= JumpGunReload;
    }
}
