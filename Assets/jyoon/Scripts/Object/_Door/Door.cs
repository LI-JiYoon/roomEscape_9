using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    public Animator doorAnimator;

    // ���� ��ȣ�ۿ��� �� ǥ���� ������Ʈ �ؽ�Ʈ�� �����ɴϴ�
    public override string GetInteractPrompt()
    {
        return "[E] ����";
    }

    // ������ ��ȣ�ۿ��� ó���մϴ�
    public override void OnInteract()
    {
        // �� ���� �ִϸ��̼��� Ʈ�����մϴ�
        doorAnimator.SetTrigger("Open");
    }
}
}
