using UnityEngine;

public class PigHead : MonoBehaviour
{
    public Vector3 qwe;
    public Transform cam;
    private void Update()
    {
        Vector3 direction = transform.position - cam.transform.position;
        transform.rotation = Quaternion.LookRotation(direction, transform.forward);

    }
}
