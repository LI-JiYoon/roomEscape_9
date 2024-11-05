using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject loadBtn;
    public GameObject saveBtn;
    public Slider musicSlider;
    public Slider soundSlider;

    public Button musicBtn;
    public Button soundBtn;

    private Color originalColor;
    private Color muteColor = Color.red;

    public bool isMusicMuted;
    public bool isSoundMuted;

    private void Start()
    {
        musicSlider.value = SoundManager.Instance != null ? SoundManager.Instance.GetMusicVolume() : 1f;
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        soundSlider.value = SoundManager.Instance != null ? SoundManager.Instance.GetSoundVolume() : 1f;
        soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);

        isMusicMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        isSoundMuted = PlayerPrefs.GetInt("SoundMuted", 0) == 1;

        originalColor = musicBtn.image.color;

        UpdateMusicIcon();
        UpdateSoundIcon();
    }

    public void OpenOptionUI()
    {
        optionPanel.SetActive(true);

        if (SceneManager.GetActiveScene().name == "IntroScene")
        {
            loadBtn.SetActive(true);
            saveBtn.SetActive(false);
        }
        else
        {
            loadBtn.SetActive(false);
            saveBtn.SetActive(true);
        }
    }

    public void CloseOptionUI()
    {
        optionPanel.SetActive(false);
    }

    public void OnClickMusicIcon()
    {
        isMusicMuted = !isMusicMuted;
        PlayerPrefs.SetInt("MusicMuted", isMusicMuted ? 1 : 0);
        UpdateMusicIcon();
    }

    public void OnClickSoundIcon()
    {
        isSoundMuted = !isSoundMuted;
        PlayerPrefs.SetInt("SoundMuted", isSoundMuted ? 1 : 0);
        UpdateSoundIcon();
    }

    private void UpdateMusicIcon()
    {
        musicBtn.image.color = isMusicMuted ? muteColor : originalColor;
        SoundManager.Instance.SetMusicMute(isMusicMuted);
    }

    private void UpdateSoundIcon()
    {
        soundBtn.image.color = isSoundMuted ? muteColor : originalColor;
        SoundManager.Instance.SetSoundMute(isSoundMuted);
    }

    public void OnClickCloseBtn()
    {
        optionPanel.SetActive(false);
    }

    public void OnClickExitBtn()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void OnMusicSliderValueChanged(float value)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetMusicVolume(value);
        }
    }

    public void OnSoundSliderValueChanged(float value)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetSoundVolume(value);
        }
    }
}
