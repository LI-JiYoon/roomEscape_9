using UnityEngine;

public class Locker : InteractableObject
{
    public Transform hidePosition; // 관물함 내부의 위치를 나타냅니다

    // 관물함과 상호작용할 때 표시할 프롬프트 텍스트를 가져옵니다
    public override string GetInteractPrompt()
    {
        return "[E] 숨기";
    }

    // 관물함과의 상호작용을 처리합니다
    public override void OnInteract()
    {
        Player player = CharacterManager.Instance.Player;
        player.transform.position = hidePosition.position;
        Debug.Log("Player is hiding in the locker.");
    }
}