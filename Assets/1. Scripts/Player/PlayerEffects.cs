using UnityEngine;
using DG.Tweening;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private Renderer[] _playerRenderers;
    [SerializeField] private PlayerHealth _player;
    private int _timeValueMultiplier = 10;

    private void Start()
    {
        EventManager.RemoveHealth += DamageAnimation;
    }

    private void DamageAnimation()
    {
        for (int i = 0; i < _playerRenderers.Length; i++)
        {
            Material material = _playerRenderers[i].material;
            material.DOColor(Color.red, "_EmissionColor", _player.InvulnerableTime/ _timeValueMultiplier).SetLoops((int)_player.InvulnerableTime * _timeValueMultiplier, LoopType.Yoyo);
        }
    }
}
