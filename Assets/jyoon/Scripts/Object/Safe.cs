using UnityEngine;

public class Safe : InteractableObject
{
    public GameObject safeUI;

    // 금고와 상호작용할 때 표시할 프롬프트 텍스트를 가져옵니다
    public override string GetInteractPrompt()
    {
        return "[E] 열기";
    }

    // 금고와의 상호작용을 처리합니다
    public override void OnInteract()
    {
        // 금고 코드를 입력할 수 있는 UI를 활성화합니다
        safeUI.SetActive(true);
    }
}