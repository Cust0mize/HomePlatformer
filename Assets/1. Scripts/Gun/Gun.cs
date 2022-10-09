using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletRigibody;
    [SerializeField] private GameObject _muzleFlash;
    [SerializeField] protected Transform BulletSpawnPoint;
    [SerializeField] protected AudioSource _shootSound;

    private float _reloadTime;
    private float _bulletSpeed;
    private bool _bulletIsReady = true;

    protected void Initialize(float reloadTime, float bulletSpeed)
    {
        _reloadTime = reloadTime;
        _bulletSpeed = bulletSpeed;
    }

    public virtual void Shoot()
    {
        if (_bulletIsReady)
        {
            _shootSound.Play();
            Rigidbody bullet = Instantiate(_bulletRigibody, BulletSpawnPoint.position, Quaternion.identity);
            bullet.AddForce(transform.forward * _bulletSpeed, ForceMode.VelocityChange);
            _bulletIsReady = false;
            StartCoroutine(Reload(_reloadTime));
            StartCoroutine(Flash(0.1f));
        }
    }

    private IEnumerator Reload(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        _bulletIsReady = true;
    }

    private IEnumerator Flash(float timeFlash)
    {
        _muzleFlash.SetActive(true);
        yield return new WaitForSeconds(timeFlash);
        _muzleFlash.SetActive(false);
    }
}