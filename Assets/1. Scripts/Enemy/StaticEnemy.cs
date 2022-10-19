using UnityEngine;

public class StaticEnemy : Enemy
{
    protected void RotateToPlayer(Vector3 targetEuler, float rightEuler, float leftEuler, float speedRotate)
    {
        if (PlayerTransform == null) return;
        if (transform.position.x < PlayerTransform.position.x)
            targetEuler.y = rightEuler;
        else
            targetEuler.y = leftEuler;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetEuler), speedRotate * Time.deltaTime);
    }
}

