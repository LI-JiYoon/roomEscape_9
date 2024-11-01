using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    public Text startText;
    public Text optionText;
    public Text exitText;

    public Color highlightColor = Color.yellow;
    public Color startHighlightColor = Color.black;

    private Color startOriginalColor;
    private Color optionOriginalColor;
    private Color exitOriginalColor;

    public PosterUI poster;

    private void Start()
    {
        Time.timeScale = 1;
        startOriginalColor = startText.color;
        optionOriginalColor = optionText.color;
        exitOriginalColor = exitText.color;
    }

    public void HighlightText(Text text)
    {
        if (text == startText)
            text.color = startHighlightColor;
        else
            text.color = highlightColor;
    }

    public void ResetTextColor(Text text)
    {
        if (text == startText)
            text.color = startOriginalColor;
        else if (text == optionText)
            text.color = optionOriginalColor;
        else if (text == exitText)
            text.color = exitOriginalColor;
    }

    public void OpenStartUI()
    {
        poster.OnPoster();
    }

    public void OpenExitUI()
    {
        Debug.Log("Exit UI opened");
    }
}
