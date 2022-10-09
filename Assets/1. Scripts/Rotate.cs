using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _speedRotate;

    void Update()
    {
        transform.Rotate(_speedRotate * Time.deltaTime);
    }
}
