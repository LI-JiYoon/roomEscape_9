public class ItemObject : InteractableObject
{
    public ItemData data;

    // �����۰� ��ȣ�ۿ��� �� ǥ���� ������Ʈ �ؽ�Ʈ�� �����ɴϴ�
    public override string GetInteractPrompt()
    {
        return $"{data.displayName}\n{data.description}";
    }

    // �����۰��� ��ȣ�ۿ��� ó���մϴ�
    public override void OnInteract()
    {
        // �÷��̾ ������ �����͸� �Ҵ��ϰ� ������ �߰� �׼��� ȣ���մϴ�
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();

        // �������� ������ �� ������ ������Ʈ�� �ı��մϴ�
        Destroy(gameObject);
    }
}
