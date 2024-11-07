using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
   public Equipment equipment;

    public ItemData itemData;
    public Action addItem;

    private void Awake()
    {
        // CharacterManager에서 Player 인스턴스를 이 스크립트로 설정합니다
        CharacterManager.Instance.Player = this;

        // 이 GameObject에 부착된 PlayerController와 PlayerCondition, Equipment 컴포넌트를 가져옵니다
        controller = GetComponent<PlayerController>();
       // condition = GetComponent<PlayerCondition>();
       equipment = GetComponent<Equipment>();

        // 상호작용 콜백을 등록합니다
       //controller.interactAction += HandleInteraction;

    }

    //private void HandleInteraction()
    //{
    //    // 현재 화면에 상호작용 가능한 오브젝트가 있으면 상호작용을 수행합니다
    //    if (Interaction.Instance.curInteractable != null)
    //    {
    //        Interaction.Instance.curInteractable.OnInteract();
    //    }
    //}

}