using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Events;
using UnityEngine.UI;

public enum FadeType
{
    FadeIn,
    FadeOut
}

public class FadeUI : MonoBehaviour
{
    private Action fadedAction;    

    [SerializeField] private FadeType fadeType;
    [SerializeField] private Image screen;

    [SerializeField][Header("ȿ�� ��ȯ �ð�")] private float duration = 1f;
    private float fadeTime = 0f;
    private bool isPlaying = false;

    [Space(20)]
    public UnityEvent callback; //���� �ൿ ����(������ �ҷ�����)
   




    private void Update()
    {
        FadeUpdate();
    }

    private void FadeUpdate()
    {
        if (isPlaying)
        {
            fadeTime += Time.deltaTime;

            if (fadeType == FadeType.FadeIn)
            {
                FadeIn();
            }
            else if (fadeType == FadeType.FadeOut)
            {
                FadeOut();
            }
        }
    }

    /// <summary>
    /// Fade in/out ����(Unity �̺�Ʈ ��)
    /// </summary>
    public void Play()
    {
        this.isPlaying = true;

        if (fadeType == FadeType.FadeIn)
            screen.color = new Color(0, 0, 0, 1);
        else
            screen.color = new Color(0, 0, 0, 0);

        fadeTime = 0;
        screen.gameObject.SetActive(true);
    }
    /// <summary>
    /// Fade in/out ����(ȣ���)
    /// </summary>
    /// <param name="fadeType">Fade in/out ����</param>
    /// <param name="fadedAction">callback �Ҵ�</param>
    public void Play(FadeType fadeType, Action fadedAction = null)
    {
        this.isPlaying = true;
        this.fadeType = fadeType;
        this.fadedAction = fadedAction;

        if (fadeType == FadeType.FadeIn)
            screen.color = new Color(0, 0, 0, 1);
        else
            screen.color = new Color(0, 0, 0, 0);

        fadeTime = 0;
        screen.gameObject.SetActive(true);
    }


    #region
    private void FadeIn()
    {
        float alpha = Mathf.Max(1 - (fadeTime / (duration)), 0);
        AlphaChange(alpha);

        if (fadeTime >= duration)
        {
            isPlaying = false;
            CallFadedAction();
            gameObject.SetActive(false);
            callback.Invoke();
        }
    }

    private void FadeOut()
    {
        float alpha = Mathf.Min(fadeTime / duration, 1);
        AlphaChange(alpha);

        if (fadeTime >= duration)
        {
            isPlaying = false;
            CallFadedAction();
            callback.Invoke();
        }
    }

    private void AlphaChange(float alpha)
    {
        Color color = screen.color;
        color.a = alpha;
        screen.color = color;
    }

    private void CallFadedAction()
    {
        fadeTime = 0;
        fadedAction?.Invoke();
    }
    #endregion
}