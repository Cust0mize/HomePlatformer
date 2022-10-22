using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menuInterface;

    public void ActiveMenu()
    {
        _menuInterface.SetActive(!_menuInterface.activeSelf);
        ProjectContext.Instance.PauseManager.SetPaused(_menuInterface.activeSelf);
    }

    public void ReloadGame()
    {
        EventManager.OnResetTime();
        ProjectContext.Instance.PauseManager.SetPaused(!_menuInterface.activeSelf);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
