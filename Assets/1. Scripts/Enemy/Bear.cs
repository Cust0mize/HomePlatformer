using System.Collections;
using UnityEngine;

public class Bear : StaticEnemy
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _bearLeftEuler;
    [SerializeField] private float _bearRightEuler;
    [SerializeField] private float _bearSpeedRotate;
    private Vector3 _bearTargetEuler;
    private int _damage = 1;
    private int _health = 2;
    private float _attackPeriod = 7;

    protected override void Start()
    {
        base.Start();
        Inicialize(_damage, _health);
    }

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
