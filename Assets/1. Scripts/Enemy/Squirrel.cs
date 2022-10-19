using System.Collections;
using UnityEngine;

public class Squirrel : StaticEnemy
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource[] _squirrelSoundAttack;
    [SerializeField] private float _attackPeriod = 4;
    private int _damage = 1;
    private int _health = 2;

    protected override void Start()
    {
        base.Start();
        Inicialize(_damage, _health);
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
