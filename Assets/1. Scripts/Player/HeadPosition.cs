using UnityEngine;

public class HeadPosition : MonoBehaviour
{
    [SerializeField] private Transform _head;

    private void Update()
    {
        transform.position = _head.position;
    }
}
