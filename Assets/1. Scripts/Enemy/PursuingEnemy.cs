using UnityEngine;

public abstract class PursuingEnemy : Enemy
{
    protected virtual void MoveToPlayer()
    {
        if (PlayerTransform == null) return;
    }
}
