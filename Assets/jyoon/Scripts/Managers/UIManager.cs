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

        //// 열린 팝업을 관리하는 PopupBase Dictionary
        //private Dictionary<string, PopupBase> popups = new Dictionary<string, PopupBase>();

        //public bool IsPause { get; private set; }

        //public void FadeIn(Action fadedAction = null)
        //{
        //    // 검은 화면이 점점 밝아지는 효과
        //    LoadFadeUI();
        //    fadeUI.Play(FadeType.FadeIn, fadedAction);
        //}

        //public void FadeOut(Action fadedAction = null)
        //{
        //    // 밝은 화면 점점 어두어지는 효과
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
        //        // Dictionary에 팝업이 있는 경우 활성화한다.
        //        popup.gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        string name = typeof(T).Name;
        //        // Dictionary에 팝업이 없는 경우 Prefab을 로드하여 생성한다.
        //        GameObject go = ResourceManager.Instance.LoadUI(name, transform);
        //        if (go == null) return null;
        //        popup = go.GetComponent<PopupBase>();
        //        // Popup을 생성했다면 Dictionary에 추가한다.
        //        popups.Add(name, popup);
        //    }

        //    return popup as T;
        //}

        //// PopupBase를 상속받은 T 클래스의 팝업을 닫아준다.
        //public void ClosePopup<T>() where T : PopupBase
        //{
        //    Type type = typeof(T);

        //    if (popups.TryGetValue(type.Name, out PopupBase popupBase))
        //    {
        //        // 실질적으로 Popup을 닫는 것이 아닌 일시적으로 숨김처리를 한다.
        //        // (Pooling)
        //        popupBase.gameObject.SetActive(false);
        //    }
        //}

        //public void ClosePopup<T>(T popup) where T : PopupBase
        //{
        //    if (popups.TryGetValue(popup.GetType().Name, out PopupBase popupBase))
        //    {
        //        // 실질적으로 Popup을 닫는 것이 아닌 일시적으로 숨김처리를 한다.
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