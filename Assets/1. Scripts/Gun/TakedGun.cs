using UnityEngine;
using TMPro;

public class TakedGun : Gun
{
    [Header("TakedGun")]
    [SerializeField] protected TextMeshProUGUI NumberOfBullet;
    [SerializeField] private PlayerArmory _playerArmory;
    private static int NumberOfBullets;

    private void Start()
    {
        UpdateNumbetOfBullet();
    }

    public override void Shoot()
    {
        
        if (NumberOfBullets > 0)
        {
            if (!BulletIsReady) return;
            base.Shoot();
            NumberOfBullets--;
            UpdateNumbetOfBullet();
        }
        else
        {
            _playerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        UpdateNumbetOfBullet();
        NumberOfBullet.gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        NumberOfBullet.gameObject.SetActive(false);
    }

    public void AddBullet(int value)
    {
        NumberOfBullets += value;
        UpdateNumbetOfBullet();
    }

    private void UpdateNumbetOfBullet()
    {
        NumberOfBullet.text = $"Пули: {NumberOfBullets}";
    }

    private void OnDestroy()
    {
        NumberOfBullets = 0;
    }
}
