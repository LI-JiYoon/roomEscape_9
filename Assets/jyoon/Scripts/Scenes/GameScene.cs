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
//        // GameScene ������
//        // ���ҽ� �ʱ�ȭ
//        ResourceManager.Instance.Init();
//        // UI �ʱ�ȭ
//        UIManager.Instance.LoadSceneUI<GameUI>();
//        // Event �ʱ�ȭ
//        StageManager.Instance?.ClearEvent();
//        // ���� ���� �ʱ�ȭ
//        GameManager.Instance.Init();
//        // �������� ���� �ʱ�ȭ
//        StageManager.Instance.InitStage(stageSO);
//        // �÷��̾� ������ ����
//        GameManager.Instance.PlayerReset();
//        // ���� �������� �ҷ����� -> ���� ���۵�
//        StageManager.Instance.LoadStage();
//        // ���� �÷���
//        AudioManager.Instance.GamePlay();
//        // ȭ���� ���������� ��� �Ѵ�.
//        UIManager.Instance.FadeIn();
//    }
//}