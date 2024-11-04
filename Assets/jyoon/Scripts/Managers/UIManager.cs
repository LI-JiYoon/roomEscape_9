using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;


namespace RoomEscape.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        //private FadeUI fadeUI;

        //// ���� �˾��� �����ϴ� PopupBase Dictionary
        //private Dictionary<string, PopupBase> popups = new Dictionary<string, PopupBase>();

        //public bool IsPause { get; private set; }

        //public void FadeIn(Action fadedAction = null)
        //{
        //    // ���� ȭ���� ���� ������� ȿ��
        //    LoadFadeUI();
        //    fadeUI.Play(FadeType.FadeIn, fadedAction);
        //}

        //public void FadeOut(Action fadedAction = null)
        //{
        //    // ���� ȭ�� ���� ��ξ����� ȿ��
        //    LoadFadeUI();
        //    fadeUI.Play(FadeType.FadeOut, fadedAction);
        //}

        //private void LoadFadeUI()
        //{
        //    if (fadeUI == null)
        //        fadeUI = ResourceManager.Instance.LoadUI("FadeUI", transform).GetComponent<FadeUI>();
        //}

        //public T ShowPopup<T>() where T : PopupBase
        //{
        //    if (popups.TryGetValue(typeof(T).Name, out PopupBase popup))
        //    {
        //        // Dictionary�� �˾��� �ִ� ��� Ȱ��ȭ�Ѵ�.
        //        popup.gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        string name = typeof(T).Name;
        //        // Dictionary�� �˾��� ���� ��� Prefab�� �ε��Ͽ� �����Ѵ�.
        //        GameObject go = ResourceManager.Instance.LoadUI(name, transform);
        //        if (go == null) return null;
        //        popup = go.GetComponent<PopupBase>();
        //        // Popup�� �����ߴٸ� Dictionary�� �߰��Ѵ�.
        //        popups.Add(name, popup);
        //    }

        //    return popup as T;
        //}

        //// PopupBase�� ��ӹ��� T Ŭ������ �˾��� �ݾ��ش�.
        //public void ClosePopup<T>() where T : PopupBase
        //{
        //    Type type = typeof(T);

        //    if (popups.TryGetValue(type.Name, out PopupBase popupBase))
        //    {
        //        // ���������� Popup�� �ݴ� ���� �ƴ� �Ͻ������� ����ó���� �Ѵ�.
        //        // (Pooling)
        //        popupBase.gameObject.SetActive(false);
        //    }
        //}

        //public void ClosePopup<T>(T popup) where T : PopupBase
        //{
        //    if (popups.TryGetValue(popup.GetType().Name, out PopupBase popupBase))
        //    {
        //        // ���������� Popup�� �ݴ� ���� �ƴ� �Ͻ������� ����ó���� �Ѵ�.
        //        // (Pooling)
        //        popupBase.gameObject.SetActive(false);
        //    }
        //}

        //public void Pause()
        //{
        //    if (IsPause) return;

        //    IsPause = true;
        //    ShowPopup<PausePopup>()?.Init();
        //    Time.timeScale = 0f;
        //}

        //public void Resume()
        //{
        //    if (IsPause == false) return;

        //    IsPause = false;
        //    Time.timeScale = 1f;
        //    ClosePopup<PausePopup>();
        //}

        //public T LoadSceneUI<T>() where T : SceneUIBase
        //{
        //    string name = typeof(T).Name;
        //    GameObject go = ResourceManager.Instance.LoadUI(name);
        //    return go.GetComponent<T>();
        //}
    }
}