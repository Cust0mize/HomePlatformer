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
                if (Mathf.Abs(_enemys[i].transform.position.x - _playerTransform.position.x) < _enemys[i].VisibilityDistanceX && Mathf.Abs(_enemys[i].transform.position.y - _playerTransform.position.y) < _enemys[i].VisibilityDistanceY)
                {
                    _enemys[i].gameObject.SetActive(true);
                }
                else
                {
                    _enemys[i].gameObject.SetActive(false);
                }
            }
            yield return new WaitForSecondsRealtime(1f);
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