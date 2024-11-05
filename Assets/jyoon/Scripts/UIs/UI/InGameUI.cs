using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject optionPanel;
    public Image musicIcon;
    public Image soundIcon;
    public GameObject achievementPanel;
    public GameObject saveButton;
    public GameObject loadButton;

    public OptionUI option;

    private Color originalColor; 

    private void Start()
    {
        originalColor = musicIcon.color; 
    }

    private void Update()
    {
        musicIcon.color = option.isMusicMuted ? Color.red : originalColor;
        soundIcon.color = option.isSoundMuted ? Color.red : originalColor;
    }
                                                                           

    public void OnClickCloseBtn()
    {
        optionPanel.SetActive(false);
    }

    public void OnClickExitBtn()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void OnClickAchievementIcon()
    {
        achievementPanel.SetActive(!achievementPanel.activeSelf);
    }
}
