using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : InteractableObject
{
    public Animator doorAnimator;

    // 문과 상호작용할 때 표시할 프롬프트 텍스트를 가져옵니다
    public override string GetInteractPrompt()
    {
        return "[E]'열기";
    }

    // 문과의 상호작용을 처리합니다
    public override void OnInteract()
    {

        if (CharacterManager.Instance.Player.equipment.curEquip is Equip)
        {
            // 문 열기 애니메이션을 트리거하고 열쇠를 제거합니다
            doorAnimator.SetTrigger("Open");
            CharacterManager.Instance.Player.equipment.UnEquip();
        }
        else
        {
            PopupManager.Instance.ShowPopup(PopupManager.Instance.CreateMessagePopup("열쇠가 필요해."));
        }
    }
}
