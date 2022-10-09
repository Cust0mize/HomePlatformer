using DG.Tweening;
using UnityEngine;

public class BloodScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _screen;
    [SerializeField] private PlayerHealth _player;

    private void Start()
    {
        EventManager.RemoveHealth += ScreenAnimation;
    }

    private void ScreenAnimation()
    {
        _screen.gameObject.SetActive(true);
        _screen.alpha = 1f;
        _screen.DOFade(0, _player.InvulnerableTime);
        Invoke(nameof(BloodScreenOff), _player.InvulnerableTime);
    }

    private void BloodScreenOff()
    {
        _screen.gameObject.SetActive(false);
    }
}
