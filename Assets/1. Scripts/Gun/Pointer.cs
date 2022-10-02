using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _scope;

    private void Update()
    {
        SetScopePosition();
        RotateToGun();
    }
    private void SetScopePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        plane.Raycast(ray, out float distance);
        _scope.position = ray.GetPoint(distance);
    }

    private void RotateToGun()
    {
        Vector3 direction = _scope.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
