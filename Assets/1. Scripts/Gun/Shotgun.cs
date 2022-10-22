using UnityEngine;

public class Shotgun : TakedGun
{
    [Header("Shotgun")]
    [SerializeField] private Transform[] _spawnPoints;

    protected override void CreateBullet()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Rigidbody bullet = Instantiate(BulletRigibody, _spawnPoints[i].position, _spawnPoints[i].rotation);
            bullet.AddForce(transform.forward * BulletSpeed, ForceMode.VelocityChange);
            BulletIsReady = false;
        }
    }
}
