using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckerPosition : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private List<Enemy> _enemys = new List<Enemy>();

    private void Start()
    {
        StartCoroutine(ChechPosition());
    }

    private IEnumerator ChechPosition()
    {
        while (true)
        {
            for (int i = 0; i < _enemys.Count; i++)
            {
                print(Vector3.Distance(new Vector3(_enemys[0].transform.position.x, 0, 0), new Vector3(_playerTransform.position.x, 0, 0)));
                if (Vector3.Distance(new Vector3(_enemys[i].transform.position.x, 0, 0), new Vector3(_playerTransform.position.x, 0, 0)) < _enemys[i].VisibilityDistance && Vector3.Distance(new Vector3(-1, _enemys[i].transform.position.y, -1), new Vector3(0, _playerTransform.position.y, 0)) < _enemys[i].VisibilityDistance / 2)
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

    public void AddToPositionList(Enemy enemy)
    {
        _enemys.Add(enemy);
    }

    public void RemoveToPositionList(Enemy enemy)
    {
        _enemys.Remove(enemy);
    }
}
