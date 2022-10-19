using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckerPosition : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private List<Enemy> _enemys = new List<Enemy>();

    private void Start()
    {
        _enemys = FindObjectsOfType<Enemy>().ToList();
        StartCoroutine(ChechPosition());
    }

    private IEnumerator ChechPosition()
    {
        while (true)
        {
            for (int i = 0; i < _enemys.Count; i++)
            {
                if (_enemys[i] == null) continue;
                if (_enemys[i].transform.position.x - _playerTransform.position.x < _enemys[i].VisibilityDistance && _enemys[i].transform.position.y - _playerTransform.position.y < _enemys[i].VisibilityDistance / 2)
                {
                    _enemys[i].gameObject.SetActive(true);
                }
                else
                {
                    _enemys[i].gameObject.SetActive(false);
                }
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
