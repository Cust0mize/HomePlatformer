using System.Collections;
using UnityEngine;

public class Bear : StaticEnemy
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _bearLeftEuler;
    [SerializeField] private float _bearRightEuler;
    [SerializeField] private float _bearSpeedRotate;
    private Vector3 _bearTargetEuler;
    private float _attackPeriod = 4;

    private void Update()
    {
        RotateToPlayer(_bearTargetEuler, _bearRightEuler, _bearLeftEuler, _bearSpeedRotate);
    }

    private void OnEnable()
    {
        StartCoroutine(OnAnimationAttack());
    }

    private IEnumerator OnAnimationAttack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(_attackPeriod);
            _animator.SetTrigger("Attack");
        }
    }

    protected override void PlayDamageEffects()
    {
        base.PlayDamageEffects();
        _animator.SetTrigger("Damage");
    }
}
