using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public bool excapeKey = false;
    public bool trueEndingItem = false;

    //엔딩 UI스크립트를 다른데 달 경우 필요할수도
    public GameObject endingUI;

    [SerializeField] private Image badEndingImage;
    [SerializeField] private Image normalEndingImage;
    [SerializeField] private Image trueEndingImage;

    [SerializeField] private Text endingTitle;
    [SerializeField] private Text endingStory;

    string endingTitleStr;
    string endingStoryStr;

    // Start is called before the first frame update
    void Start()
    {
        badEndingImage.enabled = false;
        normalEndingImage.enabled = false;
        trueEndingImage.enabled = false;

        //EndingItem에서 Find 할때 꺼져있으면 못찾음
        Invoke("SetActiveFalse", 0.1f);
    }

    public void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }

    public void GameEnding()
    {
        if (!excapeKey) return;

        this.gameObject.SetActive(true);

        if (trueEndingItem)
        {
            trueEndingImage.enabled = true;
            endingTitleStr = "True Ending";
            endingStoryStr = "트루엔딩 탈출 스토리";
        }
        else
        {
            normalEndingImage.enabled = true;
            endingTitleStr = "Normal Ending";
            endingStoryStr = "그냥 탈출 스토리";
        }

        SetEndingText();

    }

    public void SetEndingText()
    {
        endingTitle.text = endingTitleStr;
        endingStory.text = endingStoryStr;
    }
}
