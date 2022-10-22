using UnityEngine;

public class CollectebleObjects : MonoBehaviour
{
    [SerializeField] protected AudioSource DestroyebleSound;

    protected void Die()
    {
        DestroyebleSound.transform.SetParent(null);
        DestroyebleSound.Play();
        Destroy(gameObject);
        Destroy(DestroyebleSound.gameObject, DestroyebleSound.clip.length);
    }
}
