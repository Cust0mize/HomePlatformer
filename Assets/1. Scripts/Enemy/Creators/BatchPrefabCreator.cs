using UnityEngine;

public class BatchPrefabCreator : PrefabCreator
{
    [SerializeField] private Transform[] _spawnPoints;

    public override void Create()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(SpawnObjectPrefab, _spawnPoints[i].position, _spawnPoints[i].rotation); ;
        }
    }
}
