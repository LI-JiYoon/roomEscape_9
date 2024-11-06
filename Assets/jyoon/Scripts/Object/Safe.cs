using TMPro;
using UnityEngine;

public class Safe : InteractableObject
{
    public GameObject safeUI;
    public TMP_InputField inputField;
    public string correctCode = "�ҷ���";
    public ItemData rewardItem;

    // �ݰ�� ��ȣ�ۿ��� �� ǥ���� ������Ʈ �ؽ�Ʈ�� �����ɴϴ�
    public override string GetInteractPrompt()
    {
        return "Press 'E' to enter code.";
    }

    // �ݰ���� ��ȣ�ۿ��� ó���մϴ�
    public override void OnInteract()
    {
        // �ݰ� �ڵ带 �Է��� �� �ִ� UI�� PopupManager�� ���� Ȱ��ȭ�մϴ�
        PopupManager.Instance.ShowPopup(safeUI);
    }

    // �Էµ� �ڵ� Ȯ��
    public void OnSubmitCode()
    {
        if (inputField.text == correctCode)
        {
            // ������ ������ ���� �������� �κ��丮�� �߰��մϴ�
            Player player = CharacterManager.Instance.Player;
            player.itemData = rewardItem;
            player.addItem?.Invoke();

            // Save progress
            SaveManager.Instance.SavePuzzleSolved(gameObject.name);

            // �ݰ� UI �ݱ�
            PopupManager.Instance.HidePopup(safeUI);
        }
        else
        {
            // ������ Ʋ���� ���� �޽��� �˾�
            UIManager.Instance.ShowErrorMessage("����� �ٸ��ϴ�");
        }
    }
}
