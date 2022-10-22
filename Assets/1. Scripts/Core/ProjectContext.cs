using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public PauseManager PauseManager { get; private set; }
    public static ProjectContext Instance { get; private set; }

    private void Awake()
    {
        Initialize();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public void Initialize()
    {
        PauseManager = new PauseManager();
    }
}
