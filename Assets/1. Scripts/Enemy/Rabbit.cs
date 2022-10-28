using System.Collections;
using UnityEngine;

public class Rabbit : StaticEnemy
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _rabbitLeftEuler;
    [SerializeField] private float _rabbitRightEuler;
    [SerializeField] private float _rabbitSpeedRotate;
    private Vector3 _rabbitTargetEuler;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;
    private float _attackPeriod = 4;

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