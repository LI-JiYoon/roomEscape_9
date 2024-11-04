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

    [SerializeField][Header("효과 전환 시간")] private float duration = 1f;
    private float fadeTime = 0f;
    private bool isPlaying = false;

    [Space(20)]
    public UnityEvent callback; //다음 행동 예약(포스터 불러오기)
   




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
    /// Fade in/out 실행(Unity 이벤트 용)
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
    /// Fade in/out 실행(호출용)
    /// </summary>
    /// <param name="fadeType">Fade in/out 선택</param>
    /// <param name="fadedAction">callback 할당</param>
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