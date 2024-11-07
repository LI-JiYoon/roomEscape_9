public class ItemObject : InteractableObject
{
    public ItemData data;

    // 아이템과 상호작용할 때 표시할 프롬프트 텍스트를 가져옵니다
    public override string GetInteractPrompt()
    {
        return $"{data.displayName}\n{data.description}";
    }

    // 아이템과의 상호작용을 처리합니다
    public override void OnInteract()
    {
        // 플레이어에 아이템 데이터를 할당하고 아이템 추가 액션을 호출합니다
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();

        // 아이템을 습득한 후 아이템 오브젝트를 파괴합니다
        Destroy(gameObject);
    }
}
