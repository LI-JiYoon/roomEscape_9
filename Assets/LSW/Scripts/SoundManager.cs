using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
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

    [SerializeField] private List<AudioSource> bgmSources = new List<AudioSource>(); 
    public AudioSource footStep;

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
            bgmSources[0].Play(); 
        }
        else if (sceneName == "Sangwun")
        {
            bgmSources[1].Play(); 
        }
    }

    private void StopAllBGM()
    {
        foreach (var bgm in bgmSources)
        {
            if (bgm != null) bgm.Stop();
        }
    }

    public void SetMusicMute(bool isMuted)
    {
        foreach (var bgm in bgmSources)
        {
            if (bgm != null) bgm.mute = isMuted;
        }
    }

    public void SetSoundMute(bool isMuted)
    {
        if (footStep != null) footStep.mute = isMuted;
    }

    public float GetMusicVolume()
    {
        foreach (var bgm in bgmSources)
        {
            if (bgm != null && bgm.isPlaying)
            {
                return bgm.volume;
            }
        }
        return 1f; 
    }

    public float GetSoundVolume()
    {
        if (footStep != null)
        {
            return footStep.volume;
        }
        return 1f; 
    }
    public void SetMusicVolume(float volume)
    {
        foreach (var bgm in bgmSources)
        {
            if (bgm != null) bgm.volume = volume;
        }
    }

    public void SetSoundVolume(float volume)
    {
        if (footStep != null)
        {
            footStep.volume = volume;
        }
    }
}
