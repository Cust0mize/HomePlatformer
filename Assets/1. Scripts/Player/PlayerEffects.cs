using UnityEngine;
using DG.Tweening;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private Renderer[] _playerRenderers;
    [SerializeField] private AudioSource _soundDamage;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private CanvasGroup _screen;
    private int _timeValueMultiplier = 10;

    private void Start()
    {
        EventManager.RemoveHealth += PlayDamageEffects;
    }

    private void PlayDamageEffects()
    {
        Blink();
        PlaySoundDamage();
        BloodScreen();
    }

    private void Blink()
    {
        for (int i = 0; i < _playerRenderers.Length; i++)
        {
            Material material = _playerRenderers[i].material;
            material.DOColor(Color.red, "_EmissionColor", _player.InvulnerableTime / _timeValueMultiplier).SetLoops((int)_player.InvulnerableTime * _timeValueMultiplier, LoopType.Yoyo);
        }
    }

    private void PlaySoundDamage()
    {
        _soundDamage.Play();
    }

    private void BloodScreen()
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
