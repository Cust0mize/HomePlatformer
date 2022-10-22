using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;
    private float _startTimeFixedDeltaTime;
    private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _startTimeFixedDeltaTime = Time.fixedDeltaTime;
        EventManager.ResetTime += ResetTime;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && !_isPaused)
        {
            Time.timeScale = 0.2f;
        }
        else if (!_isPaused)
        {
            Time.timeScale = 1f;
        }
        else if (_isPaused)
        {
            Time.timeScale = 0;
        }
        Time.fixedDeltaTime = Time.timeScale * _startTimeFixedDeltaTime;
    }
    
    private void ResetTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * _startTimeFixedDeltaTime;
    }
}
