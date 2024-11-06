using UnityEngine;

public class Safe : InteractableObject
{
    public GameObject safeUI;

    // �ݰ�� ��ȣ�ۿ��� �� ǥ���� ������Ʈ �ؽ�Ʈ�� �����ɴϴ�
    public override string GetInteractPrompt()
    {
        return "[E] ����";
    }
    // �ݰ���� ��ȣ�ۿ��� ó���մϴ�
    public override void OnInteract()
    {
        // �ݰ� �ڵ带 �Է��� �� �ִ� UI�� PopupManager�� ���� Ȱ��ȭ�մϴ�
        PopupManager.Instance.ShowPopup(safeUI);
    }
}