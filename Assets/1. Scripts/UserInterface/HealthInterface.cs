using System.Collections.Generic;
using UnityEngine;

public class HealthInterface : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private Transform _parentHealth;
    [SerializeField] private Transform _hearthPrefab;
    [SerializeField] private List<Transform> _hearthIcons = new List<Transform>();

    private void Start()
    {
        EventManager.AddHealth += OnAddHealth;
        EventManager.RemoveHealth += OnRemoveHealth;
        for (int i = 0; i < _player.MaxHealth; i++)
        {
            Transform newHearth = Instantiate(_hearthPrefab, _parentHealth.transform);
            _hearthIcons.Add(newHearth);
        }
        for (int i = 0; i < _player.Health; i++)
            _hearthIcons[i].gameObject.SetActive(true);
    }

    private void OnRemoveHealth()
    {
        _hearthIcons[_player.Health].gameObject.SetActive(false);
    }

    private void OnAddHealth()
    {
        _hearthIcons[_player.Health - 1].gameObject.SetActive(true);
    }
}
