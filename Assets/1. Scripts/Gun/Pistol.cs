public class Pistol : Gun
{

    private void Start()
    {
        ReloadTime = 0.3f;
        BulletSpeed = 9;
        Initialize(ReloadTime, BulletSpeed);
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}