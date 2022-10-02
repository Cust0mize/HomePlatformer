using UnityEngine;

public class Gun : MonoBehaviour
{
    protected float ReloadTime;
    protected float BulletSpeed;
    protected float CurrentReloadTime;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] protected Transform BulletSpawnPoint;
    [SerializeField] protected AudioSource _shootSound;

    protected void Initialize(float reloadTime, float bulletSpeed)
    {
        ReloadTime = reloadTime;
        BulletSpeed = bulletSpeed;
    }

    public virtual void Shoot()
    {
        if (CurrentReloadTime <= 0)
        {
            _shootSound.Play();
            GameObject bullet = Instantiate(_bulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed, ForceMode.VelocityChange);
            CurrentReloadTime = ReloadTime;
        }
    }

    private void Update()
    {
        if (CurrentReloadTime > 0)
        {
            CurrentReloadTime -= Time.deltaTime;
        }
    }
}