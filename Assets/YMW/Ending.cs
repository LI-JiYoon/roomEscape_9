using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public bool excapeKey = false;
    public bool trueEndingItem = false;

    //���� UI��ũ��Ʈ�� �ٸ��� �� ��� �ʿ��Ҽ���
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

        //EndingItem���� Find �Ҷ� ���������� ��ã��
        Invoke("SetActiveFalse", 0.1f);
    }

    public void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }

    public void GameEnding()
    {
        if (!excapeKey) return;

        if (trueEndingItem)
        {
            trueEndingImage.enabled = true;
            endingTitleStr = "True Ending";
            endingStoryStr = "Ʈ�翣�� Ż�� ���丮";
        }
        else
        {
            normalEndingImage.enabled = true;
            endingTitleStr = "Normal Ending";
            endingStoryStr = "�׳� Ż�� ���丮";
        }

        SetEndingText();

    }

    public void SetEndingText()
    {
        endingTitle.text = endingTitleStr;
        endingStory.text = endingStoryStr;
    }
}
