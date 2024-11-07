//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public enum SoundType
//{
//    BGM,
//    SFX
//}

//public enum AudioClipType
//{
//    None,

//    bgm1,
//    bgm2,
//    bgm3,
//    bgm4,
//    bgm5,

//    shoot,
//    brick_break,
//    brick_bounce,
//    wall_bounce,
//    paddle_bounce,
//    gameover,
//}

//public class AudioManager : Singleton<AudioManager>
//{
//    private AudioSource bgm;
//    public AudioSource Bgm
//    {
//        get
//        {
//            if (bgm == null)
//            {
//                GameObject go = new GameObject { name = "BGM" };
//                go.transform.SetParent(transform);
//                bgm = go.AddComponent<AudioSource>();
//                bgm.loop = true;
//            }
//            return bgm;
//        }
//    }
//    private AudioSource sfx;
//    public AudioSource Sfx
//    {
//        get
//        {
//            if (sfx == null)
//            {
//                GameObject go = new GameObject { name = "SFX" };
//                go.transform.SetParent(transform);
//                sfx = go.AddComponent<AudioSource>();
//            }
//            return sfx;
//        }
//    }

//    public void Play(AudioClipType clipType, SoundType soundType, float pitch = 1.0f)
//    {
//        if (clipType == AudioClipType.None)
//            return;

//        AudioClip clip = ResourceManager.Instance.LoadSound(soundType, clipType);
//        if (clip == null)
//        {
//            Debug.Log($"{soundType} AudioClip is null! {clipType}");
//            return;
//        }

//        if (soundType == SoundType.BGM) // BGM ������� ���
//        {
//            if (Bgm.isPlaying)
//                Bgm.Stop();

//            Bgm.pitch = pitch;
//            Bgm.clip = clip;
//            Bgm.Play();
//        }
//        else // Effect ȿ���� ���
//        {
//            Sfx.pitch = pitch;
//            Sfx.PlayOneShot(clip);
//        }
//    }

//    public void PlayBgm(AudioClipType clipType, float pitch = 1.0f)
//    {
//        Play(clipType, SoundType.BGM, pitch);
//    }

//    public void PlaySfx(AudioClipType clipType, float pitch = 1.0f)
//    {
//        Play(clipType, SoundType.SFX, pitch);
//    }

//    public void VolumeBgm(float value)
//    {
//        Bgm.volume = value;
//    }

//    public void VolumeSfx(float value)
//    {
//        Sfx.volume = value;
//    }

//    public void Pause(SoundType type)
//    {
//        if (type == SoundType.BGM)
//            Bgm.Pause();
//        else
//            Sfx.Pause();
//    }

//    public void Resume(SoundType type)
//    {
//        if (type == SoundType.BGM)
//            Bgm.UnPause();
//        else
//            Sfx.UnPause();
//    }

//    public void TitlePlay()
//    {
//        SaveSettingData settingData = SaveManager.Instance.Load<SaveSettingData>();
//        PlayBgm(settingData.titleBGM);
//        VolumeBgm(settingData.bgmVolume);
//        VolumeSfx(settingData.sfxVolume);
//    }

//    public void GamePlay()
//    {
//        SaveSettingData settingData = SaveManager.Instance.Load<SaveSettingData>();
//        PlayBgm(settingData.gameBGM);
//        VolumeBgm(settingData.bgmVolume);
//        VolumeSfx(settingData.sfxVolume);
//    }
//}