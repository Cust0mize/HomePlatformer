using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _mainSound;
    [SerializeField] private Slider _mainSlider;
    private static SoundManager _instance;

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
        _mainSound.volume = _mainSlider.value;
    }

    public void PlaySound(bool active)
    {
        if (active)
        {
            _mainSound.Play();
        }
        else
        {
            _mainSound.Stop();
        }
    }

    public void ChangingVolume(float value)
    {
        _mainSound.volume = value;
    }
}
