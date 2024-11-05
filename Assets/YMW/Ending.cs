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
        if (!excapeKey)
        {
            //배드 엔딩 근데 조건이 애매함
            //return;

            badEndingImage.enabled = true;
            endingTitleStr = "BAD ENDING";
            endingStoryStr = "끝내 탈출에 실패한 주인공은 그곳에 영원히 갇혀, 귀신의 집의 또 다른 존재로 남게 된다.";
        }


        if (trueEndingItem)
        {
            trueEndingImage.enabled = true;
            endingTitleStr = "TRUE ENDING";
            endingStoryStr = "탈출 중 발견한 증거로 모든 사건의 음모를 알게 된 주인공은 진실을 밝혀내기 위해 결단을 내린다.";
        }
        else
        {
            normalEndingImage.enabled = true;
            endingTitleStr = "NORMAL ENDING";
            endingStoryStr = "간신히 병원을 빠져나온 주인공은 무사히 탈출에 성공하지만, 끔찍했던 기억만이 남아 있다.";
        }

        SetEndingText();
        this.gameObject.SetActive(true);
    }

    public void SetEndingText()
    {
        endingTitle.text = endingTitleStr;
        endingStory.text = endingStoryStr;
    }
}
