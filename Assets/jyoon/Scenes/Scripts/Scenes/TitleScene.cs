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
//        // TitleScene ������.
//        // UI �ʱ�ȭ
//        UIManager.Instance.LoadSceneUI<TitleUI>();
//        // Event �ʱ�ȭ
//        InitEvent();
//        // �������� �ʱ�ȭ
//        StageManager.Instance.InitStage(stageSO);
//        // ȭ���� ���������� ��� �Ѵ�.
//        UIManager.Instance.FadeIn();
//        // GameScene���� ���� ���
//        AudioManager.Instance.TitlePlay();
//    }
//    private void InitEvent()
//    {
//        StageManager.Instance?.ClearEvent();
//    }
//}