using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speedRotate = 200 ;
    
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * _speedRotate);
    }
}
