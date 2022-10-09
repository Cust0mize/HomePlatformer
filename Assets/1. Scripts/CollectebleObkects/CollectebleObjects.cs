using UnityEngine;

public class CollectebleObjects : MonoBehaviour
{
    protected AudioSource DestroyebleSound;

    protected void Inicialize(AudioSource destroyebleSound)
    {
        DestroyebleSound = destroyebleSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth stats))
        {
            Test(stats);
        }
    }

    protected virtual void Test(PlayerHealth stats)
    {
        Die();
    }

    private void Die()
    {
        DestroyebleSound.transform.SetParent(null);
        DestroyebleSound.Play();
        Destroy(gameObject);
        Destroy(DestroyebleSound.gameObject, 2f);
    }
}
