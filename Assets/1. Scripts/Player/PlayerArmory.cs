using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private List<Gun> _guns;
    public Gun CurrentGun { get; private set; }
    private int _gunIndex;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void Start()
    {
        SearchActiveGun();
    }

    private void Update()
    {
        if (_isPaused) return;
        if (Input.mouseScrollDelta == Vector2.up)
        {
            _gunIndex++;
            ScrolGun();
        }
        else if (Input.mouseScrollDelta == Vector2.down)
        {
            _gunIndex--;
            ScrolGun();
        }

        if (Input.GetMouseButton(0))
        {
            CurrentGun.Shoot();
        }
    }

    private void SearchActiveGun()
    {
        for (int i = 0; i < _guns.Count; i++)
        {
            if (_guns[i].gameObject.activeSelf)
            {
                CurrentGun = _guns[i];
                break;
            }
        }
    }

    public void TakeGunByIndex(int index)
    {
        _gunIndex = index;
        ActivateGun();
    }

    private void ScrolGun()
    {
        if (_gunIndex >= _guns.Count)
        {
            _gunIndex = 0;
        }
        else if (_gunIndex < 0)
        {
            _gunIndex = _guns.Count - 1;
        }
        ActivateGun();
    }

    private void ActivateGun()
    {
        CurrentGun.Deactivate();
        CurrentGun = _guns[_gunIndex];
        CurrentGun.Activate();
    }

    public void AddGun(TakedGun takedGun)
    {
        _guns.Add(takedGun);
    }
}