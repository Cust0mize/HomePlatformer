using UnityEngine;

public class CarrotCreator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _carrotPrefab;

    public void CreateCarrot()
    {
        Instantiate(_carrotPrefab, _spawnPoint.position, Quaternion.identity);
    }
}
