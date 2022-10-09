using UnityEngine;
using DG.Tweening;

public class PlayerEffects : MonoBehaviour
{
    private Renderer _player;
    private void Start()
    {
        EventManager.RemoveHealth += DamageAnimation;
        _player = transform.GetComponentInChildren<Renderer>();
    }

    private void DamageAnimation()
    {
        //_player.material.DOFade();
    }
}
