using System.Collections;
using UnityEngine;

public class Rabbit : Enemy
{
    [SerializeField] private Animator _animator;
    private int _damage = 1;
    private int _health = 3;
    private float _attackPeriod = 7;

    private void Start()
    {
        Inicialize(_damage, _health);
        StartCoroutine(OnAnimationAttack());
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Die();
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
