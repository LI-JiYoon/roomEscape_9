using UnityEngine;

public class Locker : InteractableObject
{
    public Transform hidePosition; // ������ ������ ��ġ�� ��Ÿ���ϴ�

    // �����԰� ��ȣ�ۿ��� �� ǥ���� ������Ʈ �ؽ�Ʈ�� �����ɴϴ�
    public override string GetInteractPrompt()
    {
        return "[E] ����";
    }

    // �����԰��� ��ȣ�ۿ��� ó���մϴ�
    public override void OnInteract()
    {
        Player player = CharacterManager.Instance.Player;
        player.transform.position = hidePosition.position;
        Debug.Log("Player is hiding in the locker.");
    }
}