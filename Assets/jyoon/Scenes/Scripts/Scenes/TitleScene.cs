//using System;
//using UnityEngine;

//public class TitleScene : MonoBehaviour
//{
//    #region Prefabs
//    [SerializeField] private GameObject titleUIPrefab;
//    [SerializeField] private StageSO stageSO;

//    private TitleUI titleUI;
//    #endregion

//    private void Start()
//    {
//        // TitleScene 진입점.
//        // UI 초기화
//        UIManager.Instance.LoadSceneUI<TitleUI>();
//        // Event 초기화
//        InitEvent();
//        // 스테이지 초기화
//        StageManager.Instance.InitStage(stageSO);
//        // 화면을 점차적으로 밝게 한다.
//        UIManager.Instance.FadeIn();
//        // GameScene에서 사운드 재생
//        AudioManager.Instance.TitlePlay();
//    }
//    private void InitEvent()
//    {
//        StageManager.Instance?.ClearEvent();
//    }
//}