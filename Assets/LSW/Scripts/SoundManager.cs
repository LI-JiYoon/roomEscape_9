using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject soundManager = new GameObject("SoundManager");
                    instance = soundManager.AddComponent<SoundManager>();
                    DontDestroyOnLoad(soundManager);
                }            
            }
            return instance;
        }
    }

    [SerializeField] private AudioSource IntroBgm;
    [SerializeField] private AudioSource GameBgm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGMByScene(scene.name);
    }

    private void PlayBGMByScene(string sceneName)
    {
        StopAllBGM();

        if (sceneName == "IntroScene")
        {
            if (IntroBgm != null) IntroBgm.Play();
        }
        else if (sceneName == "MainScene")
        {
            if (GameBgm != null) GameBgm.Play();
        }
    }

    private void StopAllBGM()
    {
        if (IntroBgm != null) IntroBgm.Stop();
        if (GameBgm != null) GameBgm.Stop();
    }

    public void SetMusicMute(bool isMuted)
    {
        if (IntroBgm != null) IntroBgm.mute = isMuted;
        if (GameBgm != null) GameBgm.mute = isMuted;
    }
}
