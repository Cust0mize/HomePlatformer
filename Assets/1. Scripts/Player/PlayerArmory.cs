using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [field: SerializeField] public List<Gun> Guns { get; private set; }
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
        for (int i = 0; i < Guns.Count; i++)
        {
            if (Guns[i].gameObject.activeSelf)
            {
                CurrentGun = Guns[i];
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
        if (_gunIndex >= Guns.Count)
        {
            _gunIndex = 0;
        }
        else if (_gunIndex < 0)
        {
            _gunIndex = Guns.Count - 1;
        }
        ActivateGun();
    }

    private void ActivateGun()
    {
        CurrentGun.Deactivate();
        CurrentGun = Guns[_gunIndex];
        CurrentGun.Activate();
    }

    public void AddGun(TakedGun takedGun)
    {
        Guns.Add(takedGun);
    }
}