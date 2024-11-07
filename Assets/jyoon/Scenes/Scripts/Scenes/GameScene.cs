//using System.Collections;
//using System.Collections.Generic;
//using System.Resources;
//using UnityEngine;

//public class GameScene : MonoBehaviour
//{
//    #region Prefabs
//    [SerializeField] private StageSO stageSO;
//    #endregion

//    void Start()
//    {
//        // GameScene 진입점
//        // 리소스 초기화
//        ResourceManager.Instance.Init();
//        // UI 초기화
//        UIManager.Instance.LoadSceneUI<GameUI>();
//        // Event 초기화
//        StageManager.Instance?.ClearEvent();
//        // 게임 정보 초기화
//        GameManager.Instance.Init();
//        // 스테이지 정보 초기화
//        StageManager.Instance.InitStage(stageSO);
//        // 플레이어 데이터 리셋
//        GameManager.Instance.PlayerReset();
//        // 게임 스테이지 불러오기 -> 게임 시작됨
//        StageManager.Instance.LoadStage();
//        // 사운드 플레이
//        AudioManager.Instance.GamePlay();
//        // 화면을 점차적으로 밝게 한다.
//        UIManager.Instance.FadeIn();
//    }
//}