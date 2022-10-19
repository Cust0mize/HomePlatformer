using UnityEngine;
using UnityEngine.Events;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] protected GameObject SpawnObjectPrefab;
    [SerializeField] protected UnityEvent PlayScreemSound;
    [SerializeField] protected UnityEvent PlayThrowSound;

    public virtual void Create()
    {
        Instantiate(SpawnObjectPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }

    public void OnPlayScreemSound() => PlayScreemSound?.Invoke();

    public void OnPlayThrowSound() => PlayThrowSound?.Invoke();
}
