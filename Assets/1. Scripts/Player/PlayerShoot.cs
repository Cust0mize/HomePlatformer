using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _gun.Shoot();
        }
    }
}