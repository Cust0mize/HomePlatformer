using UnityEngine;

public class Pistol : Gun
{
    [SerializeField] private float _reloadTime = 0.3f;
    [SerializeField] private float _bulletSpeed = 7f;

    private void Start()
    {
        Initialize(_reloadTime, _bulletSpeed);
    }
}