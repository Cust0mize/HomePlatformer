using System.Collections;
using UnityEngine;

public class Rabbit : StaticEnemy
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _rabbitLeftEuler;
    [SerializeField] private float _rabbitRightEuler;
    [SerializeField] private float _rabbitSpeedRotate;
    private Vector3 _rabbitTargetEuler;
    private int _damage = 1;
    private int _health = 3;
    private float _attackPeriod = 7;

    protected override void Start()
    {
        base.Start();
        Inicialize(_damage, _health);
    }

    private void Update()
    {
        RotateToPlayer(_rabbitTargetEuler, _rabbitRightEuler, _rabbitLeftEuler, _rabbitSpeedRotate);
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
}
