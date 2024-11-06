using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : InteractableObject
{
    public Animator doorAnimator;

    // ���� ��ȣ�ۿ��� �� ǥ���� ������Ʈ �ؽ�Ʈ�� �����ɴϴ�
    public override string GetInteractPrompt()
    {
        return "Press 'E' to open the door.";
    }

    // ������ ��ȣ�ۿ��� ó���մϴ�
    public override void OnInteract()
    {
        if (CharacterManager.Instance.Player.equipment.curEquip is KeyEquip)
        {
            // �� ���� �ִϸ��̼��� Ʈ�����ϰ� ���踦 �����մϴ�
            doorAnimator.SetTrigger("Open");
            CharacterManager.Instance.Player.equipment.UnEquip();
        }
        else
        {
            PopupManager.Instance.ShowPopup(PopupManager.Instance.CreateMessagePopup("���谡 �ʿ���."));
        }
    }
}
