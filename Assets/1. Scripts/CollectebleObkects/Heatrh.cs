using UnityEngine;

public class Heatrh : CollectebleObjects
{
    private int _numberHealth = 1;
    [SerializeField] private AudioSource _destroySound;

    private void Start()
    {
        Inicialize(_destroySound);
    }

    protected override void Test(PlayerHealth stats)
    {
        stats.AddHealth(_numberHealth);
        base.Test(stats);
    }
}
