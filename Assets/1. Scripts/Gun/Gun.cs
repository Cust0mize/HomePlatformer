using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _muzleFlash;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] protected Rigidbody BulletRigibody;
    [SerializeField] protected Transform BulletSpawnPoint;
    [SerializeField] protected AudioSource ShootSound;
    [SerializeField] protected float ReloadTime;
    [SerializeField] protected float BulletSpeed;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;
    public bool BulletIsReady { get; protected set; } = true;

    private void OnEnable()
    {
        if (!BulletIsReady)
        {
            StartCoroutine(Reload());
        }
    }

    public virtual void Shoot()
    {
        if (!BulletIsReady || _isPaused) return;
        ShootSound.Play();
        CreateBullet();
        StartCoroutine(Reload());
        StartCoroutine(Flash());
    }

    protected virtual void CreateBullet()
    {
        Rigidbody bullet = Instantiate(BulletRigibody, BulletSpawnPoint.position, Quaternion.identity);
        bullet.AddForce(transform.forward * BulletSpeed, ForceMode.VelocityChange);
        BulletIsReady = false;
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
        _muzleFlash.SetActive(false);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(ReloadTime);
        BulletIsReady = true;
    }

    private IEnumerator Flash()
    {
        _muzleFlash.SetActive(true);
        _shootEffect.Play();
        yield return new WaitForSecondsRealtime(0.05f);
        _muzleFlash.SetActive(false);
        _shootEffect.Stop();
    }
}