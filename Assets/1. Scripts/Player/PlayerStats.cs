using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageble
{
    private int _health = 100;

    public void ApplayDamage(int damage)
    {
        _health -= damage;
        print(_health);

        if (_health <= 0)
            print("GameOver");
    }
}
